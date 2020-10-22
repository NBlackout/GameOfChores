using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UnitTests.UseCases
{
    public class FakeChoreTypeRepository : IChoreTypeRepository
    {
        private readonly List<ChoreType> choresTypes;

        public FakeChoreTypeRepository()
        {
            choresTypes = new List<ChoreType>();
        }

        public void Add(ChoreType choreType) => choresTypes.Add(choreType);

        public Task<bool> ExistsAsync(string label) => Task.FromResult(choresTypes.Any(c => c.Label == label));

        public Task<IEnumerable<ChoreType>> GetAllAsync() => Task.FromResult(choresTypes.AsEnumerable());
    }
}
