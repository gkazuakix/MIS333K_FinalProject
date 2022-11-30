
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


    public static class SeedDisputes
    {
        public static void SeedAllDisputes(AppDbContext db)
        {
            List<Dispute> AllDisputes = new List<Dispute>();
    


            AllDisputes.Add(new Dispute
            {
                Transaction = db.Transactions.FirstOrDefault(a => a.TransactionNum == 8),
                Description = "I don’t remember buying so many snacks",
                Status = Status.Submitted,
                CorrectAmount = 300.0m,
            }) ; 


            AllDisputes.Add(new Dispute
            {
                Transaction = db.Transactions.FirstOrDefault(a => a.TransactionNum == 10),
                Description = "You rapscallions are trying to steal my money!!!",
                Status = Status.Submitted ,
                CorrectAmount = 0.0m,
            }) ; 

            //create a counter and flag to help with debugging
            int disputeID = 0;

            //we are now going to add the data to the database
            //this could cause errors, so we need to put this code
            //into a Try/Catch block
            try
            {
                //loop through each of the artists
                foreach (Dispute seedDispute in AllDisputes)
                {
                    //updates the counters to get info on where the problem is
                    disputeID = seedDispute.DisputeID;

                    //try to find the artist in the database
                    Dispute dbDispute = db.Disputes.FirstOrDefault(c => c.DisputeID == seedDispute.DisputeID);

                    //if the artist isn't in the database, dbArtist will be null
                    if (dbDispute == null)
                    {
                        //add the Artist to the database
                        db.Disputes.Add(seedDispute);
                        db.SaveChanges();
                    }
                    else //the record is in the database
                    {
                        //update all the fields
                        //this isn't really needed for artist because it only has one field
                        //but you will need it to re-set seeded data with more fields
                        dbDispute.Transaction = seedDispute.Transaction;
                        dbDispute.Description = seedDispute.Description;
                        dbDispute.Status = seedDispute.Status;
                        dbDispute.CorrectAmount = seedDispute.CorrectAmount;
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
                msg.Append(" dispute  (DisputeID = ");
                msg.Append(disputeID);
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
