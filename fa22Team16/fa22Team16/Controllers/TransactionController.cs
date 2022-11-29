using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using fa22Team16.DAL;
using fa22Team16.Models;

namespace fa22Team16
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        
        public async Task<IActionResult> Index()
        {
              return View(await _context.Transactions.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to view this transaction!" });
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            Transaction transaction = new Transaction();

            //if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
            //{
            //    return View("Error", new string[] { "You are not authorized to create this transaction!" });
            //}

            ViewBag.AllAccounts = GetAllAccountsSelectList();

            //make sure a customer isn't trying to look at someone else's order
            

            return View(transaction);

        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction, int AccountNumber)
        {
            //find the registration that should be associated with this registration
            BankAccount dbAccount = _context.BankAccounts.Find(AccountNumber);

            //set the new registration detail's registration equal to the registration you just found
            transaction.Account = dbAccount;

            if (transaction.Type == TransactionType.Deposit)
            {
                transaction.Account.Balance = transaction.Account.Balance + transaction.Amount;
            }
            else if (transaction.Type == TransactionType.Withdraw)
            {
                transaction.Account.Balance = transaction.Account.Balance - transaction.Amount;
            }
            // todo: add transfer


            _context.Add(transaction);
            await _context.SaveChangesAsync();

            //if (ModelState.IsValid)
            //{
            //    _context.Add(transaction);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return RedirectToAction("Create", "TransactionDetails", new { TransactionID = transaction.TransactionID });
        }

        // GET: Transaction/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to edit this transaction!" });
            }

            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,Amount")] Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionID))
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
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'AppDbContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private SelectList GetAllAccountsSelectList()
        {
            //Get the list of months from the database
            List<BankAccount> bankAccountList = _context.BankAccounts.ToList();

            //convert the list to a SelectList by calling SelectList constructor
            //MonthID and MonthName are the names of the properties on the Month class
            //MonthID is the primary key
            SelectList accountSelectList = new SelectList(bankAccountList.OrderBy(m => m.BankAccountID), "BankAccountID", "BankAccountName");

            //return the electList
            return accountSelectList;
        }
        private bool TransactionExists(int id)
        {
          return _context.Transactions.Any(e => e.TransactionID == id);
        }
    }
}