using System;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.UnitTests.Repositories
{
    public abstract class InMemoryRepositoryTests
    {
        private readonly DbContextOptions<GameOfChoresContext> options;

        protected GameOfChoresContext Context { get; }

        protected InMemoryRepositoryTests()
        {
            var databaseName = Guid.NewGuid().ToString();
            options = new DbContextOptionsBuilder<GameOfChoresContext>().UseInMemoryDatabase(databaseName).Options;
            Context = new GameOfChoresContext(options);
        }

        protected GameOfChoresContext MakeDbContext() => new GameOfChoresContext(options);
    }
}
