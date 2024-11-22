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
    public class EquipesController : Controller
    {
        private readonly CampeonatoContext _context;

        public EquipesController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Equipes
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Equipes.Include(e => e.IdTorneioNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Equipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes
                .Include(e => e.IdTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipe == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // GET: Equipes/Create
        public IActionResult Create()
        {
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio");
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipe,NomeEquipe,IdGrupo,IdTorneio")] Equipe equipe)
        {
            
                _context.Add(equipe);
                await _context.SaveChangesAsync();
            
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", equipe.IdTorneio);
            
                return RedirectToAction(nameof(Index));
        }

        // GET: Equipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", equipe.IdTorneio);
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipe,NomeEquipe,IdGrupo,IdTorneio")] Equipe equipe)
        {
            if (id != equipe.IdEquipe)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.IdEquipe))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", equipe.IdTorneio);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Equipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes
                .Include(e => e.IdTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipe == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipes.Remove(equipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipes.Any(e => e.IdEquipe == id);
        }
    }
}
