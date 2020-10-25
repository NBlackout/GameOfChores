using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GameOfChores.Data.UnitTests.DbContextRepositoryTests
{
    public class DisposeTests
    {
        private readonly FakeDbRepository repository;
        private readonly Mock<GameOfChoresContext> contextMock;

        public DisposeTests()
        {
            var databaseName = Guid.NewGuid().ToString();
            DbContextOptions<GameOfChoresContext> options = new DbContextOptionsBuilder<GameOfChoresContext>().UseInMemoryDatabase(databaseName).Options;

            contextMock = new Mock<GameOfChoresContext>(options);
            repository = new FakeDbRepository(contextMock.Object);
        }

        [Fact]
        public void ManagedResources_AreDisposed()
        {
            Act();

            contextMock.Verify(m => m.Dispose(), Times.Once);
        }

        private void Act() => repository.Dispose();
    }
}
