using System;
using System.Collections.Generic;
using MoreLinq;
using StringsProcessor.Application.Domain;
using StringsProcessor.Application.Output;

namespace StringsProcessor.Host.Output
{
    internal class ConsoleOutputChannel : IOutputChannel
    {
        public void Send(IReadOnlyCollection<Line> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));

            foreach (var line in lines)
            {
                Console.WriteLine($"Line {line.Index}: Sum {line.Sum}, Corrupted {line.Corrupted}");
            }

            Console.WriteLine();
            Console.WriteLine();

            var maxs = lines.MaxBy(l => l.Sum);

            foreach (var max in maxs)
            {
                Console.WriteLine($"Max line {max.Index}: Sum {max.Sum}, Corrupted {max.Corrupted}");
            }
        }
    }
}
