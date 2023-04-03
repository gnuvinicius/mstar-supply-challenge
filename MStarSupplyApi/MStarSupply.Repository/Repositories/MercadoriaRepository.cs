using Microsoft.EntityFrameworkCore;
using MStarSupply.Models.Enums;
using MStarSupply.Models.Models;

namespace MStarSupply.Repository.Repositories
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private MStarSupplyContext _context;

        public MercadoriaRepository(MStarSupplyContext context)
        {
            _context = context;
        }

        public async Task<Mercadoria> BuscaMercadoriaPorId(Guid id)
        {
            return await _context.Mercadorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CadastraNovaMercadoria(Mercadoria mercadoria)
        {
            _context.Mercadorias.Add(mercadoria);
            await _context.SaveChangesAsync();
        }

        public async Task CadastraNovoFabricante(Fabricante fabricante)
        {
            _context.Fabricantes.Add(fabricante);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EntradaSaida>> ListaEntradasSaida()
        {
            return await _context.EntradaSaidas
                .AsNoTracking()
                .Include(e => e.Mercadoria)
                .ThenInclude(x => x.Fabricante)
                .OrderByDescending(x => x.DataHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<EntradaSaida>> ListaEntradasSaidaPorMercadoria(Guid mercadoriaId, EntradaSaidaEnum tipo)
        {
            return await _context.EntradaSaidas
                .AsNoTracking()
                .Include(e => e.Mercadoria)
                .ThenInclude(x => x.Fabricante)
                .Where(x => x.MercadoriaId == mercadoriaId && x.Tipo == tipo)
                .OrderByDescending(x => x.DataHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Fabricante>> ListaFabricantes()
        {
            return await _context.Fabricantes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Mercadoria>> ListaMercadorias()
        {
            return await _context.Mercadorias
                .AsNoTracking()
                .Include(m => m.Fabricante)
                .ToListAsync();
        }

        public void RegistraEntradaSaidaMercadoria(EntradaSaida entradaSaida)
        {
            _context.EntradaSaidas.Add(entradaSaida);
            _context.SaveChanges();
        }

        public int TotalDisponivelPorMercadoriaId(Guid id)
        {
            return TotalEntrada(id) - TotalSaida(id);
        }

        private int TotalEntrada(Guid id)
        {
            return _context.EntradaSaidas
                            .Where(e => e.MercadoriaId == id && e.Tipo == EntradaSaidaEnum.Entrada)
                            .Select(e => e.Quantidade)
                            .ToList()
                            .Aggregate(0, (acc, x) => acc + x);
        }

        private int TotalSaida(Guid id)
        {
            return _context.EntradaSaidas
                            .Where(e => e.MercadoriaId == id && e.Tipo == EntradaSaidaEnum.Saida)
                            .Select(e => e.Quantidade)
                            .ToList()
                            .Aggregate(0, (acc, x) => acc + x);
        }
    }
}
