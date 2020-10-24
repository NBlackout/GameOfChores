using System.Threading.Tasks;
using GameOfChores.Application.UseCases.AddChoreType;
using Microsoft.AspNetCore.Mvc;

namespace GamesOfChores.Api.Controllers.ChoreTypes
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoreTypesController : ControllerBase
    {
        private readonly IAddChoreType addChoreType;

        public ChoreTypesController(IAddChoreType addChoreType)
        {
            this.addChoreType = addChoreType;
        }

        [HttpPost]
        public async Task<ActionResult> AddChoreTypeAsync(AddChoreTypeRequest request)
        {
            var parameter = new AddChoreTypeParameter(request.Label);
            await addChoreType.ExecuteAsync(parameter);

            return Ok();
        }
    }
}
