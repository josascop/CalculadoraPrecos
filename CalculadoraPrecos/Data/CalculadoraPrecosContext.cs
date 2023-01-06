using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalculadoraPrecos.Models;

namespace CalculadoraPrecos.Data
{
    public class CalculadoraPrecosContext : DbContext
    {
        public CalculadoraPrecosContext (DbContextOptions<CalculadoraPrecosContext> options)
            : base(options)
        {
        }

        public DbSet<CalculadoraPrecos.Models.Produto> Produto { get; set; } = default!;
    }
}
