using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Campeonato.Models;

namespace Campeonato.Controllers
{
    public class FasesController : Controller
    {
        private readonly CampeonatoContext _context;

        public FasesController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Fases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fases.ToListAsync());
        }

        // GET: Fases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await _context.Fases
                .FirstOrDefaultAsync(m => m.IdFase == id);
            if (fase == null)
            {
                return NotFound();
            }

            return View(fase);
        }

        // GET: Fases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFase,Descricao")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fase);
        }

        // GET: Fases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await _context.Fases.FindAsync(id);
            if (fase == null)
            {
                return NotFound();
            }
            return View(fase);
        }

        // POST: Fases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFase,Descricao")] Fase fase)
        {
            if (id != fase.IdFase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaseExists(fase.IdFase))
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
            return View(fase);
        }

        // GET: Fases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fase = await _context.Fases
                .FirstOrDefaultAsync(m => m.IdFase == id);
            if (fase == null)
            {
                return NotFound();
            }

            return View(fase);
        }

        // POST: Fases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fase = await _context.Fases.FindAsync(id);
            if (fase != null)
            {
                _context.Fases.Remove(fase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaseExists(int id)
        {
            return _context.Fases.Any(e => e.IdFase == id);
        }
    }
}
