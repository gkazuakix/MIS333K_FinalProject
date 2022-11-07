using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fa22Team16.Models
{
    public class StockPortfolio
    {
        [Display(Name = "User")]
        public AppUser AppUser { get; set; }
       
        public List<StockTransaction> StockTransactions { get; set; }
    }
}

