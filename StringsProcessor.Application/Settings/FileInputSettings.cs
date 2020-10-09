using System.ComponentModel.DataAnnotations;

namespace StringsProcessor.Application.Settings
{
    public class FileInputSettings
    {
        public const string FileInput = "FileInput";

        [Required]
        public string Path { get; set; }
    }
}
