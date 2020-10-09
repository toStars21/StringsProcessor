using System.Collections.Generic;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Iterator
{
    public interface IElementsEnumerableFactory
    {
        IEnumerable<Element> Create(string line);
    }
}
