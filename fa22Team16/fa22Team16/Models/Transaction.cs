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
    public enum TransactionType
    {
        Deposit, Withdraw, Transfer, Fee
    }

    public enum Approved
    {
        Yes, No
    }

    public class Transaction
    {
        internal static readonly object BankAccount;

        public Int32 TransactionID { get; set; }

        [Display(Name = "Transaction Num")]
        public Int32 TransactionNum { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Amount { get; set; }

        [Display(Name = "Account")]
        public BankAccount? Account { get; set; }

        [Display(Name = "Stock Portfolio")]
        public StockPortfolio? StockPortfolio { get; set; }

        //[Display(Name = "From Account")]
        //[Required(ErrorMessage = "From Account is required.")]
        //public BankAccount? FromAccount { get; set; }

        public List<Dispute> Disputes { get; set; }
        //public List<BankAccount> BankAccounts { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Comments")]
        public String? Comments { get; set; }

        [Display(Name = "Approved")]
        public Approved Approved { get; set; }

        [Display(Name = "Transaction Type")]
        public TransactionType Type { get; set; }


        //[Display(Name = "Balance")]
        //public Int32 Balance { get; set; }
        public Transaction()
        {
            if (Disputes == null)
            {
                Disputes = new List<Dispute>();
            }
        }
    }
}
