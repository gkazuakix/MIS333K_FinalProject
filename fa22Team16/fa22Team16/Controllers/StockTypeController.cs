using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa22Team16.DAL;
using fa22Team16.Models;

namespace fa22Team16
{
    public class StockTypeController : Controller
    {
        private readonly AppDbContext _context;

        public StockTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockType
        public async Task<IActionResult> Index()
        {
              return View(await _context.StockTypes.ToListAsync());
        }

        // GET: StockType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockTypes == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes
                .FirstOrDefaultAsync(m => m.StockTypeID == id);
            if (stockType == null)
            {
                return NotFound();
            }

            return View(stockType);
        }

        // GET: StockType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockTypeID,TypeName")] StockType stockType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockType);
        }

        // GET: StockType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockTypes == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes.FindAsync(id);
            if (stockType == null)
            {
                return NotFound();
            }
            return View(stockType);
        }

        // POST: StockType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockTypeID,TypeName")] StockType stockType)
        {
            if (id != stockType.StockTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTypeExists(stockType.StockTypeID))
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
            return View(stockType);
        }

        // GET: StockType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockTypes == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes
                .FirstOrDefaultAsync(m => m.StockTypeID == id);
            if (stockType == null)
            {
                return NotFound();
            }

            return View(stockType);
        }

        // POST: StockType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockTypes == null)
            {
                return Problem("Entity set 'AppDbContext.StockTypes'  is null.");
            }
            var stockType = await _context.StockTypes.FindAsync(id);
            if (stockType != null)
            {
                _context.StockTypes.Remove(stockType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTypeExists(int id)
        {
          return _context.StockTypes.Any(e => e.StockTypeID == id);
        }
    }
}
