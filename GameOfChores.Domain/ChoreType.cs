using System;

namespace GameOfChores.Domain
{
    public class ChoreType
    {
        public Guid Guid { get; }
        public string Label { get; }

        public ChoreType(Guid guid, string label)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException("Chore type guid must not be empty");
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentException("Chore type label must not be empty");

            Guid = guid;
            Label = label;
        }
    }
}
