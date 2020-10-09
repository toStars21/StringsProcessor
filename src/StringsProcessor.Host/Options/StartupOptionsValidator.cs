using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace StringsProcessor.Host.Options
{
    public class StartupOptionsValidator<T> : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                var options = builder.ApplicationServices.GetService(typeof(IOptions<>).MakeGenericType(typeof(T)));

                if (options != null)
                {
                    // .Value will throw exception if validation fails
                    var optionsValue = ((IOptions<object>)options).Value;
                }

                next(builder);
            };
        }
    }

}
