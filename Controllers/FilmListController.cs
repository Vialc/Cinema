using Microsoft.AspNetCore.Mvc;

namespace MeuCinema.Controllers
{
    public class FilmListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sections()
        {
            return View();
        }
    }
}
