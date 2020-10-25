using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameOfChores.Data.UnitTests.ChoreTypeRepository
{
    public class AddTests
    {
        private readonly GameOfChoresContext context;
        private readonly Repositories.ChoreTypeRepository repository;

        public AddTests()
        {
            context = InMemoryDbContextFactory.MakeDbContext();
            repository = new Data.Repositories.ChoreTypeRepository(context);
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingChoreType_GivesTrue(Domain.ChoreType choreType)
        {
            Act(choreType);
            await context.SaveChangesAsync();

            bool exists = await context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
            exists.Should().BeTrue();
        }

        private void Act(Domain.ChoreType choreType) => repository.Add(choreType);
    }
}
