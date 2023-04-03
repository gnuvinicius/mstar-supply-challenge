using System.ComponentModel.DataAnnotations.Schema;

namespace MStarSupply.Models.Models
{

    [Table("tb_mercadorias")]
    public class Mercadoria : Entity
    {
        [Column("nome")]
        public String Nome { get; set; }

        [Column("descricao")]
        public String Descricao { get; set; }

        [Column("numero_de_registro")]
        public int NumeroDeRegistro { get; set; }

        [Column("tipo")]
        public String Tipo { get; set; }

        [Column("fabricante_id")]
        public Guid FabricanteId { get; set; }

        public Fabricante Fabricante { get; set; }
    }
}
