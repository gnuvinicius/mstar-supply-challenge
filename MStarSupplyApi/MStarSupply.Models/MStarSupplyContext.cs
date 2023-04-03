using Microsoft.EntityFrameworkCore;
using MStarSupply.Models.Models;

namespace MStarSupply.Repository
{
    public class MStarSupplyContext : DbContext
    {
        public DbSet<Mercadoria> Mercadorias => Set<Mercadoria>();
        public DbSet<Fabricante> Fabricantes => Set<Fabricante>();
        public DbSet<EntradaSaida> EntradaSaidas => Set<EntradaSaida>();

        public MStarSupplyContext(DbContextOptions<MStarSupplyContext> options) : base(options) { }
    }
}
