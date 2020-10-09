using Microsoft.Extensions.DependencyInjection;

namespace StringsProcessor.Application.PipeBuilders.LineProcessing
{
    internal static class DiExtensions
    {
        public static void AddLineProcessingPipe(this IServiceCollection services)
        {
            services.AddSingleton<ILineProcessingPipeBuilder, ConcurrentLineProcessingPipeBuilder>();
        }
    }
}
