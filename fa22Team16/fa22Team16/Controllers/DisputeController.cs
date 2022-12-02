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
using System.Data.Common;

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
            if (User.IsInRole("Customer"))
            {
                return View(await _context.Disputes.Include(o => o.Transaction).Include(o => o.Transaction.Account.appUser).Where(o => o.Transaction.Account.appUser.UserName == User.Identity.Name).ToListAsync());
            }
            return View(await _context.Disputes.Include(o => o.Transaction).Include(o => o.Transaction.Account.appUser).ToListAsync());
        }

        // GET: Dispute/ManageDispute
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageDispute()
        {
            List<Dispute> Disputes = _context.Disputes.Include(o => o.Transaction).Include(o => o.Transaction.Account.appUser).Where(d => d.Status == Status.Submitted).ToList();
            return View(Disputes);
        }

        // Get:Dispute/SeeAllDispute
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SeeAllDispute()
        {
            List<Dispute> Disputes = _context.Disputes.Include(o => o.Transaction).Include(o => o.Transaction.Account.appUser).ToList();
            return View(Disputes);
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
        public async Task<IActionResult> Create()
        {
            {
                ViewBag.AllTransactions = GetAllTransactionsSelectList();
                return View();
            }
        }


        //[Authorize(Roles = "Customer")]
        //public IActionResult Create()
        //{
        //    ViewBag.AllTransactions = GetAllTransactionsSelectList();
        //    return View();
        //}

        // POST: Dispute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(Dispute dispute, int SelectedTransaction)

        {
            if (ModelState.IsValid)
            {
                //Dispute newDispute = new Dispute();
                dispute.Transaction = _context.Transactions.FirstOrDefault(t => t.TransactionID == SelectedTransaction);
                dispute.Status = Status.Submitted;
                _context.Add(dispute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dispute);
            // Transaction dbTransaction = _context.Transactions.Include(t => t.Disputes.FirstOrDefault(t => t.TransactionID == transactionID);
            //foreach (Dispute dis in dbTransaction.Disputes)
            //{ 
            //    if (dis.DisputeStatus == DisputeStatus.Accepted)
            //    {
            //        return View("NoDisputes");
            //    }
            // dispute.DisputeTransaction = dbTransaction;
            // Dispute dispute = new Dispute();
            // Transaction dbTransaction = _context.Transactions.FirstOrDefault(t => t.TransactionID == Id);
            // dispute.CorrectAmount = dbTransaction.TransactionAmount;
            // dispute.CorrectAmount = dbTransaction.TransactionAmount;
            // dispute.DisputeTransaction = dbTransaction;
            //return View(Dispute);
            //_context.Add(dispute);
            //await _context.SaveChangesAsync();
        }
       

      


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Customer")]
        //public async Task<IActionResult> Create([Bind("DisputeID,Transaction,Description,Status,CorrectAmount,RequestDeleteTransaction")] Dispute dispute)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View(dispute);
        //    }

        //    _context.Add(dispute);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Dispute", new { dispute.DisputeID });

        //}

        //public async Task<SelectList> GetAllTransactionsSelectList()
        //{
        //    List<Transaction> allTransactions = new List<Transaction>();

        //    foreach (Transaction dbTransaction in _context.Transactions)
        //    {
        //        if (dbTransaction.Account.appUser.UserName == User.Identity.Name)
        //        {
        //            allTransactions.Add(dbTransaction);
        //        }           
        //    }
        //    SelectList slAllTransactions = new SelectList(allTransactions, nameof(Transaction.TransactionID), nameof(Transaction.TransactionNum));

        //    return slAllTransactions;


        //}


        // GET: Dispute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return NotFound();
            }

            var dispute = _context.Disputes.Include(o => o.Transaction).FirstOrDefault(o => o.DisputeID == id);

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
        public async Task<IActionResult> Edit(int id, [Bind("DisputeID,Transaction,Description,Status,CorrectAmount,RequestDeleteTransaction")] Dispute dispute)
        {
            if (id != dispute.DisputeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Dispute editeddispute = _context.Disputes.Include(d => d.Transaction).Include(d => d.Transaction.Account).Include(d => d.Transaction.Account.appUser).FirstOrDefault(d => d.DisputeID == dispute.DisputeID);
                    editeddispute.Status = dispute.Status;
                    if (dispute.Status == Status.Accepted)
                    {
                        Decimal balancechange = 0;
                        if (editeddispute.Transaction.Type == TransactionType.Deposit)
                        {
                            balancechange = (editeddispute.Transaction.Amount - editeddispute.CorrectAmount);
                            editeddispute.Transaction.Account.Balance = editeddispute.Transaction.Account.Balance - balancechange;
                        }
                        else if (editeddispute.Transaction.Type == TransactionType.Transfer)
                        {
                            balancechange = (editeddispute.Transaction.Amount + editeddispute.CorrectAmount);
                            editeddispute.Transaction.Account.Balance = editeddispute.Transaction.Account.Balance + balancechange;
                        }

                        editeddispute.Transaction.Amount = editeddispute.CorrectAmount;
                        await _context.SaveChangesAsync();
                        Utilities.EmailMessaging.SendEmail(editeddispute.Transaction.Account.appUser.Email, "Your dispute was resolved", "You have successfully petitioned your transaction and got your dispute accepted");
                        return RedirectToAction(nameof(ManageDispute));
                    }
                    else if (dispute.Status == Status.Adjusted)
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(ManageDispute));
                        // return RedirectToAction(nameof(EditTransactionAmount));
                    }
                    else if (dispute.Status == Status.Rejected)
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(ManageDispute));
                    }
                }
                //try
                //{
                //    _context.Update(dispute);
                    
                
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
            }
            return View(dispute);
        }

        //public async Task<IActionResult> EditTransactionAmount(int? id)
        //{
        //    //var dispute = _context.Disputes.FirstOrDefault(o => o.DisputeID == id);
        //    ETAViewModel etavm = new ETAViewModel();
        //    if (id != null)
        //    {
        //        etavm.DisputeID = id;
        //    }
        //    return View(etavm);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditTransactionAmount(ETAViewModel etavm)
        //{
        //    etavm.Transaction
        //    Dispute newDispute = _context.Disputes.Include(o => o.Transaction).FirstOrDefault(o => o.DisputeID == dispute.DisputeID);
        //    newDispute.Transaction.Amount = correctamount;
        //    return RedirectToAction(nameof(ManageDispute));


        //}


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
        private SelectList GetAllTransactionsSelectList()
        {
            //Get the list of months from the database
            List<Transaction> transactionList = _context.Transactions.Where(o => o.Account.appUser.UserName == User.Identity.Name).ToList();
            //List<BankAccount> bankAccountList = new List<BankAccount>();

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
            SelectList transactionSelectList = new SelectList(transactionList, nameof(Transaction.TransactionID), nameof(Transaction.TransactionNum));

            //return the electList
            return transactionSelectList;
        }

            private bool DisputeExists(int id)
        {
          return _context.Disputes.Any(e => e.DisputeID == id);
        }
    }
}
