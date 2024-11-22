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
    public class ResultadosController : Controller
    {
        private readonly CampeonatoContext _context;

        public ResultadosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Resultados
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Resultados.Include(r => r.IdEquipeNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.IdEquipeNavigation)
                .FirstOrDefaultAsync(m => m.IdResultado == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultados/Create
        public IActionResult Create()
        {
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe");
            return View();
        }

        // POST: Resultados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResultado,QuantidadePontos,IdEquipe")] Resultado resultado)
        {
            
                _context.Add(resultado);
                await _context.SaveChangesAsync();
            
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", resultado.IdEquipe);
                return RedirectToAction(nameof(Index));
        }

        // GET: Resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", resultado.IdEquipe);
            return View(resultado);
        }

        // POST: Resultados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResultado,QuantidadePontos,IdEquipe")] Resultado resultado)
        {
            if (id != resultado.IdResultado)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.IdResultado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", resultado.IdEquipe);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.IdEquipeNavigation)
                .FirstOrDefaultAsync(m => m.IdResultado == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
            return _context.Resultados.Any(e => e.IdResultado == id);
        }
    }
}
