using CcC.Data;
using CcC.Models;
using CcC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CcC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> SignInManager;
        public static int cartCount = 0;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context , UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            _logger = logger;
            _context = context;
            userManager = _userManager;
            SignInManager = _signInManager;

            cartCount = _context.Carts.Count();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string searchTerm)
        {
            // Perform the search query using the searchTerm
            var moview = _context.Movies
                .Where(p => p.Name!.Contains(searchTerm) || p.Description!.Contains(searchTerm))
                .ToList();

            // Pass the results to the view or return them as needed
            return View(moview);
        }

        [HttpGet]
        public IActionResult FeedBack()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FeedBack(FeedBack model)
        {
            if (ModelState.IsValid)
            {
                _context.feedBacks.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }


            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> MovieDetails(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public IActionResult AddToCart()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> AddToCart(List<int> selectedSeats, int cinemaId, int movieId)
        {
            var selectedSeatsNames = _context.seats.Where(s => selectedSeats.Contains(s.Id)).Select(s => s.Number).ToList();
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
            if (movie == null)
            {
                // Handle case where movie is not found
                return NotFound();
            }

            var movieName = movie.Name;
            var price = movie.TicketPrice;

            foreach (var seatName in selectedSeatsNames)
            {
                var cart = new Cart
                {
                    ProductName = $"{movieName} - {seatName}",
                    Price = price,
                };

                var user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    cart.UserId = user.Id;
                }

                _context.Add(cart);
            }

            foreach (var seatId in selectedSeats)
            {
                var seat = _context.seats.FirstOrDefault(s => s.Id == seatId);
                if (seat != null)
                {
                    seat.Reserved = true;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Cart", "Home");
        }





		[Authorize]
		public async Task<IActionResult> Cart()
        {
            ViewBag.Cart = await GetCart();
            return View();
        }


        private async Task<List<Cart>> GetCart()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                return await _context.Carts.Where(c => c.UserId == user.Id).ToListAsync();
            }
            return null;
        }


        
        
        public IActionResult Char()
        {
            return View();
        }
        public IActionResult PayNow()
        {
            return View();
        }
        public IActionResult AllSnack()
        {
            return View();
        }
        public IActionResult PaymentDone()
        {
            return View();
        }
        private List<Snack> snacks = new List<Snack>()
        {
        new Snack { SnackId = 1, SnackName = "PopCorn", Price = 2.99m}, 
        new Snack { SnackId = 3, SnackName = "CarmelPopCorn", Price = 3.49m },
        new Snack { SnackId = 5, SnackName = "Snadwich", Price = 2.49m },
        new Snack { SnackId = 6, SnackName = "Burger", Price = 5.49m },
        // Add more snacks as needed
         };
    
        public IActionResult Snacks()
        {
            // Pass the snacks list to the view
            ViewBag.Snacks = snacks;
            return View();
        }
		private List<Snack> snacksb = new List<Snack>()
		{
        new Snack { SnackId = 2, SnackName = "Pepsi", Price = 1.00m },
        new Snack { SnackId = 4, SnackName = "Fanta", Price = 1.00m },
        new Snack { SnackId = 9, SnackName = "7UP", Price = 1.00m },
		new Snack { SnackId = 10, SnackName = "Cola", Price = 1.00m },
		
        // Add more snacks as needed
         };

		public IActionResult SnacksB()
		{
			// Pass the snacks list to the view
			ViewBag.Snacks = snacksb;
			return View();
		}
		[Authorize]
		[HttpPost("AddToCartSnack")]
        public async Task<IActionResult> AddToCart(int snackId, string size, int quantity, string listType)
        {
            List<Snack> selectedSnacks;
            switch (listType)
            {
                case "snacks":
                    selectedSnacks = snacks;
                    break;
                case "snacksb":
                    selectedSnacks = snacksb;
                    break;
                default:
                    // Handle the case where an invalid listType is provided
                    return RedirectToAction("Index");
            }

            // Retrieve the selected snack based on the snackId
            Snack selectedSnack = selectedSnacks.FirstOrDefault(s => s.SnackId == snackId);

            if (selectedSnack != null)
            {
                decimal totalPrice = selectedSnack.Price * quantity;

                // Adjust the total price based on the selected size
                switch (size)
                {
                    case "small":
                        totalPrice += 1.00m * quantity;
                        break;
                    case "medium":
                        totalPrice += 2.00m * quantity;
                        break;
                    case "large":
                        totalPrice += 3.00m * quantity;
                        break;
                }

                // Create a new Cart item based on the selected snack, size, and quantity
                var cart = new Cart
                {
                    ProductName = selectedSnack.SnackName + " (" + size + ")",
                    Price = totalPrice
                };

                var user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    cart.UserId = user.Id;
                }

                _context.Add(cart);
                await _context.SaveChangesAsync();

                // Redirect to the cart page or show a success message
                return RedirectToAction("Cart");
            }
            else
            {
                // Handle the case where the selected snack doesn't exist
                return RedirectToAction("Index");
            }
        }







    }
}