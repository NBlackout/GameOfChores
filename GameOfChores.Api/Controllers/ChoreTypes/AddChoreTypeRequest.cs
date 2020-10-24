using System.ComponentModel.DataAnnotations;

namespace GameOfChores.Api.Controllers.ChoreTypes
{
    public class AddChoreTypeRequest
    {
        [Required]
        public string Label { get; set; } = null!;
    }
}
