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
    public class ImagensController : Controller
    {
        private readonly ContextoDatabase _context;

        public ImagensController(ContextoDatabase context)
        {
            _context = context;
        }

        // GET: Imagens
        public async Task<IActionResult> Index()
        {
            var contextoDatabase = _context.Imagem.Include(i => i.Conteudo);
            return View(await contextoDatabase.ToListAsync());
        }

        // GET: Imagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem
                .Include(i => i.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // GET: Imagens/Create
        public IActionResult Create()
        {
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id");
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConteudoId,EnderecoImagem")] Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", imagem.ConteudoId);
            return View(imagem);
        }

        // GET: Imagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", imagem.ConteudoId);
            return View(imagem);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConteudoId,EnderecoImagem")] Imagem imagem)
        {
            if (id != imagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagemExists(imagem.Id))
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
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", imagem.ConteudoId);
            return View(imagem);
        }

        // GET: Imagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem
                .Include(i => i.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imagem == null)
            {
                return Problem("Entity set 'ContextoDatabase.Imagem'  is null.");
            }
            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem != null)
            {
                _context.Imagem.Remove(imagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemExists(int id)
        {
          return _context.Imagem.Any(e => e.Id == id);
        }
    }
}
