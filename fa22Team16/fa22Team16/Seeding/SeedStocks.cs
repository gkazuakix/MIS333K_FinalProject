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


    public static class SeedStocks
    {
        public static void SeedAllStocks(AppDbContext db)
        {
            List<Stock> AllStocks = new List<Stock>();    


            AllStocks.Add(new Stock
            {
                Ticker = "GOOG",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Alphabet Inc.",
                Price = 87.07m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "AAPL",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Apple Inc.",
                Price = 145.03m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "AMZN",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Amazon.com Inc.",
                Price = 92.12m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "LUV",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Southwest Airlines",
                Price = 36.5m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "TXN",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Texas Instruments",
                Price = 158.49m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "HSY",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "The Hershey Company",
                Price = 235.11m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "V",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Visa Inc.",
                Price = 200.95m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "NKE",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Nike",
                Price = 90.3m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "VWO",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "ETF"),
                Name = "Vanguard Emerging Markets ETF",
                Price = 35.77m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "CORN",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Futures"),
                Name = "Corn",
                Price = 27.35m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "FXAIX",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Mutual Fund"),
                Name = "Fidelity 500 Index Fund",
                Price = 133.88m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "F",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Ford Motor Company",
                Price = 13.06m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "BAC",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Bank of America Corporation",
                Price = 36.09m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "VNQ",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "ETF"),
                Name = "Vanguard REIT ETF",
                Price = 80.67m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "NSDQ",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Index Fund"),
                Name = "Nasdaq Index Fund",
                Price = 10524.8m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "KMX",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "CarMax, Inc.",
                Price = 62.36m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "DIA",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Index Fund"),
                Name = "Dow Jones Industrial Average Index Fund",
                Price = 321.36m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "SPY",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Index Fund"),
                Name = "S&P 500 Index Fund",
                Price = 374.87m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "BEN",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Ordinary"),
                Name = "Franklin Resources, Inc.",
                Price = 22.56m,
            }) ; 


            AllStocks.Add(new Stock
            {
                Ticker = "FLCEX",
                StockType = db.StockTypes.FirstOrDefault(s => s.TypeName == "Mutual Fund"),
                Name = "Fidelity Large Cap Core Enhanced Index Fund",
                Price = 18.1m,
            }) ; 

            //create a counter and flag to help with debugging
            int intStockID = 0;
            String strTicker = "Start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (Stock seedStock in AllStocks)
                {
                    //updates the counters to get info on where the problem is
                    intStockID = seedStock.StockID;
                    strTicker = seedStock.Ticker;

                    //try to find the artist in the database
                    Stock dbStock = db.Stocks.FirstOrDefault(c => c.Ticker == seedStock.Ticker);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbStock == null)
                    {
                        //add the Artist to the database
                        db.Stocks.Add(seedStock);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbStock.Ticker = seedStock.Ticker;
                        dbStock.Name = seedStock.Name;
                        dbStock.StockType = seedStock.StockType;
                        dbStock.Price = seedStock.Price;

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
                msg.Append(strTicker);
                msg.Append(" stock (StockID = ");
                msg.Append(intStockID);
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
