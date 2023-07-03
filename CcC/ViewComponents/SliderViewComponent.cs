using CcC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CcC.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private ApplicationDbContext db;
        public SliderViewComponent(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            var data = db.Sliders.OrderByDescending(x => x.CreationDate).Take(6);
            return View(data);
        }
    }
}
