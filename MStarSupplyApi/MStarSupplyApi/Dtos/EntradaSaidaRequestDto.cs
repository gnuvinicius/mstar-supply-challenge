using MStarSupply.Models.Enums;

namespace MStarSupply.Models.Models
{
    public class EntradaSaidaRequestDto
    {
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public String Local { get; set; }
        public EntradaSaidaEnum Tipo { get; set; }
        public String MercadoriaId { get; set; }
    }
}
