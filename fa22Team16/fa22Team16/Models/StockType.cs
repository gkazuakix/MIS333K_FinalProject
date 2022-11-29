using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

 namespace fa22Team16.Models
{

    public class StockType
    {
        public Int32 StockTypeID { get; set; }

        // this is synonomous to languages in HW3
        [Display(Name ="Type of Stock")]
        [Required(ErrorMessage = "The type of stock is required.")]
        public String TypeName { get; set; }

        public List<Stock> Stocks { get; set; }

        public StockType()
        {
            if (Stocks == null)
            {
                Stocks = new List<Stock>();
            }
        }
    }
}

