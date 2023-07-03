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
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Seats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.seats.Include(s => s.Cinema);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administrator/Seats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.seats == null)
            {
                return NotFound();
            }

            var seat = await _context.seats
                .Include(s => s.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Administrator/Seats/Create
        public IActionResult Create()
        {
            ViewData["CinemaId"] = new SelectList(_context.cinemas, "Id", "Id");
            return View();
        }

        // POST: Administrator/Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Row,Number,CinemaId")] Seat seat)
        {
            
                _context.Add(seat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            ViewData["CinemaId"] = new SelectList(_context.cinemas, "Id", "Id", seat.CinemaId);
            return View(seat);
        }

        // GET: Administrator/Seats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.seats == null)
            {
                return NotFound();
            }

            var seat = await _context.seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(_context.cinemas, "Id", "Id", seat.CinemaId);
            return View(seat);
        }

        // POST: Administrator/Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Row,Number,CinemaId")] Seat seat)
        {
            if (id != seat.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["CinemaId"] = new SelectList(_context.cinemas, "Id", "Id", seat.CinemaId);
            return View(seat);
        }

        // GET: Administrator/Seats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.seats == null)
            {
                return NotFound();
            }

            var seat = await _context.seats
                .Include(s => s.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Administrator/Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.seats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.seats'  is null.");
            }
            var seat = await _context.seats.FindAsync(id);
            if (seat != null)
            {
                _context.seats.Remove(seat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(int id)
        {
          return (_context.seats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
