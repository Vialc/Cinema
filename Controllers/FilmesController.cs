#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuCinema.Data;
using MeuCinema.Models;

namespace MeuCinema.Controllers
{
    public class FilmesController : Controller
    {
        private readonly DBCinemaContext _context;

        public FilmesController(DBCinemaContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmesModel == null)
            {
                return NotFound();
            }

            return View(filmesModel);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sinopse,Imagem")] FilmesModel filmesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmesModel);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes.FindAsync(id);
            if (filmesModel == null)
            {
                return NotFound();
            }
            return View(filmesModel);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sinopse,Imagem")] FilmesModel filmesModel)
        {
            if (id != filmesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesModelExists(filmesModel.Id))
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
            return View(filmesModel);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmesModel == null)
            {
                return NotFound();
            }

            return View(filmesModel);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmesModel = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filmesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmesModelExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
