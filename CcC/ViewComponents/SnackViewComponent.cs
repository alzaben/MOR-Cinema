using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.ViewComponents
{
	public class SnackViewComponent:ViewComponent
	{

		private ApplicationDbContext db;
		public SnackViewComponent(ApplicationDbContext _db)
		{
			db = _db;
		}
		public IViewComponentResult Invoke()
		{
			var data = db.snacks.OrderByDescending(x => x.CreationDate);
			return View(data);
		}
	}
}
