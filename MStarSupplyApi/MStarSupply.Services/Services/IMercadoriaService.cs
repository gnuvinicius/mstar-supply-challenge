using MStarSupply.Models.Enums;
using MStarSupply.Models.Models;

namespace MStarSupply.Services.Services
{
    public interface IMercadoriaService
    {
        Task<IEnumerable<Mercadoria>> ListaMercadorias();
        Task CadastraMercadoria(Mercadoria mercadoria);
        void RegistraEntradaSaidaMercadoria(EntradaSaida entradaSaida);
        Task CadastraFabricante(Fabricante fabricante);
        Task<IEnumerable<Fabricante>> ListaFabricantes();
        Task<IEnumerable<EntradaSaida>> ListaEntradasSaidaPorMercadoria(Guid mercadoriaId, EntradaSaidaEnum tipo);
        int QuantidadeDisponivelPorMercadoria(Guid mercadoriaId);
        Task<IEnumerable<EntradaSaida>> ListaEntradasSaida();
    }
}
