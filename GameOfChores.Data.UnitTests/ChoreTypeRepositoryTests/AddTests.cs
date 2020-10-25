using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.Data.Repositories;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameOfChores.Data.UnitTests.ChoreTypeRepositoryTests
{
    public class AddTests : InMemoryRepositoryTests<ChoreTypeRepository>
    {
        [Theory, ExtendedAutoData]
        public async Task ExistingChoreType_GivesTrue(ChoreType choreType)
        {
            await Act(choreType);

            await using GameOfChoresContext context = MakeDbContext();
            bool exists = await context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
            exists.Should().BeTrue();
        }

        private async Task Act(ChoreType choreType) => await Repository.AddAsync(choreType);
    }
}
