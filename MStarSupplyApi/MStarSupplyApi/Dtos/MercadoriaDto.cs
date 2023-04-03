using System.ComponentModel.DataAnnotations;

namespace MStarSupplyApi.Dtos
{
    public class MercadoriaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public String Descricao { get; set; }
        public int NumeroDeRegistro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public FabricanteDto Fabricante { get; set; }
        public String Tipo { get; set; }
    }
}
