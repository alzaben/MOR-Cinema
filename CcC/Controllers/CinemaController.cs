using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int movieId)
        {
            var cinemas = _context.cinemas.Where(c => c.MovieId == movieId).ToList();
            ViewBag.MovieId = movieId; // Pass the movieId to the view
            return View(cinemas);
        }
    }
}
