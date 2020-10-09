using System.Collections.Generic;
using System.Threading.Tasks;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Processor
{
    public interface IProcessor
    {
        Task Process();
    }
}
