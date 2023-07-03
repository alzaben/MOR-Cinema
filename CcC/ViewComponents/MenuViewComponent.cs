using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private ApplicationDbContext db;
        public MenuViewComponent(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.Menus.OrderByDescending(x => x.CreationDate).Take(6);
            return View(data);
        }
    }
}
