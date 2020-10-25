using System;

namespace GameOfChores.Domain
{
    public class ChoreType
    {
        public string Label { get; }

        public ChoreType(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentException("Label should not be empty");

            Label = label;
        }
    }
}
