using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa22Team16.DAL;
using fa22Team16.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fa22Team16
{
    public class StockPortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public StockPortfolioController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StockPortfolio
        public async Task<IActionResult> Index()
        {

            List<StockPortfolio> stockPortfolios = new List<StockPortfolio>();

            stockPortfolios = _context.StockPortfolios.Where(o => o.AppUser.UserName == User.Identity.Name).ToList();


            return View(stockPortfolios);



            //return View(await _context.StockPortfolios.ToListAsync());
        }

        // GET: StockPortfolio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockPortfolios == null)
            {
                return NotFound();
            }

            StockPortfolio myportfolio = await _context.StockPortfolios
                .Include(o => o.StockTransactions)
                .ThenInclude(o => o.Stock)
                .Where(m => m.AppUser.UserName == User.Identity.Name)
                .FirstOrDefaultAsync(m => m.StockPortfolioID == id);

            if (myportfolio == null)
            {
                return NotFound();
            }

            return View(myportfolio);
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
            if (ModelState.IsValid == false)
            {
                return View(stockPortfolio);
            }

            //order.OrderNumber = Utilities.GenerateNextOrderNumber.GetNextOrderNumber(_context);
            stockPortfolio.AppUser = await _userManager.FindByNameAsync(User.Identity.Name);

            _context.Add(stockPortfolio);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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
