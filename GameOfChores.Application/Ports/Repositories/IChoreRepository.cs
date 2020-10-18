using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfChores.Domain;

namespace GameOfChores.Application.Ports.Repositories
{
    public interface IChoreRepository
    {
        Task<IEnumerable<Chore>> GetAsync();
    }
}
