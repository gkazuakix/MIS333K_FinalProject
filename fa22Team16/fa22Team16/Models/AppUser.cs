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
    public class AppUser : IdentityUser
    {
        //to do: Add custom user fields - first name is included as an example
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        // just add last name for hw4

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        public List<Account> Accounts { get; set; }

        public StockPortfolio StockPortfolio { get; set; }



    }
}
