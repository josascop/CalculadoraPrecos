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

    public async Task<Produto?> BuscarPorIdAsync(int id) {
        return await _context.Produto.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Atualizar(Produto produto) {
        if (!await _context.Produto.AnyAsync(p => p.Id == produto.Id))
            throw new DbUpdateConcurrencyException("Id não encontrado");

        try {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e) { throw e; }
    }
}
