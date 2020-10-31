using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.Application.Exceptions;
using GameOfChores.Application.UnitTests.Ports.Repositories;
using GameOfChores.Application.UseCases.AddChoreType;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Xunit;

namespace GameOfChores.Application.UnitTests.UseCases.ChoreTypes
{
    public class AddChoreTypeTests
    {
        private readonly FakeChoreTypeRepository choreTypeRepository;
        private readonly AddChoreType addChoreType;

        public AddChoreTypeTests()
        {
            choreTypeRepository = new FakeChoreTypeRepository();
            addChoreType = new AddChoreType(choreTypeRepository);
        }

        [Theory, ExtendedAutoData]
        public async Task AlreadyExistingLabel_GivesError(ChoreType choreType)
        {
            await choreTypeRepository.AddAsync(choreType);
            var parameter = new AddChoreTypeParameter(choreType.Label);

            await Assert.ThrowsAsync<ChoreTypeAlreadyExistsException>(() => ActAsync(parameter));
        }

        [Theory, ExtendedAutoData]
        public async Task NotAlreadyExistingChoreType_AddsChoreType(string label)
        {
            var parameter = new AddChoreTypeParameter(label);

            await ActAsync(parameter);

            bool exists = await choreTypeRepository.ExistsAsync(new ChoreType(parameter.Guid, label));
            exists.Should().BeTrue();
        }

        private async Task ActAsync(AddChoreTypeParameter parameter) => await addChoreType.ExecuteAsync(parameter);
    }
}
