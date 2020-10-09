using GreenPipes;
using StringsProcessor.Application.Contexts;

namespace StringsProcessor.Application.PipeBuilders.TextProcessing
{
    internal interface ITextProcessingPipeBuilder
    {
        IPipe<TextProcessingContext> Build();
    }
}
