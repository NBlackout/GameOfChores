using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Data.Entities;
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

        public void Add(ChoreType choreType)
        {
            var choreTypeEntity = new ChoreTypeEntity { Label = choreType.Label };

            context.ChoreTypes.Add(choreTypeEntity);
        }

        public Task<bool> ExistsAsync(ChoreType choreType) => context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
    }
}
