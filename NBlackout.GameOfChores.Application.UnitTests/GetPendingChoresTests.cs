using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NBlackout.GameOfChores.Application.UseCases.GetPendingChores;
using Xunit;

namespace NBlackout.GameOfChores.Application.UnitTests
{
    public class GetPendingChoresTests
    {
        private readonly GetPendingChoresUseCase instance;

        public GetPendingChoresTests()
        {
            instance = new GetPendingChoresUseCase();
        }

        [Fact]
        public async Task NoExistingChore_GivesNoResultAsync()
        {
            IEnumerable<GetPendingChoresResult> results = await ActAsync();

            results.Should().BeEmpty();
        }

        private Task<IEnumerable<GetPendingChoresResult>> ActAsync() => instance.ExecuteAsync();
    }
}
