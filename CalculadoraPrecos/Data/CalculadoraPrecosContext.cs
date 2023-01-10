using CalculadoraPrecos.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraPrecos.Data {
    public class CalculadoraPrecosContext : DbContext {
        public CalculadoraPrecosContext(DbContextOptions<CalculadoraPrecosContext> options)
            : base(options) {
        }

        public DbSet<Models.Produto> Produto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.Entity<Produto>().HasIndex(p => p.Nome).IsUnique();
        }
    }
}
