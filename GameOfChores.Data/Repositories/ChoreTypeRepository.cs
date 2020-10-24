using System;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.Repositories
{
    public class ChoreTypeRepository : IChoreTypeRepository
    {
        private readonly GameOfChoresContext context;

        public ChoreTypeRepository(GameOfChoresContext context)
        {
            this.context = context;
        }

        public void Add(ChoreType choreType) => throw new NotImplementedException();

        public Task<bool> ExistsAsync(ChoreType choreType) => context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
    }
}
