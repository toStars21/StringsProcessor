using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using GreenPipes;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Settings;

namespace StringsProcessor.Application.Filters.TextProcessing
{
    internal class TextLinesParallelProcessingFilter : IFilter<TextProcessingContext>
    {
        private readonly IPipe<LineProcessingContext> _lineProcessingPipe;
        private readonly ActionBlock<LineProcessingContext> _processLine;
        private readonly ConcurrencySettings _settings;

        public TextLinesParallelProcessingFilter(IPipe<LineProcessingContext> lineProcessingPipe, ConcurrencySettings settings)
        {
            _lineProcessingPipe = lineProcessingPipe;
            _settings = settings;
            _processLine = new ActionBlock<LineProcessingContext>(
                context => _lineProcessingPipe.Send(context),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = 1,
                    EnsureOrdered = false,
                    MaxDegreeOfParallelism = _settings.DegreeOfParallelism
                });
        }

        public async Task Send(TextProcessingContext context, IPipe<TextProcessingContext> next)
        {
            var lineProcessingContexts = new List<LineProcessingContext>();
            for (int lineIndex = 0; lineIndex < context.RawLines.Length; lineIndex++)
            {
                lineProcessingContexts.Add(
                    new LineProcessingContext
                    {
                        RawLine = context.RawLines[lineIndex],
                        LineIndex = lineIndex
                    });
            }

            var tasks = new List<Task>();
            foreach (var lineProcessingContext in lineProcessingContexts)
            {
                tasks.Add(_processLine.SendAsync(lineProcessingContext));
            }

            await Task.WhenAll(tasks);

            foreach (var lineProcessingContext in lineProcessingContexts)
            {
                context.ProcessedLines.Add(lineProcessingContext.ProcessedLine);
            }

            await next.Send(context);
        }

        public void Probe(ProbeContext context) { }
    }
}
