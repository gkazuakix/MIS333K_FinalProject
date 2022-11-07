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
    public enum AccountTypw
    {
        Savings, Checkings, IRA
    }

    public class Account
    {
       

        public AppUser appUser { get; set; }

        public List<Transaction> Transactions { get; set; }


        [Display(Name = "Balance")]
        public Int32 Balance { get; set; }

    }
}
