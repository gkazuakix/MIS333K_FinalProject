
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


    public static class SeedStockType
    {
        public static void SeedAllStockType(AppDbContext db)
        {
            List<StockType> AllStockTypes = new List<StockType>();
    


            AllStockTypes.Add(new StockType
            {
                TypeName = "Ordinary",
                
            }) ; 


            AllStockTypes.Add(new StockType
            {
                TypeName = "ETF",
                
            }) ; 


            AllStockTypes.Add(new StockType
            {
                TypeName = "Futures",
                
            }) ; 


            AllStockTypes.Add(new StockType
            {
                TypeName = "Mutual Fund",
                
            }) ; 


            AllStockTypes.Add(new StockType
            {
                TypeName = "Index Fund",
                
            }) ; 

            //create a counter and flag to help with debugging
            string stockTypeName = "start";

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (StockType seedStockType in AllStockTypes)
                {
                    //updates the counters to get info on where the problem is
                    stockTypeName = seedStockType.TypeName;

                    //try to find the artist in the database
                    StockType dbStockType = db.StockTypes.FirstOrDefault(c => c.TypeName == seedStockType.TypeName);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbStockType == null)
                    {
                        //add the Artist to the database
                        db.StockTypes.Add(seedStockType);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbStockType.TypeName = seedStockType.TypeName;
                        
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
                msg.Append(" stocktype  (Stock Type Name = ");
                msg.Append(stockTypeName);
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
