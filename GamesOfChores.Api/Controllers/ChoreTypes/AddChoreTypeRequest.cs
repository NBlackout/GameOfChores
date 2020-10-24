using System.ComponentModel.DataAnnotations;

namespace GamesOfChores.Api.Controllers.ChoreTypes
{
    public class AddChoreTypeRequest
    {
        [Required]
        public string Label { get; set; } = null!;
    }
}
