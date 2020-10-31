using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using GameOfChores.Api.Controllers.ChoreTypes;
using GameOfChores.Application.UseCases.AddChoreType;
using GameOfChores.Application.UseCases.GetChoreTypes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameOfChores.Api.UnitTests.Controllers.ChoreTypes
{
    public class AddChoreTypeTests
    {
        private readonly Mock<IAddChoreType> addChoreTypeMock;
        private readonly ChoreTypesController controller;

        public AddChoreTypeTests()
        {
            var getChoreTypesMock = new Mock<IGetChoreTypes>();
            addChoreTypeMock = new Mock<IAddChoreType>();

            controller = new ChoreTypesController(getChoreTypesMock.Object, addChoreTypeMock.Object);
        }

        [Theory, AutoData]
        public async Task ValidRequestParameter_ExecutesUseCaseAndGivesSuccess(string label)
        {
            AddChoreTypeParameter parameter = null;
            addChoreTypeMock.Setup(m => m.ExecuteAsync(It.IsAny<AddChoreTypeParameter>()))
                .Callback<AddChoreTypeParameter>(p => parameter = p);

            var request = new AddChoreTypeRequest { Label = label };
            ActionResult result = await ActAsync(request);

            var response = new AddChoreTypeResponse(parameter.Guid, parameter.Label);
            var expected = new CreatedResult($"api/ChoreTypes/{parameter.Guid}", response);
            parameter.Label.Should().Be(label);
            result.Should().BeEquivalentTo(expected);

        }

        private async Task<ActionResult> ActAsync(AddChoreTypeRequest request) => await controller.AddChoreTypeAsync(request);
    }
}
