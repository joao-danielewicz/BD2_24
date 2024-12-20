﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Campeonato.Models;

namespace Campeonato.Controllers
{
    public class TorneiosController : Controller
    {
        private readonly CampeonatoContext _context;

        public TorneiosController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Torneios
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Torneios.Include(t => t.IdModalidadeNavigation).Include(t => t.IdTipoTorneioNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Torneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios
                .Include(t => t.IdModalidadeNavigation)
                .Include(t => t.IdTipoTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdTorneio == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        // GET: Torneios/Create
        public IActionResult Create()
        {
            ViewData["IdModalidade"] = new SelectList(_context.TipoModalidades, "IdModalidade", "NomeModalidade");
            ViewData["IdTipoTorneio"] = new SelectList(_context.TipoTorneios, "IdTipoTorneio", "NomeTipo");
            return View();
        }

        // POST: Torneios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTorneio,NomeTorneio,DataInicio,DataFim,IdModalidade,IdTipoTorneio")] Torneio torneio)
        {
            
            _context.Add(torneio);
            await _context.SaveChangesAsync();
            
            ViewData["IdModalidade"] = new SelectList(_context.TipoModalidades, "IdModalidade", "NomeModalidade", torneio.IdModalidade);
            ViewData["IdTipoTorneio"] = new SelectList(_context.TipoTorneios, "IdTipoTorneio", "NomeTipo", torneio.IdTipoTorneio);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Torneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios.FindAsync(id);
            if (torneio == null)
            {
                return NotFound();
            }
            ViewData["IdModalidade"] = new SelectList(_context.TipoModalidades, "IdModalidade", "NomeModalidade", torneio.IdModalidade);
            ViewData["IdTipoTorneio"] = new SelectList(_context.TipoTorneios, "IdTipoTorneio", "NomeTipo", torneio.IdTipoTorneio);
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTorneio,NomeTorneio,DataInicio,DataFim,IdModalidade,IdTipoTorneio")] Torneio torneio)
        {
            if (id != torneio.IdTorneio)
            {
                return NotFound();
            }

            
            try
            {
                _context.Update(torneio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneioExists(torneio.IdTorneio))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            ViewData["IdModalidade"] = new SelectList(_context.TipoModalidades, "IdModalidade", "NomeModalidade", torneio.IdModalidade);
            ViewData["IdTipoTorneio"] = new SelectList(_context.TipoTorneios, "IdTipoTorneio", "NomeTipo", torneio.IdTipoTorneio);
             return RedirectToAction(nameof(Index));
            
        }

        // GET: Torneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios
                .Include(t => t.IdModalidadeNavigation)
                .Include(t => t.IdTipoTorneioNavigation)
                .FirstOrDefaultAsync(m => m.IdTorneio == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneio = await _context.Torneios.FindAsync(id);
            if (torneio != null)
            {
                _context.Torneios.Remove(torneio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneioExists(int id)
        {
            return _context.Torneios.Any(e => e.IdTorneio == id);
        }
    }
}
