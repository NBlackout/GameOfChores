using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UseCases.GetPendingChores
{
    public class GetPendingChoresUseCase
    {
        private readonly IChoreRepository choreRepository;

        public GetPendingChoresUseCase(IChoreRepository choreRepository)
        {
            this.choreRepository = choreRepository;
        }

        public async Task<IEnumerable<GetPendingChoresResult>> ExecuteAsync()
        {
            IEnumerable<Chore> chores = await choreRepository.GetAsync();

            return chores.Select(c => new GetPendingChoresResult { Label = c.Label });
        }
    }
}
