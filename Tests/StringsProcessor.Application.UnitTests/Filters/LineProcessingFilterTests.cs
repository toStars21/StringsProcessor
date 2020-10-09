using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes.Pipes;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Domain;
using StringsProcessor.Application.Filters.LineProcessing;
using StringsProcessor.Application.Iterator;

namespace StringsProcessor.Application.UnitTests.Filters
{
    public class LineProcessingFilterTests
    {
        [Test]
        public async Task LineProcessingFilter_Send_Create_ElementsEnumerable_Correct()
        {
            string rawLine = "1, 2,3";

            var context = new LineProcessingContext
            {
                RawLine = rawLine,
                LineIndex = 10
            };

            var enumerableFactorySub = Substitute.For<IElementsEnumerableFactory>();

            var filter = new RawLineProcessingFilter(enumerableFactorySub);

            await filter.Send(context, new EmptyPipe<LineProcessingContext>());

            enumerableFactorySub
                .Received(Quantity.Exactly(1))
                .Create(Arg.Is(rawLine));
        }

        [Test]
        public async Task LineProcessingFilter_Send_Use_ElementsEnumerable_Results_Correct()
        {
            string rawLine = "1, 2,3";

            var expected = new List<Element>() {new Element("asd")};

            var enumerableFactorySub = Substitute.For<IElementsEnumerableFactory>();
            enumerableFactorySub.Create(Arg.Is(rawLine)).Returns(expected);

            var context = new LineProcessingContext
            {
                RawLine = rawLine,
                LineIndex = 10
            };

            var filter = new RawLineProcessingFilter(enumerableFactorySub);

            await filter.Send(context, new EmptyPipe<LineProcessingContext>());

            CollectionAssert.AreEquivalent(
                expected.Select(e => e.Value),
                context.ProcessedLine.Elements.Select(e => e.Value));
        }
    }
}
