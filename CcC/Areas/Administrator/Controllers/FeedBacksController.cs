using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CcC.Data;
using CcC.Models;

namespace CcC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class FeedBacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedBacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/FeedBacks
        public async Task<IActionResult> Index()
        {
              return _context.feedBacks != null ? 
                          View(await _context.feedBacks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.feedBacks'  is null.");
        }

        // GET: Administrator/FeedBacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.feedBacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedBacks
                .FirstOrDefaultAsync(m => m.FeedBackId == id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return View(feedBack);
        }

        // GET: Administrator/FeedBacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/FeedBacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedBackId,Name,Email,Message")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedBack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedBack);
        }

        // GET: Administrator/FeedBacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.feedBacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }
            return View(feedBack);
        }

        // POST: Administrator/FeedBacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedBackId,Name,Email,Message")] FeedBack feedBack)
        {
            if (id != feedBack.FeedBackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedBack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackExists(feedBack.FeedBackId))
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
            return View(feedBack);
        }

        // GET: Administrator/FeedBacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.feedBacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedBacks
                .FirstOrDefaultAsync(m => m.FeedBackId == id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return View(feedBack);
        }

        // POST: Administrator/FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.feedBacks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.feedBacks'  is null.");
            }
            var feedBack = await _context.feedBacks.FindAsync(id);
            if (feedBack != null)
            {
                _context.feedBacks.Remove(feedBack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackExists(int id)
        {
          return (_context.feedBacks?.Any(e => e.FeedBackId == id)).GetValueOrDefault();
        }
    }
}
