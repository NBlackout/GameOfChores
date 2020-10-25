using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfChores.Application.UseCases.AddChoreType;
using GameOfChores.Application.UseCases.GetChoreTypes;
using Microsoft.AspNetCore.Mvc;

namespace GameOfChores.Api.Controllers.ChoreTypes
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoreTypesController : ControllerBase
    {
        private readonly IGetChoreTypes getChoreTypes;
        private readonly IAddChoreType addChoreType;

        public ChoreTypesController(IGetChoreTypes getChoreTypes, IAddChoreType addChoreType)
        {
            this.getChoreTypes = getChoreTypes;
            this.addChoreType = addChoreType;
        }

        [HttpGet]
        public async Task<ActionResult> GetChoreTypesAsync()
        {
            IEnumerable<GetChoreTypesResult> results = await getChoreTypes.ExecuteAsync();

            return Ok(results);
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
