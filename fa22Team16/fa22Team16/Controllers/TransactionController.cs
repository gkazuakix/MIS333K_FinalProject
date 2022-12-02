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
            List<Transaction> transactions = new List<Transaction>();
            ////if (User.IsInRole("Customer"))
            ////{
            ////    foreach (Transaction transaction in _context.Transactions)
            ////    {
            ////        if (transaction.Account != null)
            ////        {
            ////            transactions = _context.Transactions.Where(o => o.Account.appUser.UserName == User.Identity.Name).ToList();
            ////        }
            ////        else if (transaction.StockPortfolio != null)
            ////        {
            ////            transactions = _context.Transactions.Where(o => o.Account.appUser.UserName == User.Identity.Name).ToList();
            ////        }
            ////    }
            ////}
            transactions = _context.Transactions.Where(o => o.Account.appUser.UserName == User.Identity.Name).ToList();

            return View(transactions);
            //return View(await _context.Transactions.ToListAsync());
            //create a new instance of the RegistrationDetail class
            
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }
            Transaction transaction = new Transaction();

            transaction = _context.Transactions.FirstOrDefault(m => m.TransactionID == id);

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
        //[Authorize(Roles = "Customer")]

        //public IActionResult Create()
        //{

        //}
        //public IActionResult Create()
        //{

        //    Transaction transaction = new Transaction();

        //    ViewBag.AllAccounts = GetAllAccountsSelectList();
        //    return View(transaction);

        //}

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Transaction transaction, int AccountNumber)
        //{


        //    //find the registration that should be associated with this registration
        //    BankAccount dbAccount = _context.BankAccounts.Find(AccountNumber);

        //    //make sure a customer isn't trying to look at someone else's order



        //    // set the new registration detail's registration equal to the registration you just found
        //    transaction.Account = dbAccount;

        //    if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
        //    {
        //        return View("Error", new string[] { "You are not authorized to create this transaction!" });
        //    }

        //    if (transaction.Amount >= 0)
        //    {
        //        return RedirectToAction("DepositCreate", "Transaction", new { TransactionID = transaction.TransactionID });
        //    }
        //    else if (transaction.Amount >= 0)
        //    {
        //        return RedirectToAction("WithdrawCreate", "Transaction", new { TransactionID = transaction.TransactionID });
        //    }
        //    //// todo: add transfer
        //    else
        //    {
        //        return View();
        //    }


        //_context.Add(transaction);
        //await _context.SaveChangesAsync();

        //if (ModelState.IsValid)
        //{
        //    _context.Add(transaction);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //return RedirectToAction("Create", "TransactionDetails", new { TransactionID = transaction.TransactionID });
        // }
        //  GET: Transaction/DepositCreate
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DepositCreate()
        {
            ViewBag.AllAccounts = GetAllAccountsSelectList();
            DepositCreateViewModel dpvm = new DepositCreateViewModel();
            dpvm.Date = DateTime.Now;
            //find the registration that should be associated with this registration
            //BankAccount dbBankAccount = _context.BankAccounts.Find(TransactionID);

            //set the new registration detail's registration equal to the registration you just found
            //dpvm.Account = dbBankAccount;


            //Transaction transaction = new Transaction();

            ////find the registration that should be associated with this registration
            //BankAccount dbBankAccount = _context.BankAccounts.Find(TransactionID);

            ////set the new registration detail's registration equal to the registration you just found
            //transaction.Account = dbBankAccount;

            ////populate the ViewBag with a list of existing courses
            //ViewBag.AllBankAccounts = GetAllAccountsSelectList();

            ////pass the newly created registration detail to the view
            //return View(transaction);

            return View(dpvm);
        }

        // Post: Transaction/Deposit Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(DepositCreateViewModel transaction, int AccountNumber, int[] SelectedAccount)
        public async Task<IActionResult> DepositCreate(DepositCreateViewModel transaction, int SelectedAccount)

        {
            if (ModelState.IsValid)
            {
                if (transaction.Amount > 5000)
                {
                    transaction.Approved = Approved.No;
                    return View("Error", new string[] { "This deposit amount needs to be authorized!" });
                }
                else
                {
                    transaction.Account = _context.BankAccounts.Find(SelectedAccount);
                    transaction.Account.Balance = transaction.Account.Balance + transaction.Amount;
                    transaction.Account.appUser = _context.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
                    Transaction deposit = new Transaction();
                    deposit.TransactionNum = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber(_context);
                    deposit.Account = transaction.Account;
                    deposit.Date = transaction.Date;
                    deposit.Amount = transaction.Amount;
                    deposit.Comments = transaction.Comments;
                    _context.Transactions.Add(deposit);
                    await _context.SaveChangesAsync();
                }
             return RedirectToAction(nameof(Index));

            }

            // await _context.SaveChangesAsync();
            return View(transaction);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> WithdrawCreate(Transaction transaction)
        {
            ViewBag.AllAccounts = GetAllAccountsSelectList();
            WithdrawCreateViewModel wdvm = new WithdrawCreateViewModel();
            wdvm.Date = DateTime.Now;

            return View(wdvm);
        }

        // Post: Transaction/Withdraw Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(DepositCreateViewModel transaction, int AccountNumber, int[] SelectedAccount)
        public async Task<IActionResult> WithdrawCreate(WithdrawCreateViewModel transaction, int SelectedAccount)

        {
            if (ModelState.IsValid)
            {
                transaction.Account = _context.BankAccounts.Find(SelectedAccount);

                if (transaction.Amount > transaction.Account.Balance)
                {
                    transaction.Approved = Approved.No;
                    return View("Error", new string[] { "You do not have enough funds!" });
                }
                else
                {
                    transaction.Account.Balance = transaction.Account.Balance - transaction.Amount;
                    transaction.Account.appUser = _context.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
                    Transaction withdraw = new Transaction();
                    withdraw.TransactionNum = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber(_context);
                    withdraw.Type = TransactionType.Withdraw;
                    withdraw.Account = transaction.Account;
                    withdraw.Date = transaction.Date;
                    withdraw.Amount = transaction.Amount;
                    withdraw.Comments = transaction.Comments;
                    _context.Transactions.Add(withdraw);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));

            }

            // await _context.SaveChangesAsync();
            return View(transaction);
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
            //if (transaction == null)
            //{
            //    return NotFound();
            //}

            //if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
            //{
            //    return View("Error", new string[] { "You are not authorized to edit this transaction!" });
            //}

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
            //List<BankAccount> bankAccountList = _context.BankAccounts.ToList()

            List<BankAccount> bankAccounts = _context.BankAccounts.Where(o => o.appUser.UserName == User.Identity.Name).ToList();


            //foreach (BankAccount bankAccount in _context.BankAccounts)
            //{
            //    if (bankAccount.appUser.Email == User.Identity.Name)
            //    {
            //        bankAccountList.Add(bankAccount);
            //    }
            //}


            //convert the list to a SelectList by calling SelectList constructor
            //MonthID and MonthName are the names of the properties on the Month class
            //MonthID is the primary key
            SelectList accountSelectList = new SelectList(bankAccounts, nameof(BankAccount.BankAccountID), nameof(BankAccount.AccountName));

            //return the electList
            return accountSelectList;
        }
        private bool TransactionExists(int id)
        {
          return _context.Transactions.Any(e => e.TransactionID == id);
        }
    }
}
