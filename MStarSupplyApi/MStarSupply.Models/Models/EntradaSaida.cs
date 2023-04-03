using MStarSupply.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MStarSupply.Models.Models
{
    [Table("tb_entradas_saidas")]
    public class EntradaSaida : Entity
    {
        [Column("quantidade")]
        public int Quantidade { get; set; }
        
        [Column("data_hora")]
        public DateTime DataHora { get; set; }

        [Column("local")]
        public String Local { get; set; }

        [Column("tipo")]
        public EntradaSaidaEnum Tipo { get; set; }

        [Column("mercadoria_id")]
        public Guid MercadoriaId { get; set; }
        
        public Mercadoria Mercadoria { get; set; }
    }
}
