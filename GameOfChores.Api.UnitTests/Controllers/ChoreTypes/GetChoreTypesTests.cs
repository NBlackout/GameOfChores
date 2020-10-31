using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
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
    public class GetChoreTypesTests
    {
        private readonly Mock<IGetChoreTypes> getChoreTypesMock;
        private readonly ChoreTypesController controller;

        public GetChoreTypesTests()
        {
            getChoreTypesMock = new Mock<IGetChoreTypes>();
            var addChoreTypeMock = new Mock<IAddChoreType>();

            controller = new ChoreTypesController(getChoreTypesMock.Object, addChoreTypeMock.Object);
        }

        [Theory, AutoData]
        public async Task Get_ExecutesUseCaseAndGivesResults(Generator<string> stringGenerator)
        {
            IEnumerable<GetChoreTypesResult> expectedResults = stringGenerator.Take(5).Select(l => new GetChoreTypesResult(Guid.NewGuid(), l));
            getChoreTypesMock.Setup(m => m.ExecuteAsync()).ReturnsAsync(expectedResults);

            ActionResult response = await ActAsync();

            response.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(expectedResults);
        }

        private async Task<ActionResult> ActAsync() => await controller.GetChoreTypesAsync();
    }
}
