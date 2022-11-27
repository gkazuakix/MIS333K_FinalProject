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
              return View(await _context.Accounts.ToListAsync());
        }

        // GET: BankAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("AccountID,AccountNumber,Balance,AccountType,ActiveStatus")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: BankAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: BankAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,AccountNumber,Balance,AccountType,ActiveStatus")] Account account)
        {
            if (id != account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountID))
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
            return View(account);
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

        private bool AccountExists(int id)
        {
          return _context.Accounts.Any(e => e.AccountID == id);
        }
    }
}
