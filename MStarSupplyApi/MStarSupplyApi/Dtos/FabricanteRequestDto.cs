using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApi.Dtos
{
    public class FabricanteRequestDto
    {
        
        [Required]
        public String Nome { get; set; }
    }
}
