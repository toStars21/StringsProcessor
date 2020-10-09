using System.Threading.Tasks;
using GreenPipes;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Input;

namespace StringsProcessor.Application.Filters.TextProcessing
{
    internal class ExtractTextFilter : IFilter<TextProcessingContext>
    {
        private readonly IInputProvider _input;

        public ExtractTextFilter(IInputProvider input)
        {
            _input = input;
        }

        public async Task Send(TextProcessingContext context, IPipe<TextProcessingContext> next)
        {
            var source = await _input.GetAsync();

            context.SourceText = source;

            await next.Send(context);
        }

        public void Probe(ProbeContext context) {}
    }
}
