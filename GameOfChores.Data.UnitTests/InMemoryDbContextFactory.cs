using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.UnitTests
{
    public static class InMemoryDbContextFactory
    {
        public static GameOfChoresContext MakeDbContext() => new GameOfChoresContext(MakeDbContextOptions());
        //public static GameOfChoresContext MakeDbContext(DbContextOptions<GameOfChoresContext>? options = null) => new GameOfChoresContext(options ?? MakeDbContextOptions());

        public static DbContextOptions<GameOfChoresContext> MakeDbContextOptions() =>
            new DbContextOptionsBuilder<GameOfChoresContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
    }
}
