using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CcC.Data;
using CcC.Models;
using CcC.Models.ViewModels;

namespace CcC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public CinemasController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/Cinemas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cinemas.Include(c => c.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administrator/Cinemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // GET: Administrator/Cinemas/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "Name");
            return View();
            
        }

        // POST: Administrator/Cinemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaViewModel model)
        {
            string imgName = FileUpload(model);
            Cinema cinema = new Cinema
            {
                CreationDate=model.CreationDate,
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                IsPublished = model.IsPublished,
                Location = model.Location,
                Movie = model.Movie,
                MovieId = model.MovieId,
                Name = model.Name,
                UserId = model.UserId,
                Img=imgName
            };
                _context.Add(cinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", model.MovieId);
            return View(cinema);
        }

        // GET: Administrator/Cinemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas.FindAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", cinema.MovieId);
            return View(cinema);
        }

        // POST: Administrator/Cinemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Img,Location,MovieId,CreationDate,IsPublished,IsDeleted,UserId")] Cinema cinema)
        {
            if (id != cinema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaExists(cinema.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId", cinema.MovieId);
            return View(cinema);
        }

        // GET: Administrator/Cinemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.cinemas
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // POST: Administrator/Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cinemas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cinemas'  is null.");
            }
            var cinema = await _context.cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.cinemas.Remove(cinema);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaExists(int id)
        {
          return (_context.cinemas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public string FileUpload(CinemaViewModel model)
        {
            string wwwPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwPath)) { }
            string contentPath = _webHostEnvironment.ContentRootPath;
            if (string.IsNullOrEmpty(contentPath)) { }
            string p = Path.Combine(wwwPath, "Pics");
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }
            string fileName = Path.GetFileNameWithoutExtension(model.Img!.FileName);
            string newImgName = "OMR_" + fileName + "_" + Guid.NewGuid().ToString() + Path.GetExtension(model.Img!.FileName);
            using (FileStream fileStream = new FileStream(Path.Combine(p, newImgName), FileMode.Create))
            {
                model.Img.CopyTo(fileStream);
            }

            return "\\Pics\\" + newImgName;
        }
    }
}
