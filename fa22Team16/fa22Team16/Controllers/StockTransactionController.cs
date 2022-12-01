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
    public class StockTransactionController : Controller
    {
        private readonly AppDbContext _context;

        public StockTransactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockTransaction
        public async Task<IActionResult> Index()
        {
              return View(await _context.StockTransactions.ToListAsync());
        }

        // GET: StockTransaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockTransactions == null)
            {
                return NotFound();
            }

            var stockTransaction = await _context.StockTransactions
                .FirstOrDefaultAsync(m => m.StockTransactionID == id);
            if (stockTransaction == null)
            {
                return NotFound();
            }

            return View(stockTransaction);

        }

        // GET: StockTransaction/Create
        public IActionResult Create()
        {
            ViewBag.AllStocks = GetAllStockSelectList();

            return View();
        }

        // POST: StockTransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockTransaction stockTransaction, int SelectedStock)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.AllStocks = GetAllStockSelectList();
                return View(stockTransaction);
            }

            //this is a purchase
            stockTransaction.Type = StockTransactionType.Purchase;

            //find the stock associated with the purchase
            Stock dbstock = _context.Stocks.Find(SelectedStock);

            //set the stock equal
            stockTransaction.Stock = dbstock;

            //find the correct stock portfolio
            StockPortfolio dbstockportfolio = _context.StockPortfolios.Find(stockTransaction.StockPortfolio.StockPortfolioID);

            //set equal
            stockTransaction.StockPortfolio = dbstockportfolio;

            //set price
            stockTransaction.Price = dbstock.Price;

            //calc current value
            stockTransaction.CurrentValue = stockTransaction.NumberOfShares * stockTransaction.Price;

            //subtract from your selected account
            dbstockportfolio.StockPortfolioCashBalance = dbstockportfolio.StockPortfolioCashBalance - stockTransaction.CurrentValue;

            //you can't buy something you can't afford
            if (stockTransaction.CurrentValue > dbstockportfolio.StockPortfolioCashBalance)
            {
                ViewBag.Error = "You can't afford this puchase! Try again.";

                return View("Index");
            }

            _context.Add(stockTransaction);
            await _context.SaveChangesAsync();

            //redirect to confirm page
            return View("Confirm");
        }

        // GET: StockTransaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockTransactions == null)
            {
                return NotFound();
            }

            var stockTransaction = await _context.StockTransactions.FindAsync(id);
            if (stockTransaction == null)
            {
                return NotFound();
            }
            return View(stockTransaction);
        }

        // POST: StockTransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockTransactionID,NumberOfShares,Price")] StockTransaction stockTransaction)
        {
            if (id != stockTransaction.StockTransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTransactionExists(stockTransaction.StockTransactionID))
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
            return View(stockTransaction);
        }

        // GET: StockTransaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockTransactions == null)
            {
                return NotFound();
            }

            var stockTransaction = await _context.StockTransactions
                .FirstOrDefaultAsync(m => m.StockTransactionID == id);
            if (stockTransaction == null)
            {
                return NotFound();
            }

            return View(stockTransaction);
        }

        // POST: StockTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockTransactions == null)
            {
                return Problem("Entity set 'AppDbContext.StockTransactions'  is null.");
            }
            var stockTransaction = await _context.StockTransactions.FindAsync(id);
            if (stockTransaction != null)
            {
                _context.StockTransactions.Remove(stockTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList GetAllStockSelectList()
        {
            List<Stock> allStocks = _context.Stocks.ToList();

            //use the constructor on select list to create a new select list with the options
            SelectList slAllStocks = new SelectList(allStocks, nameof(Stock.StockID), nameof(Stock.Name));

            return slAllStocks;
        }

        private bool StockTransactionExists(int id)
        {
          return _context.StockTransactions.Any(e => e.StockTransactionID == id);
        }
    }
}
