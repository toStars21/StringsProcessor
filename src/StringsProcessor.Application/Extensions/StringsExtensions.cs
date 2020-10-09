using System;

namespace StringsProcessor.Application.Extensions
{
    public static class StringsExtensions
    {
        public static string[] SplitByEOL(this string source) => source.Split(Environment.NewLine);
    }
}
