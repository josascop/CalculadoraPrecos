using Microsoft.AspNetCore.Mvc;
using CalculadoraPrecos.Services;
using CalculadoraPrecos.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraPrecos.Controllers;
public class ProdutosController : Controller {
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService ps) {
        _produtoService = ps;
    }

    // GET: Produtos
    public async Task<IActionResult> Index() {
        var res = await _produtoService.BuscarTodosAsync();

        if (res.Count == 0) ViewData["Msg"] = "Você ainda não adicionou produtos ao sistema";

        return View(res);
    }

    // GET: Produtos/Create
    public async Task<IActionResult> CreateAsync() {
        return View(new Produto());
    }

    // POST: Produtos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(Produto produto) {
        if (!ModelState.IsValid) return View(produto);

        await _produtoService.Inserir(produto);
        return RedirectToAction(nameof(Index));
    }

    //// GET: Produtos/Details/5
    //public async Task<IActionResult> Details(int? id) {
    //    if (id == null || _context.Produto == null) {
    //        return NotFound();
    //    }

    //    var produto = await _context.Produto
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (produto == null) {
    //        return NotFound();
    //    }

    //    return View(produto);
    //}





    //// GET: Produtos/Edit/5
    //public async Task<IActionResult> Edit(int? id) {
    //    if (id == null || _context.Produto == null) {
    //        return NotFound();
    //    }

    //    var produto = await _context.Produto.FindAsync(id);
    //    if (produto == null) {
    //        return NotFound();
    //    }
    //    return View(produto);
    //}

    //// POST: Produtos/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,PrecoUnitario,EmEstoque,Tipo,CriadoEm,UltimaAtualizacao")] Produto produto) {
    //    if (id != produto.Id) {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid) {
    //        try {
    //            _context.Update(produto);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException) {
    //            if (!ProdutoExists(produto.Id)) {
    //                return NotFound();
    //            } else {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(produto);
    //}

    //// GET: Produtos/Delete/5
    //public async Task<IActionResult> Delete(int? id) {
    //    if (id == null || _context.Produto == null) {
    //        return NotFound();
    //    }

    //    var produto = await _context.Produto
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (produto == null) {
    //        return NotFound();
    //    }

    //    return View(produto);
    //}

    //// POST: Produtos/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id) {
    //    if (_context.Produto == null) {
    //        return Problem("Entity set 'CalculadoraPrecosContext.Produto'  is null.");
    //    }
    //    var produto = await _context.Produto.FindAsync(id);
    //    if (produto != null) {
    //        _context.Produto.Remove(produto);
    //    }

    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool ProdutoExists(int id) {
    //    return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
    //}
}

