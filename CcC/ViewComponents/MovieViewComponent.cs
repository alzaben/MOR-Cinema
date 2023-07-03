using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.ViewComponents
{
	public class MovieViewComponent:ViewComponent
	{
		private ApplicationDbContext db;
        public MovieViewComponent(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data=db.Movies.OrderByDescending(x=>x.CreationDate);
            return View(data);
        }

	}
}
