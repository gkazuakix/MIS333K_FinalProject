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
    public enum Status
    {
        Submitted, Accepted, Rejected, Adjusted
    }
    public class Dispute
    {
        // todo: Check this?
        public Int32 DisputeID { get; set; }

        [Display(Name = "Transaction")]
        public Transaction Transaction { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Status?")]
        public Status Status { get; set; }

        [Display(Name = "Correct Amount")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal CorrectAmount { get; set; }

        //[Display(Name = "Transaction")]
        //public Account Account { get; set; }

        //public List<Dispute> Dispute { get; set; }


        //[Display(Name = "Balance")]
        //public Int32 Balance { get; set; }

    }
}
