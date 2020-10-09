using Microsoft.Extensions.DependencyInjection;
using StringsProcessor.Application.Input;
using StringsProcessor.Application.Iterator;
using StringsProcessor.Application.PipeBuilders.LineProcessing;
using StringsProcessor.Application.PipeBuilders.TextProcessing;
using StringsProcessor.Application.Settings;

namespace StringsProcessor.Application.Processor
{
    public static class DiExtensions
    {
        public static void AddTextProcessor(this IServiceCollection services)
        {
            services.AddSingleton<IProcessor, ConcurrentProcessor>();
            services.AddLineProcessingPipe();
            services.AddTextProcessingPipe();
            services.AddInputProviders();
            services.AddElementsIteratorFactory();
        }
    }
}
