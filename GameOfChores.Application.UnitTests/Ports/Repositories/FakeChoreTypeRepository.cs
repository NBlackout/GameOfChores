using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UnitTests.Ports.Repositories
{
    public class FakeChoreTypeRepository : IChoreTypeRepository
    {
        private readonly List<ChoreType> choresTypes;

        public FakeChoreTypeRepository()
        {
            choresTypes = new List<ChoreType>();
        }

        public Task AddAsync(ChoreType choreType)
        {
            choresTypes.Add(choreType);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(ChoreType choreType) => Task.FromResult(choresTypes.Any(c => c.Label == choreType.Label));
        public Task<IEnumerable<ChoreType>> GetAsync() => Task.FromResult(choresTypes.AsEnumerable());
    }
}
