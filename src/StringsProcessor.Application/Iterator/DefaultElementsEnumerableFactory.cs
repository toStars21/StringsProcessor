using System;
using System.Collections.Generic;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Iterator
{
    internal class DefaultElementsEnumerableFactory : IElementsEnumerableFactory
    {
        public IEnumerable<Element> Create(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));

            var elements = line.Split(',');

            foreach (var element in elements)
            {
                yield return new Element(element);
            }
        }
    }
}
