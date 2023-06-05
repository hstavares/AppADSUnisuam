﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Data;
using AppWebUnisuam.Models;
using AppWebUnisuam.Services;
using AppWebUnisuam.Collections;
using AppWebUnisuam.Filters;

namespace AppWebUnisuam.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppWebUnisuamContext _context;

        public CadastroController(AppWebUnisuamContext context)
        {
            _context = context;
        }

        // GET: Cadastroes
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Index()
        {
              return _context.Cadastro != null ? 
                          View(await _context.Cadastro.ToListAsync()) :
                          Problem("Entity set 'AppWebUnisuamContext.Cadastro'  is null.");
        }

        // GET: Cadastroes/Details/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cadastro cadastro)
        {

            cadastro.Senha = CriptografiaService.EncriptaPassword(cadastro.Senha);
            cadastro.Perfil = cadastro.Perfil == "Administrador" ? PerfilType.Admin.ToString() : PerfilType.Vendedor.ToString();

            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            cadastro.Senha = "";
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                cadastro.Senha = CriptografiaService.EncriptaPassword(cadastro.Senha);
                try
                {
                    _context.Cadastro.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Id))
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
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        [AuthToken(PerfilType.Admin)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cadastro == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthToken(PerfilType.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cadastro == null)
            {
                return Problem("Entity set 'AppWebUnisuamContext.Cadastro'  is null.");
            }
            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastro.Remove(cadastro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(string id)
        {
          return (_context.Cadastro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
