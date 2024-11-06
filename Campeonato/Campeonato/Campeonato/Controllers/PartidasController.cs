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
    public class PartidasController : Controller
    {
        private readonly CampeonatoContext _context;

        public PartidasController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Partida.Include(p => p.IdEquipe1Navigation).Include(p => p.IdEquipe2Navigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .Include(p => p.IdEquipe1Navigation)
                .Include(p => p.IdEquipe2Navigation)
                .FirstOrDefaultAsync(m => m.IdPartida == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            ViewData["IdEquipe1"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe");
            ViewData["IdEquipe2"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe");
            return View();
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPartida,DataPartida,PlacarEquipe1,PlacarEquipe2,IdEquipe1,IdEquipe2")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipe1"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe1);
            ViewData["IdEquipe2"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe2);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            ViewData["IdEquipe1"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe1);
            ViewData["IdEquipe2"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe2);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPartida,DataPartida,PlacarEquipe1,PlacarEquipe2,IdEquipe1,IdEquipe2")] Partida partida)
        {
            if (id != partida.IdPartida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.IdPartida))
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
            ViewData["IdEquipe1"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe1);
            ViewData["IdEquipe2"] = new SelectList(_context.Equipes, "IdEquipe", "IdEquipe", partida.IdEquipe2);
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partida
                .Include(p => p.IdEquipe1Navigation)
                .Include(p => p.IdEquipe2Navigation)
                .FirstOrDefaultAsync(m => m.IdPartida == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partida.FindAsync(id);
            if (partida != null)
            {
                _context.Partida.Remove(partida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partida.Any(e => e.IdPartida == id);
        }
    }
}
