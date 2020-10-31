using System.Collections.Generic;
using System.Linq;
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
            var choreTypeEntity = new ChoreTypeEntity { Guid = choreType.Guid, Label = choreType.Label };

            await Context.ChoreTypes.AddAsync(choreTypeEntity);
            await Context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(ChoreType choreType)
        {
            return Context.ChoreTypes.AnyAsync(ct =>
                ct.Guid.ToString().ToUpperInvariant() == choreType.Guid.ToString().ToUpperInvariant()
                || ct.Label.ToUpperInvariant() == choreType.Label.ToUpperInvariant()
            );
        }

        public async Task<IEnumerable<ChoreType>> GetAsync() => await Context.ChoreTypes.Select(ct => new ChoreType(ct.Guid, ct.Label)).ToListAsync();
    }
}
