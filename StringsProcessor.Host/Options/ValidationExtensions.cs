using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace StringsProcessor.Host.Options
{
    public static class ValidationExtensions
    {
        public static OptionsBuilder<TOptions> ValidateEagerly<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
        {
            optionsBuilder.Services.AddTransient<IStartupFilter, StartupOptionsValidator<TOptions>>();

            return optionsBuilder;
        }
    }

}
