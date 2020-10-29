using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using GameOfChores.Application.UnitTests.Ports.Repositories;
using GameOfChores.Application.UseCases.GetChoreTypes;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Xunit;

namespace GameOfChores.Application.UnitTests.UseCases.ChoreTypes
{
    public class GetChoreTypesTests
    {
        private readonly FakeChoreTypeRepository choreTypeRepository;
        private readonly GetChoreTypes getChoreTypes;

        public GetChoreTypesTests()
        {
            choreTypeRepository = new FakeChoreTypeRepository();
            getChoreTypes = new GetChoreTypes(choreTypeRepository);
        }

        [Fact]
        public async Task NoExistingChoreTypes_GivesNoResult()
        {
            IEnumerable<GetChoreTypesResult> results = await ActAsync();

            results.Should().BeEmpty();
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingChoreTypes_GivesAll(Generator<ChoreType> choreTypeGenerator)
        {
            IEnumerable<ChoreType> choreTypes = choreTypeGenerator.Take(5).ToList();
            foreach (ChoreType choreType in choreTypes)
                await choreTypeRepository.AddAsync(choreType);

            IEnumerable<GetChoreTypesResult> results = await ActAsync();

            IEnumerable<GetChoreTypesResult> expected = choreTypes.Select(ct => new GetChoreTypesResult(ct.Label));
            results.Should().BeEquivalentTo(expected);
        }

        private async Task<IEnumerable<GetChoreTypesResult>> ActAsync() => await getChoreTypes.ExecuteAsync();
    }
}
