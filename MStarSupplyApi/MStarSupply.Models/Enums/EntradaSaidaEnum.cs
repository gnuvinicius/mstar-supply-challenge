using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MStarSupply.Models.Enums
{
    public enum EntradaSaidaEnum
    {
        [EnumMember(Value = "Entrada")]
        Entrada = 0,

        [EnumMember(Value = "Saída")]
        Saida = 1
    }
}
