using System;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.UnitTests
{
    public static class InMemoryDbContextFactory
    {
        public static GameOfChoresContext MakeDbContext() => new GameOfChoresContext(MakeDbContextOptions());

        public static DbContextOptions<GameOfChoresContext> MakeDbContextOptions() =>
            new DbContextOptionsBuilder<GameOfChoresContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
    }
}
