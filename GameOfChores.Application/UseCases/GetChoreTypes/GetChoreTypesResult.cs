using System;

namespace GameOfChores.Application.UseCases.GetChoreTypes
{
    public class GetChoreTypesResult
    {
        public Guid Guid { get; }
        public string Label { get; }

        public GetChoreTypesResult(Guid guid, string label)
        {
            Guid = guid;
            Label = label;
        }
    }
}
