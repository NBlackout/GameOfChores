using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using GameOfChores.Application.UnitTests.Ports.Repositories;
using GameOfChores.Application.UseCases.GetPendingChores;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Xunit;

namespace GameOfChores.Application.UnitTests.UseCases
{
    public class GetPendingChoresTests
    {
        private readonly ChoreRepository choreRepository;
        private readonly GetPendingChoresUseCase useCase;

        public GetPendingChoresTests()
        {
            choreRepository = new ChoreRepository();
            useCase = new GetPendingChoresUseCase(choreRepository);
        }

        [Fact]
        public async Task NoExistingChore_GivesNoResultAsync()
        {
            IEnumerable<GetPendingChoresResult> results = await ActAsync();

            results.Should().BeEmpty();
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingChores_GivesNotAlreadyCompletedChores(Generator<Chore> choreGenerator)
        {
            List<Chore> chores = choreGenerator.Take(5).ToList();
            chores.ForEach(choreRepository.Add);

            IEnumerable<GetPendingChoresResult> results = await ActAsync();

            IEnumerable<GetPendingChoresResult> expectedChores = chores.Select(c => new GetPendingChoresResult { Label = c.Label });
            results.Should().BeEquivalentTo(expectedChores);
        }

        private Task<IEnumerable<GetPendingChoresResult>> ActAsync() => useCase.ExecuteAsync();
    }
}
