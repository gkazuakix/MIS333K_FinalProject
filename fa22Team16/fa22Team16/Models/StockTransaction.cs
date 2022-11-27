using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fa22Team16.Models
{
    public class StockTransaction
    {
        public Int32 StockTransactionID { get; set; }

        [Display(Name = "Number of Shares")]
        public Int32 NumberOfShares { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Price { get; set; }

        public StockPortfolio StockPortfolio { get; set; }

        [Display(Name ="Stock")]
        [Required(ErrorMessage = "Stock is required.")]
        public Stock Stock { get; set; }

        //[Display(Name = "Number of Shares")]
        //public Int32 NumberOfShares { get; set; }
    }
}

