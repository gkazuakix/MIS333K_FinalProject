using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fa22Team16.Models
{ 
    public class SearchViewModel
    {
        [Display(Name = "Search by Comments:")]
        public String? Comments { get; set; }

        [Display(Name = "Search by Transaction Type:")]
        public TransactionType? Type { get; set; }

        [Display(Name = "Minimum Amount:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal? MinAmount { get; set; }

        [Display(Name = "Maximum Amount:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal? MaxAmount { get; set; }

        [Display(Name = "Search by Transaction Number:")]
        public Int32? TransactionNum { get; set; }

        [Display(Name = "Earliest Date:")]
        public DateTime? MinDate { get; set; }

        [Display(Name = "Latest Date:")]
        public DateTime? MaxDate { get; set; }
    }
}

