using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fa22Team16.Models
{

    public class Stock
    {
        public Int32 StockID { get; set; }

        [Display(Name = "Ticker Symbol")]
        [Required(ErrorMessage = "Ticker Symbol is required.")]
        public String Ticker { get; set; }

        [Display(Name = "Stock Name")]
        [Required(ErrorMessage = "Stock Name is required.")]
        public String Name { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Price { get; set; }



        //[Display(Name = "Fees")]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        //public Decimal Fees { get; set; }


        [Display(Name ="Stock Type")]
        [Required(ErrorMessage = "Stock Type is required.")]
        public StockType StockType { get; set; }

        public List<StockTransaction> StockTransactions { get; set;}

        public Stock()
        {
            if (StockTransactions == null)
            {
                StockTransactions = new List<StockTransaction>();
            }
        }
    }
}

