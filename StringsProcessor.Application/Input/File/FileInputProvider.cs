using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StringsProcessor.Application.Settings;

namespace StringsProcessor.Application.Input.File
{
    internal class FileInputProvider : IInputProvider
    {
        private readonly FileInputSettings _settings;

        public FileInputProvider(IOptions<FileInputSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<string> GetAsync()
        {
            using var file = System.IO.File.OpenText(_settings.Path);

            var text = await file.ReadToEndAsync();

            return text;
        }
    }
}
