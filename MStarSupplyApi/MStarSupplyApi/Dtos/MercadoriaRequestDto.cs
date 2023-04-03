using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApi.Dtos
{
    public class MercadoriaRequestDto
    {
        [Required]
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public int NumeroDeRegistro { get; set; }
        public String FabricanteId { get; set; }
        public String Tipo { get; set; }
    }
}
