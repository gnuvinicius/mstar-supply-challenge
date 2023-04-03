using System.ComponentModel.DataAnnotations.Schema;

namespace MStarSupply.Models.Models
{
    [Table("tb_fabricantes")]
    public class Fabricante : Entity
    {
        [Column("nome")]
        public String Nome { get; set; }

        public IEnumerable<Mercadoria> Mercadorias { get; set; }
    }
}
