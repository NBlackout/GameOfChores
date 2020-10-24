using System.Threading.Tasks;
using GameOfChores.Domain;

namespace GameOfChores.Application.Ports.Repositories
{
    public interface IChoreTypeRepository
    {
        void Add(ChoreType choreType);
        Task<bool> ExistsAsync(ChoreType choreType);
    }
}
