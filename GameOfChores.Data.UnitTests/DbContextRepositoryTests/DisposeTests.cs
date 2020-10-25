using System;
using FluentAssertions;
using GameOfChores.Data.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;

namespace GameOfChores.Data.UnitTests.DbContextRepositoryTests
{
    public class DisposeTests : InMemoryRepositoryTests<FakeDbRepository>
    {
        [Fact]
        public void EnsureDisposed()
        {
            Repository.Dispose();

            Func<DatabaseFacade> getContextDatabase = () => Repository.Context.Database;
            getContextDatabase.Should().ThrowExactly<ObjectDisposedException>();
        }
    }

    public class FakeDbRepository : DbContextRepository
    {
        public FakeDbRepository(GameOfChoresContext context)
            : base(context)
        {
        }
    }
}
