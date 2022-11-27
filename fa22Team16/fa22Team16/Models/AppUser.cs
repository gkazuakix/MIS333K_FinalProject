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
        [Required(ErrorMessage ="First Name is required.")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public String? MiddleInitial { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public String LastName { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street Address is required.")]
        public String StreetAddress { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public String City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required.")]
        public String State { get; set; }

        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Display(Name = "Address")]
        public String Address
        {
            get { return StreetAddress + ", " + City + ", " + State + " " + ZipCode; }
        }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "Birthday is required.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public List<Account> Accounts { get; set; }

        public StockPortfolio StockPortfolio { get; set; }


    }
}
