using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.Controllers
{
    public class SeatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public IActionResult Index(int cinemaId, int movieId)
        {
            var seats = _context.seats.Where(s => s.CinemaId == cinemaId).ToList();
            ViewBag.CinemaId = cinemaId;
            ViewBag.MovieId = movieId;
            return View(seats);
        }*/
        public IActionResult Index(int cinemaId, int movieId)
        {
            var seats = _context.seats.Where(s => s.CinemaId == cinemaId && !s.Reserved).ToList();
            ViewBag.CinemaId = cinemaId;
            ViewBag.MovieId = movieId;
            return View(seats);
        }



    }
}
