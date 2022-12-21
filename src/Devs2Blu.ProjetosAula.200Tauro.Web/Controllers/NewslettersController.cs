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
    public class NewslettersController : Controller
    {
        private readonly ContextoDatabase _context;

        public NewslettersController(ContextoDatabase context)
        {
            _context = context;
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
              return View(await _context.Newsletter.ToListAsync());
        }

        // GET: Newsletters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Newsletter == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // GET: Newsletters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Ativo")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsletter);
        }

        // GET: Newsletters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Newsletter == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter.FindAsync(id);
            if (newsletter == null)
            {
                return NotFound();
            }
            return View(newsletter);
        }

        // POST: Newsletters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Ativo")] Newsletter newsletter)
        {
            if (id != newsletter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterExists(newsletter.Id))
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
            return View(newsletter);
        }

        // GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Newsletter == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Newsletter == null)
            {
                return Problem("Entity set 'ContextoDatabase.Newsletter'  is null.");
            }
            var newsletter = await _context.Newsletter.FindAsync(id);
            if (newsletter != null)
            {
                _context.Newsletter.Remove(newsletter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsletterExists(int id)
        {
          return _context.Newsletter.Any(e => e.Id == id);
        }
    }
}
