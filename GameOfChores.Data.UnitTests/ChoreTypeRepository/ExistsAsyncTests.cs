using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.Data.Entities;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Xunit;

namespace GameOfChores.Data.UnitTests.ChoreTypeRepository
{
    public class ExistsAsyncTests
    {
        private readonly GameOfChoresContext context;
        private readonly Repositories.ChoreTypeRepository repository;

        public ExistsAsyncTests()
        {
            context = InMemoryDbContextFactory.MakeDbContext();
            repository = new Repositories.ChoreTypeRepository(context);
        }

        [Theory, ExtendedAutoData]
        public async Task NotExistingChoreType_GivesFalse(ChoreType choreType)
        {
            bool exists = await ActAsync(choreType);

            exists.Should().BeFalse();
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingChoreType_GivesTrue(ChoreType choreType)
        {
            await context.ChoreTypes.AddAsync(new ChoreTypeEntity { Id = 1, Label = choreType.Label });
            await context.SaveChangesAsync();

            bool exists = await repository.ExistsAsync(choreType);

            exists.Should().BeTrue();
        }

        private async Task<bool> ActAsync(ChoreType choreType) => await repository.ExistsAsync(choreType);
    }
}
