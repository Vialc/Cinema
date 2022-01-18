using MeuCinema.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuCinema.Controllers
{
    public class FilmListController : Controller
    {
        private readonly DBCinemaContext _context;
        public FilmListController(DBCinemaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
        }

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

        public IActionResult Sections()
        {
            return View();
        }

        private bool FilmesModelExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
