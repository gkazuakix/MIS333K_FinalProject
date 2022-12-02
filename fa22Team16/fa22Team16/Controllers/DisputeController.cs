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
namespace fa22Team16
{
    [Authorize] 
    public class DisputeController : Controller
    {
        private readonly AppDbContext _context;

        public DisputeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dispute
        public async Task<IActionResult> Index()
        {
              return View(await _context.Disputes.ToListAsync());
        }

        // GET: Dispute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Dispute/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            ViewBag.AllTransactions = GetAllTransactionsSelectList();
            return View();
        }

        // POST: Dispute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("DisputeID,Transaction,Description,Status,CorrectAmount,RequestDeleteTransaction")] Dispute dispute)
        {
            if (ModelState.IsValid == false)
            {
                return View(dispute);
            }
              
            _context.Add(dispute);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dispute", new { dispute.DisputeID });
            
        }
           
        public async Task<SelectList> GetAllTransactionsSelectList()
        {
            List<Transaction> allTransactions = new List<Transaction>();

            foreach (Transaction dbTransaction in _context.Transactions)
            {
                if (dbTransaction.Account.appUser.UserName == User.Identity.Name)
                {
                    allTransactions.Add(dbTransaction);
                }           
            }
            SelectList slAllTransactions = new SelectList(allTransactions, nameof(Transaction.TransactionID), nameof(Transaction.TransactionNum));
   
            return slAllTransactions;

           
        }


        // GET: Dispute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes.FindAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }
            return View(dispute);
        }

        // POST: Dispute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisputeID")] Dispute dispute)
        {
            if (id != dispute.DisputeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeExists(dispute.DisputeID))
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
            return View(dispute);
        }

        // GET: Dispute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: Dispute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disputes == null)
            {
                return Problem("Entity set 'AppDbContext.Disputes'  is null.");
            }
            var dispute = await _context.Disputes.FindAsync(id);
            if (dispute != null)
            {
                _context.Disputes.Remove(dispute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisputeExists(int id)
        {
          return _context.Disputes.Any(e => e.DisputeID == id);
        }
    }
}
