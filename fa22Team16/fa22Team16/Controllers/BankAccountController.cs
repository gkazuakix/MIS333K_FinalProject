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
    [Authorize]
    public class BankAccountController : Controller
    {
        private readonly AppDbContext _context;

        public BankAccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BankAccount
        public async Task<IActionResult> Index()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            bankAccounts = _context.BankAccounts.Where(o => o.appUser.UserName == User.Identity.Name).Include(ba => ba.Transactions).ToList();
            

            return View(bankAccounts);
            //return View(await _context.BankAccounts.ToListAsync());
        }

        // GET: BankAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            BankAccount account = await _context.BankAccounts
            .Include(o => o.Transactions)
            .Include(o => o.appUser)
            .FirstOrDefaultAsync(m => m.BankAccountID == id);

            if (account == null)
            {
                return NotFound();
            }

            //this is the normal state
            ViewBag.SelectedTransactions = account.Transactions.Count();

            return View(account);
        }


        // GET: BankAccount/Create
        [Authorize(Roles="Customer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("AccountID,AccountName, AccountNumber,Balance,AccountType,ActiveStatus")] BankAccount account)
        {
            account.AccountNumber = Utilities.GenerateNextAccountNumber.GetNextAccountNumber(_context);

           
            account.appUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
         

            
            if (ModelState.IsValid == false)
            {
                return View(account);
            }
            if (account.Balance > 5000)
            {
                account.ActiveStatus = false;
            }
            else
            {
                account.ActiveStatus = true;
            }
            
            _context.Add(account);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("Index", "BankAccount", new { accountID = account.BankAccountID });
        }

        // GET: BankAccount/Edit/5
        // public async Task<IActionResult> Edit(int? id);
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            //did not specify an account to edit
            if (id == null)
            {
                return View("Error", new String[] { "Please specify an account to edit" });
            }
            BankAccount BankAccount = _context.BankAccounts.FirstOrDefault(m => m.BankAccountID == id);//
            
            //account was not found in the database
            if (BankAccount == null)
            {
                return View("Error", new String[] { "This account was not found!" });
            }

            //account does not belong to this user
            if (User.IsInRole("Customer") && BankAccount.appUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this account!" });
            }

            return View(BankAccount);
            //return RedirectToAction("Edit", "BankAccount", new { accountID = BankAccount.BankAccountID });
        }

        // POST: BankAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiveStatus")] BankAccount account)
        {
            //this is a security measure to make sure the user is editing the correct account
            if (id != account.BankAccountID)
            {
                return View("Error", new String[] { "There was a problem editing this account. Try again!" });
            }

            //if there is something wrong with this order, try again
            if (ModelState.IsValid == false)
            {
                return View(account);
            }

            //if code gets this far, update the record
            try
            {
                //find the record in the database
                BankAccount dbBankAccount = _context.BankAccounts.Find(account.BankAccountID);

                _context.Update(dbBankAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this account!", ex.Message });
            }

            //send the user to the Orders Index page.
            return RedirectToAction(nameof(Index));
        }


        // GET: BankAccount/EditNickname/5
        // public async Task<IActionResult> Edit(int? id);
        [Authorize(Roles = "Customer")]
        public IActionResult EditNickname(int? id)
        {
            //did not specify an account to edit
            if (id == null)
            {
                return View("Error", new String[] { "Please specify an account to edit" });
            }
            BankAccount BankAccount = _context.BankAccounts.FirstOrDefault(m => m.BankAccountID == id);//

            //account was not found in the database
            if (BankAccount == null)
            {
                return View("Error", new String[] { "This account was not found!" });
            }

            return View(BankAccount);
            //return RedirectToAction("Edit", "BankAccount", new { accountID = BankAccount.BankAccountID });
        }

        // POST: BankAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNickname(int id, [Bind("AccountName")] BankAccount account)
        {
            BankAccount editedAccount = _context.BankAccounts.Include(d => d.Transactions).Include(d => d.appUser).FirstOrDefault(d => d.BankAccountID == id);
            //this is a security measure to make sure the user is editing the correct account
            //if (id != account.BankAccountID)
            //{
            //    return View("Error", new String[] { "There was a problem editing this account. Try again!" });
            //}

            //if there is something wrong with this order, try again
            if (ModelState.IsValid == false)
            {
                return View(account);
            }

            //if code gets this far, update the record
            try
            {
                //find the record in the database
                editedAccount.AccountName = account.AccountName;
                _context.Update(editedAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this account!", ex.Message });
            }

            //send the user to the Orders Index page.
            return RedirectToAction("Index");
        }


        //SEARCH

        public ActionResult DetailedSearch()
        {
            return View();
        }

        public ActionResult DisplaySearchResults(SearchViewModel svm)
        {
            var query = from r in _context.Transactions
                        .Where(o => o.Account.appUser.UserName == User.Identity.Name) select r;

            //query for searching by comment/description
            if (svm.Comments != null && svm.Comments != "")
            {
                query = query.Where(r => r.Comments.Contains(svm.Comments));
            }

            if (svm.Type != null)
            {
                query = query.Where(r => r.Type == svm.Type);
            }

            if (svm.MinAmount != null)
            {
                query = query.Where(r => Math.Abs(r.Amount) >= svm.MinAmount);
            }

            if (svm.MaxAmount != null)
            {
                query = query.Where(r => Math.Abs(r.Amount) <= svm.MaxAmount);
            }

            if (svm.TransactionNum != null)
            {
                query = query.Where(r => r.TransactionNum == svm.TransactionNum);
            }

            if (svm.MinDate != null)
            {
                query = query.Where(r => r.Date >= svm.MinDate);
            }

            if (svm.MaxDate != null)
            {
                query = query.Where(r => r.Date <= svm.MaxDate);
            }

            //execute the query
            List<Transaction> SelectedTransactions = query.Include(r => r.Account).ToList();

            //Populate the view bag with a count of selected repositories
            ViewBag.SelectedTransactions = SelectedTransactions.Count;

            return View(SelectedTransactions.OrderByDescending(r => r.TransactionNum));
        }
    }
}

//// GET: BankAccount/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null || _context.Accounts == null)
//    {
//        return NotFound();
//    }

//    var account = await _context.Accounts
//        .FirstOrDefaultAsync(m => m.AccountID == id);
//    if (account == null)
//    {
//        return NotFound();
//    }

//    return View(account);
//}

//// POST: BankAccount/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    if (_context.Accounts == null)
//    {
//        return Problem("Entity set 'AppDbContext.Accounts'  is null.");
//    }
//    var account = await _context.Accounts.FindAsync(id);
//    if (account != null)
//    {
//        _context.Accounts.Remove(account);
//    }

//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}


//private bool AccountExists(int id)
 //       {
 //        return _context.BankAccounts.Any(e => e.BankAccountID == id);
  //      }
   // }
//}
