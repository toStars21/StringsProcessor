using System.Threading.Tasks;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Output;
using StringsProcessor.Application.PipeBuilders.TextProcessing;

namespace StringsProcessor.Application.Processor
{
    internal class ConcurrentProcessor : IProcessor
    {
        private readonly ITextProcessingPipeBuilder _pipeBuilder;
        private readonly IOutputChannel _out;

        public ConcurrentProcessor(ITextProcessingPipeBuilder pipeBuilder, IOutputChannel @out)
        {
            _pipeBuilder = pipeBuilder;
            _out = @out;
        }

        public async Task Process()
        {
            var pipe = _pipeBuilder.Build();

            var context = new TextProcessingContext();

            await pipe.Send(context);

            _out.Send(context.ProcessedLines);
        }
    }
}
