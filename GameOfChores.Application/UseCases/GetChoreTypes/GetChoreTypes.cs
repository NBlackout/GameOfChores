using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UseCases.GetChoreTypes
{
    public class GetChoreTypes : IGetChoreTypes
    {
        private readonly IChoreTypeRepository choreTypeRepository;

        public GetChoreTypes(IChoreTypeRepository choreTypeRepository)
        {
            this.choreTypeRepository = choreTypeRepository;
        }

        public async Task<IEnumerable<GetChoreTypesResult>> ExecuteAsync()
        {
            IEnumerable<ChoreType> choreTypes = await choreTypeRepository.GetAsync();

            return choreTypes.Select(ct => new GetChoreTypesResult(ct.Label));
        }
    }
}
