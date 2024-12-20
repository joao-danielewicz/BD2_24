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
    public class AtletasController : Controller
    {
        private readonly CampeonatoContext _context;

        public AtletasController(CampeonatoContext context)
        {
            _context = context;
        }

        // GET: Atletas
        public async Task<IActionResult> Index()
        {
            var campeonatoContext = _context.Atleta.Include(a => a.IdEquipeNavigation);
            return View(await campeonatoContext.ToListAsync());
        }

        // GET: Atletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .Include(a => a.IdEquipeNavigation)
                .FirstOrDefaultAsync(m => m.IdAtleta == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // GET: Atletas/Create
        public IActionResult Create()
        {
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe");
            return View();
        }

        // POST: Atletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtleta,Nome,IdEquipe")] Atleta atleta)
        {
            
                _context.Add(atleta);
                await _context.SaveChangesAsync();
            
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", atleta.IdEquipe);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Atletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }
            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", atleta.IdEquipe);
            return View(atleta);
        }

        // POST: Atletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtleta,Nome,IdEquipe")] Atleta atleta)
        {
            if (id != atleta.IdAtleta)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(atleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtletaExists(atleta.IdAtleta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            ViewData["IdEquipe"] = new SelectList(_context.Equipes, "IdEquipe", "NomeEquipe", atleta.IdEquipe);

                return RedirectToAction(nameof(Index));
        }

        // GET: Atletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atleta = await _context.Atleta
                .Include(a => a.IdEquipeNavigation)
                .FirstOrDefaultAsync(m => m.IdAtleta == id);
            if (atleta == null)
            {
                return NotFound();
            }

            return View(atleta);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta != null)
            {
                _context.Atleta.Remove(atleta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtletaExists(int id)
        {
            return _context.Atleta.Any(e => e.IdAtleta == id);
        }
    }
}
