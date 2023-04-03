using MStarSupply.Models.Enums;
using MStarSupplyApi.Dtos;

namespace MStarSupply.Models.Models
{
    public class EntradaSaidaDto
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public String Local { get; set; }


        public EntradaSaidaEnum Tipo { get; set; }
        public MercadoriaDto Mercadoria { get; set; }
    }
}
