using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.Data.Repositories;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameOfChores.Data.UnitTests.Repositories.ChoreTypes
{
    public class AddAsyncTests : InMemoryRepositoryTests
    {
        private readonly ChoreTypeRepository repository;

        public AddAsyncTests()
        {
            repository = new ChoreTypeRepository(Context);
        }

        [Theory, ExtendedAutoData]
        public async Task NotExistingChoreType_GivesTrue(ChoreType choreType)
        {
            await Act(choreType);

            await using GameOfChoresContext context = MakeDbContext();
            bool exists = await context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
            exists.Should().BeTrue();
        }

        private async Task Act(ChoreType choreType) => await repository.AddAsync(choreType);
    }
}
