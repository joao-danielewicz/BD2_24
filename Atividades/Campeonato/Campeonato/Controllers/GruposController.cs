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
    public class GruposController : Controller
    {
        private readonly CampeonatoContext _context;

        public GruposController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Grupos.Include(g => g.IdFaseNavigation).Include(g => g.IdTorneioNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdFaseNavigation)
                .Include(g => g.IdTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewData["IdFase"] = new SelectList(_context.Fases, "IdFase", "Descricao");
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,NomeGrupo,IdFase,IdTorneio")] Grupo grupo)
        {
            _context.Add(grupo);
            await _context.SaveChangesAsync();
            ViewData["IdFase"] = new SelectList(_context.Fases, "IdFase", "Descricao", grupo.IdFase);
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", grupo.IdTorneio);
           return RedirectToAction(nameof(Index));
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdFase"] = new SelectList(_context.Fases, "IdFase", "Descricao", grupo.IdFase);
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", grupo.IdTorneio);
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,NomeGrupo,IdFase,IdTorneio")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return NotFound();
            }
            try
            {
                _context.Update(grupo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(grupo.IdGrupo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["IdFase"] = new SelectList(_context.Fases, "IdFase", "Descricao", grupo.IdFase);
            ViewData["IdTorneio"] = new SelectList(_context.Torneios, "IdTorneio", "NomeTorneio", grupo.IdTorneio);
            return RedirectToAction(nameof(Index));
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdFaseNavigation)
                .Include(g => g.IdTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo != null)
            {
                _context.Grupos.Remove(grupo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.IdGrupo == id);
        }
    }
}
