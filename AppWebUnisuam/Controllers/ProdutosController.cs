using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Data;
using AppWebUnisuam.Models;
using AppWebUnisuam.Collections;
using AppWebUnisuam.Filters;

namespace AppWebUnisuam.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppWebUnisuamContext _context;

        public ProdutosController(AppWebUnisuamContext context)
        {
            _context = context;
        }

        // GET: Produtos
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Index()
        {
              return _context.Produtos != null ? 
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'AppWebUnisuamContext.Produtos'  is null.");
        }

        // GET: Produtos/Details/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var Produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Produtos == null)
            {
                return NotFound();
            }

            return View(Produtos);
        }

        // GET: Produtos/Create
        [AuthToken(PerfilType.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descrição,Preco,Categoria,Marca,Imagem,Disponibilidade,Estoque,AtualizadoEm,CriadoEm")] Produtos Produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Produtos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Produtos);
        }

        // GET: Produtos/Edit/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var Produtos = await _context.Produtos.FindAsync(id);
            if (Produtos == null)
            {
                return NotFound();
            }
            return View(Produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,Descrição,Preco,Categoria,Marca,Imagem,Disponibilidade,Estoque,AtualizadoEm,CriadoEm")] Produtos Produtos)
        {
            if (id != Produtos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Produtos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(Produtos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Produtos);
        }

        // GET: Produtos/Delete/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var Produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Produtos == null)
            {
                return NotFound();
            }

            return View(Produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'AppWebUnisuamContext.Produtos'  is null.");
            }
            var Produtos = await _context.Produtos.FindAsync(id);
            if (Produtos != null)
            {
                _context.Produtos.Remove(Produtos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosExists(string id)
        {
          return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
