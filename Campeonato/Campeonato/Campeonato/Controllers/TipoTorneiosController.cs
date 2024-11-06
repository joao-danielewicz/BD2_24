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
    public class TipoTorneiosController : Controller
    {
        private readonly CampeonatoContext _context;

        public TipoTorneiosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: TipoTorneios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTorneios.ToListAsync());
        }

        // GET: TipoTorneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTorneio = await _context.TipoTorneios
                .FirstOrDefaultAsync(m => m.IdTipoTorneio == id);
            if (tipoTorneio == null)
            {
                return NotFound();
            }

            return View(tipoTorneio);
        }

        // GET: TipoTorneios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTorneios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTorneio,NomeTipo")] TipoTorneio tipoTorneio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTorneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTorneio);
        }

        // GET: TipoTorneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTorneio = await _context.TipoTorneios.FindAsync(id);
            if (tipoTorneio == null)
            {
                return NotFound();
            }
            return View(tipoTorneio);
        }

        // POST: TipoTorneios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTorneio,NomeTipo")] TipoTorneio tipoTorneio)
        {
            if (id != tipoTorneio.IdTipoTorneio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTorneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTorneioExists(tipoTorneio.IdTipoTorneio))
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
            return View(tipoTorneio);
        }

        // GET: TipoTorneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTorneio = await _context.TipoTorneios
                .FirstOrDefaultAsync(m => m.IdTipoTorneio == id);
            if (tipoTorneio == null)
            {
                return NotFound();
            }

            return View(tipoTorneio);
        }

        // POST: TipoTorneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTorneio = await _context.TipoTorneios.FindAsync(id);
            if (tipoTorneio != null)
            {
                _context.TipoTorneios.Remove(tipoTorneio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTorneioExists(int id)
        {
            return _context.TipoTorneios.Any(e => e.IdTipoTorneio == id);
        }
    }
}
