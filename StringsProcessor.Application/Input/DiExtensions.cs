using Microsoft.Extensions.DependencyInjection;
using StringsProcessor.Application.Input.File;

namespace StringsProcessor.Application.Input
{
    internal static class DiExtensions
    {
        public static void AddInputProviders(this IServiceCollection services)
        {
            services.AddSingleton<IInputProvider, FileInputProvider>();
        }
    }
}
