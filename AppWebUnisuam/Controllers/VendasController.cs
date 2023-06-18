using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Data;
using AppWebUnisuam.Models;
using AppWebUnisuam.DTO;
using AppWebUnisuam.Collections;
using AppWebUnisuam.Filters;
using Org.BouncyCastle.Bcpg;

namespace AppWebUnisuam.Controllers
{
    public class VendasController : Controller
    {
        private readonly AppWebUnisuamContext _context;

        public VendasController(AppWebUnisuamContext context)
        {
            _context = context;
        }

        // GET: Vendas
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Index()
        {
              return _context.Vendas != null ? 
                          View(await _context.Vendas.ToListAsync()) :
                          Problem("Entity set 'AppWebUnisuamContext.Vendas'  is null.");
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDaVenda,Produto,Cliente,Quantidade,PrecoUnitario,ValorDaVenda,Desconto,Funcionario,FormaDePagamento,Observacoes")] Vendas vendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendas);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas == null)
            {
                return NotFound();
            }
            return View(vendas);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DataDaVenda,Produto,Cliente,Quantidade,PrecoUnitario,ValorDaVenda,Desconto,Funcionario,FormaDePagamento,Observacoes")] Vendas vendas)
        {
            if (id != vendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasExists(vendas.Id))
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
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendas = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendas == null)
            {
                return NotFound();
            }

            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'AppWebUnisuamContext.Vendas'  is null.");
            }
            var vendas = await _context.Vendas.FindAsync(id);
            if (vendas != null)
            {
                _context.Vendas.Remove(vendas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasExists(string id)
        {
          return (_context.Vendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult MinhasVendas()
        {
            string? userId = Request.Cookies["userid"];

            if (String.IsNullOrEmpty(userId))
            {
                TempData["MensagemErro"] = "Usuário não encontrado";
                return RedirectToAction("Index", "Login");
            }

            var usuario = _context.Cadastro.FirstOrDefault(e => e.Id == userId);

            var vendas = _context.Vendas.Where(e => e.Funcionario == usuario.Nome).ToList();

            return View(vendas);
        }

        public async Task<IActionResult> Vender(string id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(e => e.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            string? userId = Request.Cookies["userid"];

            var vendedor = _context.Cadastro.FirstOrDefault(e => e.Id == userId); 


            var venda = new VendaPOST
            {
                Nome = produto.Nome,
                Preco = Convert.ToDouble(produto.Preco),
                Desconto = 0,
                Quantidade = 1,
                Imagem = produto.Imagem,
                Cliente = "",
                Funcionario = vendedor.Nome.ToString(),
                FormaDePagamento = "",
                Observacoes = "",
                PrecoFinal = 0
            };

            return View(venda);
        }

        [HttpPost]
        [AuthToken(PerfilType.Vendedor)]
        public async Task<IActionResult> Vender(VendaPOST request)
        {
            var venda = new Vendas
            {
                DataDaVenda = DateTime.Now,
                Produto = request.Nome,
                Cliente = request.Cliente,
                Quantidade = request.Quantidade.ToString(),
                PrecoUnitario = request.Preco.ToString(),
                ValorDaVenda = request.PrecoFinal.ToString(),
                Desconto = request.Desconto.ToString(),
                Funcionario = request.Funcionario.ToString(),
                FormaDePagamento = request.FormaDePagamento.ToString(),
                Observacoes = request.Observacoes
            };
            if (venda != null)
            {
                _context.Vendas.Add(venda);
            }

            var produto = _context.Produtos.FirstOrDefault(e => e.Nome == request.Nome);

            produto.Estoque = produto.Estoque - request.Quantidade;

            if (produto.Estoque < 0)
            {
                produto.Disponibilidade = "Indisponível";
            }

            _context.Produtos.Update(produto);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index_Vendedor", "Home");
        }

        [HttpGet]
        public IActionResult NotaFiscal(string id)
        {
            var venda = _context.Vendas.FirstOrDefault(e => e.Id == id);

            var novaNota = new NotaFiscalPOST
            {
                Codigo = venda.Id,
                NomeDoVendedor = venda.Funcionario,
                NomeDoCliente = venda.Cliente,
                NomeDoProduto = venda.Produto,
                Preco = venda.PrecoUnitario,
                Quantidade = venda.Quantidade,
                Desconto = venda.Desconto == null ? "0" : venda.Desconto.ToString(),
                PrecoTotal = venda.ValorDaVenda,
                FormaDePagamento = venda.FormaDePagamento,
                Observacoes = venda.Observacoes == null ? "Não preencheu" : venda.Observacoes.ToString()
            };

            return View(novaNota);
        }
    }
}
