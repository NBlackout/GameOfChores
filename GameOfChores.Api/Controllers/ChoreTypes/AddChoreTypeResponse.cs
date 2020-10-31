using System;

namespace GameOfChores.Api.Controllers.ChoreTypes
{
    public class AddChoreTypeResponse
    {
        public Guid Guid { get; }
        public string Label { get; }

        public AddChoreTypeResponse(Guid guid, string label)
        {
            Guid = guid;
            Label = label;
        }
    }
}
