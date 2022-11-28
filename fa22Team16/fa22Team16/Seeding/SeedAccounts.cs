
using fa22Team16.DAL;
using fa22Team16.Models;
using fa22Team16.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace fa22Team16.Seeding
{


    public static class SeedBankAccounts
    {
        public static void SeedAllBankAccounts(AppDbContext db)
        {
            List<BankAccount> AllBankAccounts = new List<BankAccount>();    


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000002),
                appUser = db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com"),
                AccountName = "William's Savings",
                AccountType = AccountType.Savings,
                Balance = 40035.5m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000003),
                appUser = db.Users.FirstOrDefault(u => u.Email == "smartinmartin.Martin@aool.com"),
                AccountName = "Gregory's Checking",
                AccountType = AccountType.Checking,
                Balance = 39779.49m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000004),
                appUser = db.Users.FirstOrDefault(u => u.Email == "avelasco@yaho.com"),
                AccountName = "Allen's Checking",
                AccountType = AccountType.Checking,
                Balance = 47277.33m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000005),
                appUser = db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net"),
                AccountName = "Reagan's Checking",
                AccountType = AccountType.Checking,
                Balance = 70812.15m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000006),
                appUser = db.Users.FirstOrDefault(u => u.Email == "nelson.Kelly@aool.com"),
                AccountName = "Kelly's Savings",
                AccountType = AccountType.Savings,
                Balance = 21901.97m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000007),
                appUser = db.Users.FirstOrDefault(u => u.Email == "erynrice@aool.com"),
                AccountName = "Eryn's Checking",
                AccountType = AccountType.Checking,
                Balance = 70480.99m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000008),
                appUser = db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net"),
                AccountName = "Jake's Savings",
                AccountType = AccountType.Savings,
                Balance = 7916.4m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000010),
                appUser = db.Users.FirstOrDefault(u => u.Email == "jeff@ggmail.com"),
                AccountName = "Jeffrey's Savings",
                AccountType = AccountType.Savings,
                Balance = 69576.83m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000012),
                appUser = db.Users.FirstOrDefault(u => u.Email == "erynrice@aool.com"),
                AccountName = "Eryn's Checking 2",
                AccountType = AccountType.Checking,
                Balance = 30279.33m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000013),
                appUser = db.Users.FirstOrDefault(u => u.Email == "mackcloud@pimpdaddy.com"),
                AccountName = "Jennifer's IRA",
                AccountType = AccountType.IRA,
                Balance = 53177.21m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000014),
                appUser = db.Users.FirstOrDefault(u => u.Email == "ss34@ggmail.com"),
                AccountName = "Sarah's Savings",
                AccountType = AccountType.Savings,
                Balance = 11958.08m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000015),
                appUser = db.Users.FirstOrDefault(u => u.Email == "tanner@ggmail.com"),
                AccountName = "Jeremy's Savings",
                AccountType = AccountType.Savings,
                Balance = 72990.47m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000016),
                appUser = db.Users.FirstOrDefault(u => u.Email == "liz@ggmail.com"),
                AccountName = "Elizabeth's Savings",
                AccountType = AccountType.Savings,
                Balance = 7417.2m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000017),
                appUser = db.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                AccountName = "Allen's IRA",
                AccountType = AccountType.IRA,
                Balance = 75866.69m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000019),
                appUser = db.Users.FirstOrDefault(u => u.Email == "mclarence@aool.com"),
                AccountName = "Clarence's Savings",
                AccountType = AccountType.Savings,
                Balance = 1642.82m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000020),
                appUser = db.Users.FirstOrDefault(u => u.Email == "ss34@ggmail.com"),
                AccountName = "Sarah's Checking",
                AccountType = AccountType.Checking,
                Balance = 84421.45m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000021),
                appUser = db.Users.FirstOrDefault(u => u.Email == "cbaker@freezing.co.uk"),
                AccountName = "CBaker's Checking",
                AccountType = AccountType.Checking,
                Balance = 4523.0m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000022),
                appUser = db.Users.FirstOrDefault(u => u.Email == "cbaker@freezing.co.uk"),
                AccountName = "CBaker's Savings",
                AccountType = AccountType.Savings,
                Balance = 1000.0m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000023),
                appUser = db.Users.FirstOrDefault(u => u.Email == "cbaker@freezing.co.uk"),
                AccountName = "CBaker's IRA",
                AccountType = AccountType.IRA,
                Balance = 1000.0m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000025),
                appUser = db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com"),
                AccountName = "C-dawg's Checking",
                AccountType = AccountType.Checking,
                Balance = 4.04m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000026),
                appUser = db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com"),
                AccountName = "C-dawg's Savings",
                AccountType = AccountType.Savings,
                Balance = 350.0m,
                ActiveStatus = true,
            }) ; 


            AllBankAccounts.Add(new BankAccount
            {
                AccountNumber = Convert.ToInt64(2290000027),
                appUser = db.Users.FirstOrDefault(u => u.Email == "mgar@aool.com"),
                AccountName = "Margaret's IRA",
                AccountType = AccountType.IRA,
                Balance = 3500.0m,
                ActiveStatus = true,
            }) ; 

            //create a counter and flag to help with debugging
            Int64 intAccountNum = 0;
            String strAccountName = "Start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (BankAccount seedBankAccount in AllBankAccounts)
                {
                    //updates the counters to get info on where the problem is
                    intAccountNum = seedBankAccount.AccountNumber;
                    strAccountName = seedBankAccount.AccountName;


                    //try to find the artist in the database
                    BankAccount dbAccount = db.BankAccounts.FirstOrDefault(c => c.AccountNumber == seedBankAccount.AccountNumber);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbAccount == null)
                    {
                        //add the Artist to the database
                        db.BankAccounts.Add(seedBankAccount);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbAccount.AccountName = seedBankAccount.AccountName;
                        dbAccount.appUser = seedBankAccount.appUser;
                        dbAccount.AccountType = seedBankAccount.AccountType;
                        dbAccount.Balance = seedBankAccount.Balance;
                        dbAccount.ActiveStatus = seedBankAccount.ActiveStatus;
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex) //something about adding to the database caused a problem
            {
                //create a new instance of the string builder to make building out 
                //our message neater - we don't want a REALLY long line of code for this
                //so we break it up into several lines
                StringBuilder msg = new StringBuilder();

                msg.Append("There was an error adding the ");
                msg.Append(strAccountName);
                msg.Append(" account");

                //have this method throw the exception to the calling method
                //this code wraps the exception from the database with the 
                //custom message we built above. The original error from the
                //database becomes the InnerException
                throw new Exception(msg.ToString(), ex);
            }
  
        }
    }
        
}
