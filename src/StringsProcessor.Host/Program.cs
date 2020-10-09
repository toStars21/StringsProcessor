using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StringsProcessor.Application.Output;
using StringsProcessor.Application.Processor;
using StringsProcessor.Host.Output;
using StringsProcessor.Host.Settings;

namespace StringsProcessor.Host
{
    class Program
    {
        static async Task Main()
        {
            using var host = BuildHost();

            var processor = host.Services.GetRequiredService<IProcessor>();

            await processor.Process();
        }

        private static IHost BuildHost() =>
            new HostBuilder()
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, collection) =>
                {
                    collection.AddSettings(context.Configuration);
                    collection.AddSingleton<IOutputChannel, ConsoleOutputChannel>();
                    collection.AddTextProcessor();
                })
                .Build();
    }
}
