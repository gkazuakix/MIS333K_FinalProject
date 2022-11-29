
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


    public static class SeedTransactions
    {
        public static void SeedAllTransactions(AppDbContext db)
        {
            List<Transaction> AllTransactions = new List<Transaction>();
    

            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(1.0),
                Type = TransactionType.Deposit,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000021.0)),
                Amount = 4000.0m, 
                Date = Convert.ToDateTime("2022-01-15 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
             });
                
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(2.0),
                Type = TransactionType.Deposit,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000022.0)),
                Amount = 2200.0m, 
                Date = Convert.ToDateTime("2022-03-05 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "This transaction went so well! I will be using this bank again for sure!!"
             });
                
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(3.0),
                Type = TransactionType.Deposit,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000022.0)),
                Amount = 6000.0m, 
                Date = Convert.ToDateTime("2022-03-09 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
             });
                
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(4.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000021.0)),
                Amount = 1200.0m, 
                Date = Convert.ToDateTime("2022-04-14 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "Jacob Foster has a GPA of 1.92. LOL"
            });
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(4.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000022.0)),
                Amount = -1200.0m, 
                Date = Convert.ToDateTime("2022-04-14 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "Jacob Foster has a GPA of 1.92. LOL"
            });
    
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(5.0),
                Type = TransactionType.Withdraw,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000022.0)),
                Amount = -352.0m, 
                Date = Convert.ToDateTime("2022-04-21 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "Longhorn Bank is my favorite bank! I couldn't dream of putting my money anywhere else."
             });
                
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(6.0),
                Type = TransactionType.Deposit,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000023.0)),
                Amount = 1500.0m, 
                Date = Convert.ToDateTime("2022-03-08 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
             });
                
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(7.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000021.0)),
                Amount = 3000.0m, 
                Date = Convert.ToDateTime("2022-04-20 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
            });
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(7.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000024.0)),
                Amount = -3000.0m, 
                Date = Convert.ToDateTime("2022-04-20 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
            });
    
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(8.0),
                Type = TransactionType.Withdraw,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000021.0)),
                Amount = -578.12m, 
                Date = Convert.ToDateTime("2022-04-19 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "K project snack expenses"
             });
                
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(9.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000025.0)),
                Amount = 52.0m, 
                Date = Convert.ToDateTime("2022-04-29 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
            });
    AllTransactions.Add(new Transaction
    {
        TransactionNum = Convert.ToInt32(9.0),
                Type = TransactionType.Transfer,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000026.0)),
                Amount = -52.0m, 
                Date = Convert.ToDateTime("2022-04-29 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "nan"
            });
    
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(10.0),
                Type = TransactionType.Withdraw,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000020.0)),
                Amount = -4000.0m, 
                Date = Convert.ToDateTime("2022-03-07 00:00:00"), 
                Approved = Approved.Yes,
                Comments = "This is totally not fraudulent 0_o"
             });
                
            AllTransactions.Add(new Transaction
            {
                TransactionNum = Convert.ToInt32(11.0),
                Type = TransactionType.Deposit,
                Account = db.BankAccounts.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000016.0)),
                Amount = 6000.0m, 
                Date = Convert.ToDateTime("2022-05-01 00:00:00"), 
                Approved = Approved.No,
                Comments = "I got this money from my new business at the Blue Cat Lodge"
             });
                
            //create a counter and flag to help with debugging
            int intTransactionNum = 0;

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (Transaction seedTransaction in AllTransactions)
                {
                    //updates the counters to get info on where the problem is
                    intTransactionNum = seedTransaction.TransactionID;

                    //try to find the artist in the database
                    Transaction dbTransaction = db.Transactions.FirstOrDefault(c => c.TransactionID == seedTransaction.TransactionID);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbTransaction == null)
                    {
                        //add the Artist to the database
                        db.Transactions.Add(seedTransaction);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbTransaction.Amount = seedTransaction.Amount;
                        dbTransaction.Account = seedTransaction.Account;
                        dbTransaction.Date = seedTransaction.Date;
                        dbTransaction.Comments = seedTransaction.Comments;
                        dbTransaction.Approved = seedTransaction.Approved;
                        dbTransaction.Type = seedTransaction.Type;
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
                msg.Append(" transaction (TransactionID = ");
                msg.Append(intTransactionNum);
                msg.Append(")");

                //have this method throw the exception to the calling method
                //this code wraps the exception from the database with the 
                //custom message we built above. The original error from the
                //database becomes the InnerException
                throw new Exception(msg.ToString(), ex);
            }
  
        }
    }
        
}
