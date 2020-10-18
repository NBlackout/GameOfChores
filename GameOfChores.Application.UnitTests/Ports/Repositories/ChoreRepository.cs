using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UnitTests.Ports.Repositories
{
    public class ChoreRepository : IChoreRepository
    {
        private readonly List<Chore> chores;

        public ChoreRepository()
        {
            chores = new List<Chore>();
        }

        public void Add(Chore chore) => chores.Add(chore);

        public Task<IEnumerable<Chore>> GetAsync() => Task.FromResult(chores.AsEnumerable());
    }
}
