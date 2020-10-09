using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StringsProcessor.Application.Settings;
using StringsProcessor.Host.Options;

namespace StringsProcessor.Host.Settings
{
    internal static class DiExtensions
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<FileInputSettings>()
                .Bind(configuration.GetSection(FileInputSettings.FileInput))
                .ValidateDataAnnotations()
                .ValidateEagerly();

            services
                .AddOptions<ConcurrencySettings>()
                .Bind(configuration.GetSection(ConcurrencySettings.Concurrency))
                .ValidateDataAnnotations()
                .ValidateEagerly();
        }
    }
}
