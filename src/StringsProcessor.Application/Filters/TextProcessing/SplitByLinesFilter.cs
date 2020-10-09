using System.Threading.Tasks;
using GreenPipes;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Extensions;

namespace StringsProcessor.Application.Filters.TextProcessing
{
    internal class SplitByLinesFilter : IFilter<TextProcessingContext>
    {
        public async Task Send(TextProcessingContext context, IPipe<TextProcessingContext> next)
        {
            context.RawLines = context.SourceText.SplitByEOL();

            await next.Send(context);
        }

        public void Probe(ProbeContext context) { }
    }
}
