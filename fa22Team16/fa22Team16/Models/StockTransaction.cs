using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fa22Team16.Models
{
    public enum StockTransactionType
    {
        Purchase, Sell
    }

    public class StockTransaction
    {
        public Int32 StockTransactionID { get; set; }

        [Display(Name = "Number of Shares")]
        public Int32 NumberOfShares { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Price { get; set; }

        // relational
        public StockPortfolio StockPortfolio { get; set; }

        [Display(Name = "Bank Account for Withdrawal")]
        public Int32 WithdrawalAccount { get; set; }

        [Display(Name ="Stock")]
        [Required(ErrorMessage = "Stock is required.")]
        public Stock Stock { get; set; }

        [Display(Name ="Type")]
        public StockTransactionType Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }


        [Display(Name = "Current Value")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal CurrentValue
        {
            get { return NumberOfShares * Price; }
        }

        [Display(Name = "Individual Gain")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal IndividualGain
        {
            get { return CurrentValue - (NumberOfShares * Stock.Price); }
        }

    }
}

