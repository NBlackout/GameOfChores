using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfChores.Domain;

namespace GameOfChores.Application.Ports.Repositories
{
    public interface IChoreTypeRepository
    {
        Task AddAsync(ChoreType choreType);
        Task<bool> ExistsAsync(ChoreType choreType);
        Task<IEnumerable<ChoreType>> GetAsync();
    }
}
