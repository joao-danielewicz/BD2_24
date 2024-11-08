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
    public class TipoModalidadesController : Controller
    {
        private readonly CampeonatoContext _context;

        public TipoModalidadesController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: TipoModalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoModalidades.ToListAsync());
        }

        // GET: TipoModalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoModalidade = await _context.TipoModalidades
                .FirstOrDefaultAsync(m => m.IdModalidade == id);
            if (tipoModalidade == null)
            {
                return NotFound();
            }

            return View(tipoModalidade);
        }

        // GET: TipoModalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoModalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModalidade,NomeModalidade")] TipoModalidade tipoModalidade)
        {
            
                _context.Add(tipoModalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: TipoModalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoModalidade = await _context.TipoModalidades.FindAsync(id);
            if (tipoModalidade == null)
            {
                return NotFound();
            }
            return View(tipoModalidade);
        }

        // POST: TipoModalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdModalidade,NomeModalidade")] TipoModalidade tipoModalidade)
        {
            if (id != tipoModalidade.IdModalidade)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(tipoModalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoModalidadeExists(tipoModalidade.IdModalidade))
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

        // GET: TipoModalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoModalidade = await _context.TipoModalidades
                .FirstOrDefaultAsync(m => m.IdModalidade == id);
            if (tipoModalidade == null)
            {
                return NotFound();
            }

            return View(tipoModalidade);
        }

        // POST: TipoModalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoModalidade = await _context.TipoModalidades.FindAsync(id);
            if (tipoModalidade != null)
            {
                _context.TipoModalidades.Remove(tipoModalidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoModalidadeExists(int id)
        {
            return _context.TipoModalidades.Any(e => e.IdModalidade == id);
        }
    }
}
