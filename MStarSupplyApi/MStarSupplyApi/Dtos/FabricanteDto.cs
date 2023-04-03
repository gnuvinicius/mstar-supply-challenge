using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApi.Dtos
{
    public class FabricanteDto
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public String Nome { get; set; }
    }
}
