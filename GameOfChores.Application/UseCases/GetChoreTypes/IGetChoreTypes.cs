using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOfChores.Application.UseCases.GetChoreTypes
{
    public interface IGetChoreTypes
    {
        Task<IEnumerable<GetChoreTypesResult>> ExecuteAsync();
    }
}
