using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//to do : Make this namespace match your project name
namespace fa22Team16.Models
{
    public enum AccountType
    {
        Savings, Checking, IRA
    }
    public class BankAccount
    {
       
        public Int32 BankAccountID { get; set; }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Account Number is required.")]
        public Int64 AccountNumber { get; set; }

        public AppUser appUser { get; set; }

        public List<Transaction> Transactions { get; set; }

        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Balance { get; set; }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }

        [Display(Name = "Active Status")]
        public Boolean ActiveStatus { get; set; }

        public BankAccount()
        {
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
            }
        }
    }
}
