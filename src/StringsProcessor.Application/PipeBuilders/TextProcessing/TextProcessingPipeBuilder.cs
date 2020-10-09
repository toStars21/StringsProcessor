using GreenPipes;
using Microsoft.Extensions.Options;
using StringsProcessor.Application.Contexts;
using StringsProcessor.Application.Filters.Exceptions;
using StringsProcessor.Application.Filters.TextProcessing;
using StringsProcessor.Application.Input;
using StringsProcessor.Application.PipeBuilders.LineProcessing;
using StringsProcessor.Application.Settings;

namespace StringsProcessor.Application.PipeBuilders.TextProcessing
{
    internal class TextProcessingPipeBuilder : ITextProcessingPipeBuilder
    {
        private readonly IInputProvider _input;
        private readonly ILineProcessingPipeBuilder _lineProcessingPipeBuilder;
        private readonly ConcurrencySettings _settings;

        public TextProcessingPipeBuilder(IInputProvider input, ILineProcessingPipeBuilder lineProcessingPipeBuilder, IOptions<ConcurrencySettings> settings)
        {
            _input = input;
            _lineProcessingPipeBuilder = lineProcessingPipeBuilder;
            _settings = settings.Value;
        }

        public IPipe<TextProcessingContext> Build()
        {
            return Pipe.New<TextProcessingContext>(configurator =>
            {
                configurator.UseFilter(new ExceptionLoggingFilter<TextProcessingContext>());
                configurator.UseFilter(new ExtractTextFilter(_input));
                configurator.UseFilter(new SplitByLinesFilter());
                configurator.UseFilter(new TextLinesParallelProcessingFilter(_lineProcessingPipeBuilder.Build(), _settings));
            });
        }
    }
}
