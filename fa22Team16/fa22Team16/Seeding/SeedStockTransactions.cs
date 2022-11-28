
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


    public static class SeedStockTransactions
    {
        public static void SeedAllStockTransactions(AppDbContext db)
        {
            List<StockTransaction> AllStockTransactions = new List<StockTransaction>();
    


            AllStockTransactions.Add(new StockTransaction
            {
                Type = StockTransactionType.Purchase,
                StockPortfolio = db.StockPortfolios.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000024)),
                Price = 145.03m,
                NumberOfShares = 10,
                Stock = db.Stocks.FirstOrDefault(a => a.Ticker == "AAPL"),
                Date = Convert.ToDateTime("2022-04-01 00:00:00")
            }) ; 


            AllStockTransactions.Add(new StockTransaction
            {
                Type = StockTransactionType.Purchase,
                StockPortfolio = db.StockPortfolios.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000024)),
                Price = 321.36m,
                NumberOfShares = 5,
                Stock = db.Stocks.FirstOrDefault(a => a.Ticker == "DIA"),
                Date = Convert.ToDateTime("2022-04-03 00:00:00")
            }) ; 


            AllStockTransactions.Add(new StockTransaction
            {
                Type = StockTransactionType.Purchase,
                StockPortfolio = db.StockPortfolios.FirstOrDefault(a => a.AccountNumber == Convert.ToInt64(2290000024)),
                Price = 18.1m,
                NumberOfShares = 2,
                Stock = db.Stocks.FirstOrDefault(a => a.Ticker == "FLCEX"),
                Date = Convert.ToDateTime("2022-04-28 00:00:00")
            }) ; 

            //create a counter and flag to help with debugging
            int stockTransactionID = 0;

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (StockTransaction seedStockTransaction in AllStockTransactions)
                {
                    //updates the counters to get info on where the problem is
                    stockTransactionID = seedStockTransaction.StockTransactionID;

                    //try to find the artist in the database
                    StockTransaction dbStockTransaction = db.StockTransactions.FirstOrDefault(c => c.StockTransactionID == seedStockTransaction.StockTransactionID);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbStockTransaction == null)
                    {
                        //add the Artist to the database
                        db.StockTransactions.Add(seedStockTransaction);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbStockTransaction.StockPortfolio = seedStockTransaction.StockPortfolio;
                        dbStockTransaction.Type = seedStockTransaction.Type;
                        dbStockTransaction.Price = seedStockTransaction.Price;
                        dbStockTransaction.NumberOfShares = seedStockTransaction.NumberOfShares;
                        dbStockTransaction.Stock = seedStockTransaction.Stock;
                        dbStockTransaction.Date = seedStockTransaction.Date;


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
                msg.Append(" stock Transaction (stockTransactionID = ");
                msg.Append(stockTransactionID);
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
