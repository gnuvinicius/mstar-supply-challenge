using MStarSupply.Models.Enums;
using MStarSupply.Models.Models;
using MStarSupply.Repository.Repositories;

namespace MStarSupply.Services.Services
{
    public class MercadoriaService : IMercadoriaService
    {
        private readonly IMercadoriaRepository _repository;

        public MercadoriaService(IMercadoriaRepository mercadoriaRepository)
        {
            _repository = mercadoriaRepository;
        }
        public async Task<IEnumerable<Mercadoria>> ListaMercadorias()
        {
            return await _repository.ListaMercadorias();
        }

        public async Task CadastraMercadoria(Mercadoria mercadoria)
        {
            mercadoria.Id = Guid.NewGuid();
            mercadoria.FabricanteId = mercadoria.FabricanteId;
            await _repository.CadastraNovaMercadoria(mercadoria);
        }

        public void RegistraEntradaSaidaMercadoria(EntradaSaida entradaSaida)
        {
            var mercadoria = _repository.BuscaMercadoriaPorId(entradaSaida.MercadoriaId).Result;

            entradaSaida.MercadoriaId = mercadoria.Id;

            if (entradaSaida.Tipo == EntradaSaidaEnum.Saida)
            {
                int totalDisponivel = _repository.TotalDisponivelPorMercadoriaId(mercadoria.Id);
                if (totalDisponivel < entradaSaida.Quantidade)
                    throw new Exception("error!!");
            }

            _repository.RegistraEntradaSaidaMercadoria(entradaSaida);
        }

        public async Task CadastraFabricante(Fabricante fabricante)
        {
            await _repository.CadastraNovoFabricante(fabricante);
        }

        public async Task<IEnumerable<Fabricante>> ListaFabricantes()
        {
            return await _repository.ListaFabricantes();
        }

        public async Task<IEnumerable<EntradaSaida>> ListaEntradasSaidaPorMercadoria(Guid mercadoriaId, EntradaSaidaEnum tipo)
        {
            return await _repository.ListaEntradasSaidaPorMercadoria(mercadoriaId, tipo);
        }

        public int QuantidadeDisponivelPorMercadoria(Guid mercadoriaId)
        {
           return _repository.TotalDisponivelPorMercadoriaId(mercadoriaId);
        }

        public async Task<IEnumerable<EntradaSaida>> ListaEntradasSaida()
        {
            return await _repository.ListaEntradasSaida();
        }
    }
}
