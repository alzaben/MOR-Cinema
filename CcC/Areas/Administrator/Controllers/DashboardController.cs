using Microsoft.AspNetCore.Mvc;

namespace CcC.Areas.Administrator.Controllers
{
	[Area("Administrator")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
