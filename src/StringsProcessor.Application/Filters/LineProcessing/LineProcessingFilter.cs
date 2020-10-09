using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Domain;
using StringsProcessor.Application.Iterator;

namespace StringsProcessor.Application.Filters.LineProcessing
{
    internal class LineProcessingFilter : IFilter<LineProcessingContext>
    {
        private readonly IElementsEnumerableFactory _enumerableFactory;

        public LineProcessingFilter(IElementsEnumerableFactory enumerableFactory)
        {
            _enumerableFactory = enumerableFactory;
        }

        public async Task Send(LineProcessingContext context, IPipe<LineProcessingContext> next)
        {
            var elements = _enumerableFactory.Create(context.RawLine);

            context.ProcessedLine = new Line(context.LineIndex, elements.ToList());

            await next.Send(context);
        }

        public void Probe(ProbeContext context) { }
    }
}
