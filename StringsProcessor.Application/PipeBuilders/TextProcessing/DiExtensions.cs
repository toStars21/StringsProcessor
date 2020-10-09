using Microsoft.Extensions.DependencyInjection;

namespace StringsProcessor.Application.PipeBuilders.TextProcessing
{
    internal static class DiExtensions
    {
        public static void AddTextProcessingPipe(this IServiceCollection services)
        {
            services.AddSingleton<ITextProcessingPipeBuilder, TextProcessingPipeBuilder>();
        }
    }
}
