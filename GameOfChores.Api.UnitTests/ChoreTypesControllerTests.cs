using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using GameOfChores.Application.UseCases.AddChoreType;
using GamesOfChores.Api.Controllers.ChoreTypes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameOfChores.Api.UnitTests
{
    public class ChoreTypesControllerTests
    {
        private readonly Mock<IAddChoreType> addChoreTypeMock;
        private readonly ChoreTypesController controller;

        public ChoreTypesControllerTests()
        {
            addChoreTypeMock = new Mock<IAddChoreType>();

            controller = new ChoreTypesController(addChoreTypeMock.Object);
        }

        [Theory, AutoData]
        public async Task ValidRequestParameter_ExecutesUseCaseAndGivesSuccess(string label)
        {
            var request = new AddChoreTypeRequest { Label = label };

            ActionResult response = await ActAsync(request);

            response.Should().BeOfType<OkResult>();
            addChoreTypeMock.Verify(m => m.ExecuteAsync(It.IsAny<AddChoreTypeParameter>()), Times.Once);
            addChoreTypeMock.Verify(m => m.ExecuteAsync(It.Is<AddChoreTypeParameter>(p => p.Label == label)), Times.Once);
        }

        private async Task<ActionResult> ActAsync(AddChoreTypeRequest request) => await controller.AddChoreTypeAsync(request);
    }
}
