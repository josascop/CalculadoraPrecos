using CalculadoraPrecos.Data;
using CalculadoraPrecos.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraPrecos.Services;

public class ProdutoService {
    private readonly CalculadoraPrecosContext _context;

    public ProdutoService(CalculadoraPrecosContext context) {
        _context = context;
    }

    public async Task<List<Produto>> BuscarTodosAsync() {
        return await _context.Produto.ToListAsync();
    }

    public async Task Inserir(Produto p) {
        _context.Add(p);
        await _context.SaveChangesAsync();
    }
}
