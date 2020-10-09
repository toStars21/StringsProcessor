using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StringsProcessor.Application.Domain
{
    public class Line
    {
        private readonly Lazy<double> _sum;
        private readonly Lazy<bool> _corrupted;


        public Line(int index, IReadOnlyCollection<Element> elements)
        {
            if (index < 0) throw new ArgumentException($"{nameof(index)} must be greater or equals 0");

            Index = index;
            Elements = elements ?? throw new ArgumentNullException(nameof(elements));

            _sum = new Lazy<double>(
                () => Elements.Sum(e => e.TryGetNumber(out var number) ? number : 0d),
                LazyThreadSafetyMode.ExecutionAndPublication
            );

            _corrupted = new Lazy<bool>(
                () => Elements.Any(e => !e.TryGetNumber(out _)),
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public int Index { get; }

        public IReadOnlyCollection<Element> Elements { get; }

        public double Sum => _sum.Value;

        public bool Corrupted => _corrupted.Value;
    }
}
