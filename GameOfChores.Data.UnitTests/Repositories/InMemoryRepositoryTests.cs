using System;
using GameOfChores.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.UnitTests.Repositories
{
    public abstract class InMemoryRepositoryTests<T> where T : DbContextRepository
    {
        private readonly DbContextOptions<GameOfChoresContext> options;
        protected readonly T Repository;

        protected InMemoryRepositoryTests()
        {
            var databaseName = Guid.NewGuid().ToString();
            options = new DbContextOptionsBuilder<GameOfChoresContext>().UseInMemoryDatabase(databaseName).Options;

            Repository = (T)Activator.CreateInstance(typeof(T), MakeDbContext())!;
        }

        protected GameOfChoresContext MakeDbContext() => new GameOfChoresContext(options);
    }
}
