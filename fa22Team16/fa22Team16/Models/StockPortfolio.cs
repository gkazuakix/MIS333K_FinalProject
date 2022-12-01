using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fa22Team16.Models
{
    public enum StockStatus
    {
        Balanced, Unbalanced
    }

    public class StockPortfolio
    {
        public Int32 StockPortfolioID { get; set; }

        [Display(Name = "Account Number")]
        public Int64 AccountNumber { get; set; }

        [Display(Name = "User")]
        public AppUser AppUser { get; set; }

        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Gains")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Gains
        {
            get { return StockTransactions.Sum(s => s.IndividualGain); }
        }

        [Display(Name = "Fees")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Fees { get; set; }

        [Display(Name = "Available Cash")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Balance { get; set; }

        [Display(Name = "Sum of All Stock Values")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SumCurrentValue
        {
            get { return StockTransactions.Sum(s => s.CurrentValue); }
        }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Value
        {
            get { return SumCurrentValue + Gains - Fees + Balance; }
        }

        public List<StockTransaction> StockTransactions { get; set; }
        public List<Transaction> Transactions { get; set; }


        [Display(Name = "Status")]
        public StockStatus Status { get; set; }


        public StockPortfolio()
        {
            if (StockTransactions == null)
            {
                StockTransactions = new List<StockTransaction>();
            }
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
            }
        }
    }
}

