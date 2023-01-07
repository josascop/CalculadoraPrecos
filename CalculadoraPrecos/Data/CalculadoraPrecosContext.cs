using Microsoft.EntityFrameworkCore;

namespace CalculadoraPrecos.Data {
    public class CalculadoraPrecosContext : DbContext {
        public CalculadoraPrecosContext(DbContextOptions<CalculadoraPrecosContext> options)
            : base(options) {
        }

        public DbSet<Models.Produto> Produto { get; set; } = default!;
    }
}
