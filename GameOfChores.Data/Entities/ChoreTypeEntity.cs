using System;

namespace GameOfChores.Data.Entities
{
    public class ChoreTypeEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Label { get; set; } = null!;
    }
}
