using System.Threading.Tasks;
using GameOfChores.Application.Exceptions;
using GameOfChores.Application.Ports.Repositories;
using GameOfChores.Domain;

namespace GameOfChores.Application.UseCases.AddChoreType
{
    public class AddChoreType : IAddChoreType
    {
        private readonly IChoreTypeRepository choreTypeRepository;

        public AddChoreType(IChoreTypeRepository choreTypeRepository)
        {
            this.choreTypeRepository = choreTypeRepository;
        }

        public async Task ExecuteAsync(AddChoreTypeParameter parameter)
        {
            var choreType = new ChoreType(parameter.Label);

            bool exists = await choreTypeRepository.ExistsAsync(choreType.Label);
            if (exists)
                throw new ChoreTypeLabelAlreadyExistsException();

            choreTypeRepository.Add(choreType);
        }
    }
}
