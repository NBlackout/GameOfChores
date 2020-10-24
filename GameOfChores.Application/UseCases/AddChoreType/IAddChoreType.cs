using System.Threading.Tasks;

namespace GameOfChores.Application.UseCases.AddChoreType
{
    public interface IAddChoreType
    {
        Task ExecuteAsync(AddChoreTypeParameter parameter);
    }
}
