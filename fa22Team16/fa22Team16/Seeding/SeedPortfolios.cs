
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


    public static class SeedPortfolio
    {
        public static void SeedAllPortfolios(AppDbContext db)
        {
            List<StockPortfolio> AllPortfolios = new List<StockPortfolio>();
    


            AllPortfolios.Add(new StockPortfolio
            {
                AccountNumber = Convert.ToInt64(2290000001.0),
                AppUser = db.Users.FirstOrDefault(s => s.Email == "Dixon@aool.com"),
                AccountName = "Shan's Stock",
                Balance = 0.0m,
                Status = StockStatus.Unbalanced
            }) ; 


            AllPortfolios.Add(new StockPortfolio
            {
                AccountNumber = Convert.ToInt64(2290000009.0),
                AppUser = db.Users.FirstOrDefault(s => s.Email == "mb@aool.com"),
                AccountName = "Michelle's Stock",
                Balance = 8888.88m,
                Status = StockStatus.Unbalanced
            }) ; 


            AllPortfolios.Add(new StockPortfolio
            {
                AccountNumber = Convert.ToInt64(2290000011.0),
                AppUser = db.Users.FirstOrDefault(s => s.Email == "nelson.Kelly@aool.com"),
                AccountName = "Kelly's Stock",
                Balance = 420.0m,
                Status = StockStatus.Unbalanced
            }) ; 


            AllPortfolios.Add(new StockPortfolio
            {
                AccountNumber = Convert.ToInt64(2290000018.0),
                AppUser = db.Users.FirstOrDefault(s => s.Email == "johnsmith187@aool.com"),
                AccountName = "John's Stock",
                Balance = 0.0m,
                Status = StockStatus.Unbalanced
            }) ; 


            AllPortfolios.Add(new StockPortfolio
            {
                AccountNumber = Convert.ToInt64(2290000024.0),
                AppUser = db.Users.FirstOrDefault(s => s.Email == "cbaker@freezing.co.uk"),
                AccountName = "CBaker's Stock",
                Balance = 6900.0m,
                Status = StockStatus.Unbalanced
            }) ; 

            //create a counter and flag to help with debugging
            int intPortfolioID = 0;
            String strAccountName = "Start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (StockPortfolio seedPortfolio in AllPortfolios)
                {
                    //updates the counters to get info on where the problem is
                    intPortfolioID = seedPortfolio.StockPortfolioID;
                    strAccountName = seedPortfolio.AccountName;

                    //try to find the artist in the database
                    StockPortfolio dbPortfolio = db.StockPortfolios.FirstOrDefault(c => c.AccountNumber == seedPortfolio.AccountNumber);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbPortfolio == null)
                    {
                        //add the Artist to the database
                        db.StockPortfolios.Add(seedPortfolio);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbPortfolio.AppUser = seedPortfolio.AppUser;
                        dbPortfolio.AccountName = seedPortfolio.AccountName;
                        dbPortfolio.Balance = seedPortfolio.Balance;
                        dbPortfolio.Status = StockStatus.Unbalanced;

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
                msg.Append(" portfolio (PortfolioID = ");
                msg.Append(intPortfolioID);
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
