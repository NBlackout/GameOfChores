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
            Act(choreType);

            bool exists = await MakeDbContext().ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
            exists.Should().BeTrue();
        }

        private void Act(ChoreType choreType) => Repository.AddAsync(choreType);
    }
}
