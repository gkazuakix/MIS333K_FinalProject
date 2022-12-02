using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//to do: Change this namespace to match your project
namespace fa22Team16.Models
{ 
    //NOTE: This is the view model used to allow the user to login
    //The user only needs teh email and password to login
    public class DepositCreateViewModel
    {
        public Int32 TransactionID { get; set; }

        public Int32 TransactionNum { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Amount { get; set; }

        //[Display(Name = "Account")]
        public BankAccount? Account { get; set; }

        [Display(Name = "Account Name")]
        public String? AccountName { get; set; }

        public Approved Approved { get; set; }

        //[Display(Name = "Stock Portfolio")]
        //public StockPortfolio? StockPortfolio { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Comments")]
        public String? Comments { get; set; }
    }

    public class WithdrawCreateViewModel
    {
        public Int32 TransactionID { get; set; }

        public Int32 TransactionNum { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Amount { get; set; }

        //[Display(Name = "Account")]
        public BankAccount? Account { get; set; }

        [Display(Name = "Account Name")]
        public String? AccountName { get; set; }

        public Approved Approved { get; set; }

        //[Display(Name = "Stock Portfolio")]
        //public StockPortfolio? StockPortfolio { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Comments")]
        public String? Comments { get; set; }
    }

    ////NOTE: This is the view model used to register a user
    ////When the user registers, they only need to specify the
    ////properties listed in this model
    //public class RegisterViewModel
    //{   
    //    //NOTE: Here is the property for email
    //    [Required]
    //    [EmailAddress]
    //    [Display(Name = "Email")]
    //    public string Email { get; set; }

    //    //NOTE: Here is the property for phone number
    //    [Required(ErrorMessage = "Phone number is required")]
    //    [Phone]
    //    [Display(Name = "Phone Number")]
    //    public string PhoneNumber { get; set; }


    //    //to do: Add any fields that you need for creating a new user
    //    //First name is provided as an example
    //    [Required(ErrorMessage = "First name is required.")]
    //    [Display(Name = "First Name")]
    //    public String FirstName { get; set; }

    //    [Required(ErrorMessage = "Last name is required.")]
    //    [Display(Name = "Last Name")]
    //    public String LastName { get; set; }


    //    [Display(Name = "Middle Initial")]
    //    public String MiddleInitial { get; set; }

    //    [Required(ErrorMessage = "Street address is required.")]
    //    [Display(Name = "Street address")]
    //    public String StreetAddress { get; set; }

    //    [Display(Name = "City")]
    //    [Required(ErrorMessage = "City is required.")]
    //    public String City { get; set; }

    //    [Display(Name = "State")]
    //    [Required(ErrorMessage = "State is required.")]
    //    public String State { get; set; }

    //    [Display(Name = "Zip Code")]
    //    public String ZipCode { get; set; }

    //    [Display(Name = "Birthday")]
    //    [Required(ErrorMessage = "Birthday is required.")]
    //    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    //    public DateTime Birthday { get; set; }


    //    //NOTE: Here is the logic for putting in a password
    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string ConfirmPassword { get; set; }
    //}

    ////NOTE: This is the view model used to allow the user to 
    ////change their password
    //public class ChangePasswordViewModel
    //{
    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Current password")]
    //    public string OldPassword { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "New password")]
    //    public string NewPassword { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm new password")]
    //    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    //    public string ConfirmPassword { get; set; }
    //}   

    ////NOTE: This is the view model used to display basic user information
    ////on the index page
    //public class IndexViewModel
    //{
    //    public bool HasPassword { get; set; }
    //    public String UserName { get; set; }
    //    public String Email { get; set; }
    //    public String UserID { get; set; }
    //}

    //public class UserProfileEdit
    //{

    //    public String FirstName { get; set; }

    //    public String? MiddleInitial { get; set; }


    //    public String LastName { get; set; }

    //    public String StreetAddress { get; set; }

    //    public String PhoneNumber { get; set; }



    //    public String City { get; set; }

    //    public String State { get; set; }

    //    public String ZipCode { get; set; }
    //}
}
