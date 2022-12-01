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
    public class StockPortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public StockPortfolioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockPortfolio
        public async Task<IActionResult> Index()
        {
            //need to pass through list of StockTransactions that are related to signed in user

            /*
            List<StockTransaction> stocktransactions;

            stocktransactions = _context.StockTransactions
                                            .Include(r => r.StockPortfolio)
                                            .Where(r => r.User.UserName == User.Identity.Name)
                                            .ToList();

            return View(stocktransactions);
            */


            //need to allow only the user who owns portfolio to see

            StockPortfolio myportfolio = await _context.StockPortfolios
                .Include(m => m.StockTransactions)
                .Where(m => m.AppUser.UserName == User.Identity.Name)
                .FirstOrDefaultAsync(m => m.StockPortfolioID == id);

            if (myportfolio == null)
            {
                return NotFound();
            }

            return View(myportfolio);

            // return View(await _context.StockPortfolios.ToListAsync());
        }

        // GET: StockPortfolio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockPortfolios == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(m => m.StockPortfolioID == id);
            if (stockPortfolio == null)
            {
                return NotFound();
            }

            return View(stockPortfolio);
        }

        // GET: StockPortfolio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockPortfolio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockPortfolioID")] StockPortfolio stockPortfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockPortfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockPortfolio);
        }

        // GET: StockPortfolio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockPortfolios == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios.FindAsync(id);
            if (stockPortfolio == null)
            {
                return NotFound();
            }
            return View(stockPortfolio);
        }

        // POST: StockPortfolio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockPortfolioID")] StockPortfolio stockPortfolio)
        {
            if (id != stockPortfolio.StockPortfolioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockPortfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockPortfolioExists(stockPortfolio.StockPortfolioID))
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
            return View(stockPortfolio);
        }

        // GET: StockPortfolio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockPortfolios == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(m => m.StockPortfolioID == id);
            if (stockPortfolio == null)
            {
                return NotFound();
            }

            return View(stockPortfolio);
        }

        // POST: StockPortfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockPortfolios == null)
            {
                return Problem("Entity set 'AppDbContext.StockPortfolios'  is null.");
            }
            var stockPortfolio = await _context.StockPortfolios.FindAsync(id);
            if (stockPortfolio != null)
            {
                _context.StockPortfolios.Remove(stockPortfolio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockPortfolioExists(int id)
        {
          return _context.StockPortfolios.Any(e => e.StockPortfolioID == id);
        }


    
    }
}
