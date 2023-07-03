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
    public class SnacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SnacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Snacks
        public async Task<IActionResult> Index()
        {
              return _context.snacks != null ? 
                          View(await _context.snacks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.snacks'  is null.");
        }

        // GET: Administrator/Snacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.snacks
                .FirstOrDefaultAsync(m => m.SnackId == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Administrator/Snacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Snacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnackId,SnackName,Price,CreationDate,IsPublished,IsDeleted,UserId")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snack);
        }

        // GET: Administrator/Snacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }
            return View(snack);
        }

        // POST: Administrator/Snacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SnackId,SnackName,Price,CreationDate,IsPublished,IsDeleted,UserId")] Snack snack)
        {
            if (id != snack.SnackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.SnackId))
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
            return View(snack);
        }

        // GET: Administrator/Snacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.snacks
                .FirstOrDefaultAsync(m => m.SnackId == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Administrator/Snacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.snacks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.snacks'  is null.");
            }
            var snack = await _context.snacks.FindAsync(id);
            if (snack != null)
            {
                _context.snacks.Remove(snack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
          return (_context.snacks?.Any(e => e.SnackId == id)).GetValueOrDefault();
        }
    }
}
