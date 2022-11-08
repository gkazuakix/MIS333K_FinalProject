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
    public class Transaction
    {
        public Int32 TransactionID { get; set; }

        [Display(Name = "Amount")]
        public Int32 Amount { get; set; }

        [Display(Name = "Transaction")]
        public Account Account { get; set; }

        public List<Dispute> Dispute { get; set; }


        //[Display(Name = "Balance")]
        //public Int32 Balance { get; set; }

    }
}
