using System;

namespace StringsProcessor.Application.Domain
{
    public class Element
    {
        public string Value { get; }

        public Element(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool TryGetNumber(out double number)
        {
            return double.TryParse(Value, out number);
        }
    }
}
