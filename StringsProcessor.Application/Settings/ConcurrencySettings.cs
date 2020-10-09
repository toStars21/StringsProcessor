using System.ComponentModel.DataAnnotations;

namespace StringsProcessor.Application.Settings
{
    public class ConcurrencySettings
    {
        public const string Concurrency = "Concurrency";

        [Range(1, 1000)]
        public int DegreeOfParallelism { get; set; }
    }
}
