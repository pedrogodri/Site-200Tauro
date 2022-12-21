using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Devs2Blu.ProjetosAula._200Tauro.Web.Models;
using Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Controllers
{
    public class ConteudosController : Controller
    {
        private readonly ContextoDatabase _context;

        public ConteudosController(ContextoDatabase context)
        {
            _context = context;
        }

        // GET: Conteudos
        public async Task<IActionResult> Index()
        {
            var contextoDatabase = _context.Conteudo.Include(c => c.Categoria);
            return View(await contextoDatabase.ToListAsync());
        }

        // GET: Conteudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id");
            return View();
        }

        // POST: Conteudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,CategoriaId,IsPublished,IsDeleted,CreatedDate")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", conteudo.CategoriaId);
            return View(conteudo);
        }

        // GET: Conteudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", conteudo.CategoriaId);
            return View(conteudo);
        }

        // POST: Conteudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,CategoriaId,IsPublished,IsDeleted,CreatedDate")] Conteudo conteudo)
        {
            if (id != conteudo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", conteudo.CategoriaId);
            return View(conteudo);
        }

        // GET: Conteudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // POST: Conteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conteudo == null)
            {
                return Problem("Entity set 'ContextoDatabase.Conteudo'  is null.");
            }
            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo != null)
            {
                _context.Conteudo.Remove(conteudo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExists(int id)
        {
          return _context.Conteudo.Any(e => e.Id == id);
        }
    }
}
