using System.Collections.Generic;
using GreenPipes;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Contexts
{
    internal class TextProcessingContext : BasePipeContext, PipeContext
    {
        public List<Line> ProcessedLines { get; set; } = new List<Line>();

        public string SourceText { get; set; } = string.Empty;

        public string[] RawLines { get; set; }
    }
}
