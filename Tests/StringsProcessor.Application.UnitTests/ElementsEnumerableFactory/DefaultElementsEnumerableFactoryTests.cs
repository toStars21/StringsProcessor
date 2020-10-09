using System.Linq;
using NUnit.Framework;
using StringsProcessor.Application.Domain;
using StringsProcessor.Application.Iterator;

namespace StringsProcessor.Application.UnitTests.ElementsEnumerableFactory
{
    public class DefaultElementsEnumerableFactoryTests
    {
        [Test]
        public void DefaultElementsEnumerableFactory_Create_Enumerable_Correct()
        {
            var factory = new DefaultElementsEnumerableFactory();

            string line = "1, 2, 15, asd, ,";

            var expected = line.Split(',').Select(s => new Element(s));

            var actual = factory.Create(line);

            CollectionAssert.AreEquivalent(
                expected.Select(e => e.Value),
                actual.Select(e => e.Value));
        }
    }
}
