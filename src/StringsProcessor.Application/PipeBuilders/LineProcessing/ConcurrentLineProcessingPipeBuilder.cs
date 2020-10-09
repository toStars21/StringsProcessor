using GreenPipes;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Filters.LineProcessing;
using StringsProcessor.Application.Iterator;

namespace StringsProcessor.Application.PipeBuilders.LineProcessing
{
    internal class ConcurrentLineProcessingPipeBuilder : ILineProcessingPipeBuilder
    {
        private readonly IElementsEnumerableFactory _elementsEnumerableFactory;

        public ConcurrentLineProcessingPipeBuilder(IElementsEnumerableFactory elementsEnumerableFactory)
        {
            _elementsEnumerableFactory = elementsEnumerableFactory;
        }

        public IPipe<LineProcessingContext> Build()
        {
            return Pipe.New<LineProcessingContext>(configurator =>
            {
                configurator.UseFilter(new RawLineProcessingFilter(_elementsEnumerableFactory));
            });
        }
    }
}
