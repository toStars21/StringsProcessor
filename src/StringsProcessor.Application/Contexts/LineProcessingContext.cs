﻿using GreenPipes;
using StringsProcessor.Application.Domain;

namespace StringsProcessor.Application.Contexts
{
    internal class LineProcessingContext : BasePipeContext, PipeContext
    {
        public int LineIndex { get; set; }
        public string RawLine { get; set; }
        public Line ProcessedLine { get; set; }
    }
}
