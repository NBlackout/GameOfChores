using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Data.Entities;
using GameOfChores.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameOfChores.Data.Repositories
{
    public class ChoreTypeRepository : DbContextRepository, IChoreTypeRepository
    {
        public ChoreTypeRepository(GameOfChoresContext context)
            : base(context)
        {
        }

        public async Task AddAsync(ChoreType choreType)
        {
            var choreTypeEntity = new ChoreTypeEntity { Label = choreType.Label };

            await Context.ChoreTypes.AddAsync(choreTypeEntity);
            await Context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(ChoreType choreType) => Context.ChoreTypes.AnyAsync(ct => ct.Label == choreType.Label);
    }
}
