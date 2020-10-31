using System;

namespace GameOfChores.Application.UseCases.AddChoreType
{
    public class AddChoreTypeParameter
    {
        public Guid Guid { get; }
        public string Label { get; }

        public AddChoreTypeParameter(string label)
        {
            Guid = Guid.NewGuid();
            Label = label;
        }
    }
}
