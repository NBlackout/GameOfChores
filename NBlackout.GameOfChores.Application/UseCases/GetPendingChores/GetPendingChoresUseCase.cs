using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBlackout.GameOfChores.Application.UseCases.GetPendingChores
{
    public class GetPendingChoresUseCase
    {
        public Task<IEnumerable<GetPendingChoresResult>> ExecuteAsync() => Task.FromResult(Enumerable.Empty<GetPendingChoresResult>());
    }
}
