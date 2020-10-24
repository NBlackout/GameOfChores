using System.Diagnostics.CodeAnalysis;
using GameOfChores.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data
{
    public class GameOfChoresContext : DbContext
    {
        public DbSet<ChoreTypeEntity> ChoreTypes { get; set; } = null!;

        public GameOfChoresContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
