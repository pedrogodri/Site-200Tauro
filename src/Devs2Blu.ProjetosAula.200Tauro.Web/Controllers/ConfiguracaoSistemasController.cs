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
    public class ConfiguracaoSistemasController : Controller
    {
        private readonly ContextoDatabase _context;

        public ConfiguracaoSistemasController(ContextoDatabase context)
        {
            _context = context;
        }

        // GET: ConfiguracaoSistemas
        public async Task<IActionResult> Index()
        {
              return View(await _context.ConfiguracaoSistema.ToListAsync());
        }

        // GET: ConfiguracaoSistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConfiguracaoSistema == null)
            {
                return NotFound();
            }

            var configuracaoSistema = await _context.ConfiguracaoSistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuracaoSistema == null)
            {
                return NotFound();
            }

            return View(configuracaoSistema);
        }

        // GET: ConfiguracaoSistemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracaoSistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeSite,Contato,Endereco")] ConfiguracaoSistema configuracaoSistema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracaoSistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuracaoSistema);
        }

        // GET: ConfiguracaoSistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConfiguracaoSistema == null)
            {
                return NotFound();
            }

            var configuracaoSistema = await _context.ConfiguracaoSistema.FindAsync(id);
            if (configuracaoSistema == null)
            {
                return NotFound();
            }
            return View(configuracaoSistema);
        }

        // POST: ConfiguracaoSistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeSite,Contato,Endereco")] ConfiguracaoSistema configuracaoSistema)
        {
            if (id != configuracaoSistema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracaoSistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracaoSistemaExists(configuracaoSistema.Id))
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
            return View(configuracaoSistema);
        }

        // GET: ConfiguracaoSistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConfiguracaoSistema == null)
            {
                return NotFound();
            }

            var configuracaoSistema = await _context.ConfiguracaoSistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configuracaoSistema == null)
            {
                return NotFound();
            }

            return View(configuracaoSistema);
        }

        // POST: ConfiguracaoSistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConfiguracaoSistema == null)
            {
                return Problem("Entity set 'ContextoDatabase.ConfiguracaoSistema'  is null.");
            }
            var configuracaoSistema = await _context.ConfiguracaoSistema.FindAsync(id);
            if (configuracaoSistema != null)
            {
                _context.ConfiguracaoSistema.Remove(configuracaoSistema);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracaoSistemaExists(int id)
        {
          return _context.ConfiguracaoSistema.Any(e => e.Id == id);
        }
    }
}
