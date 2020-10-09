using System.Collections.Generic;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Output
{
    public interface IOutputChannel
    {
        void Send(IReadOnlyCollection<Line> lines);
    }
}
