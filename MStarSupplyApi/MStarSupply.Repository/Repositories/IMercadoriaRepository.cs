using MStarSupply.Models.Enums;
using MStarSupply.Models.Models;

namespace MStarSupply.Repository.Repositories
{
    public interface IMercadoriaRepository
    {
        Task CadastraNovaMercadoria(Mercadoria mercadoria);
        Task<IEnumerable<Mercadoria>> ListaMercadorias();
        void RegistraEntradaSaidaMercadoria(EntradaSaida entradaSaida);
        Task<Mercadoria> BuscaMercadoriaPorId(Guid id);
        Task CadastraNovoFabricante(Fabricante fabricante);
        Task<IEnumerable<Fabricante>> ListaFabricantes();
        int TotalDisponivelPorMercadoriaId(Guid id);
        Task<IEnumerable<EntradaSaida>> ListaEntradasSaidaPorMercadoria(Guid mercadoriaId, EntradaSaidaEnum tipo);
        Task<IEnumerable<EntradaSaida>> ListaEntradasSaida();
    }
}
