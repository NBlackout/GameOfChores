using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UnitTests.Ports.Repositories
{
    public class FakeChoreTypeRepository : IChoreTypeRepository
    {
        private readonly List<ChoreType> choreTypes;

        public FakeChoreTypeRepository()
        {
            choreTypes = new List<ChoreType>();
        }

        public Task AddAsync(ChoreType choreType)
        {
            choreTypes.Add(choreType);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(ChoreType choreType) => Task.FromResult(choreTypes.Any(c => c.Guid == choreType.Guid || c.Label == choreType.Label));
        public Task<IEnumerable<ChoreType>> GetAsync() => Task.FromResult(choreTypes.AsEnumerable());
    }
}
