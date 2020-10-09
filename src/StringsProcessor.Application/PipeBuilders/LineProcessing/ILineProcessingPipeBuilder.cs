using GreenPipes;
using StringsProcessor.Application.Contexts;

namespace StringsProcessor.Application.PipeBuilders.LineProcessing
{
    internal interface ILineProcessingPipeBuilder
    {
        IPipe<LineProcessingContext> Build();
    }
}
