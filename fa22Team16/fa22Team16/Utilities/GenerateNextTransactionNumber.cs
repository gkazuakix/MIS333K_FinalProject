using fa22Team16.DAL;
using System;
using System.Linq;


namespace fa22Team16.Utilities
{
    public static class GenerateNextTransactionNumber
    {
        public static Int32 GetNextTransactionNumber(AppDbContext _context)
        {
            //set a constant to designate where the registration numbers 
            //should start
            const Int32 START_NUMBER = 0;

            Int32 intMaxTransactionNumber; //the current maximum course number
            Int32 intNextTransactionNumber; //the course number for the next class

            if (_context.Transactions.Count() == 0) //there are no registrations in the database yet
            {
                intMaxTransactionNumber = START_NUMBER; //registration numbers start at 101
            }
            else
            {
                intMaxTransactionNumber = _context.Transactions.Max(c => c.TransactionNum); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxTransactionNumber < START_NUMBER)
            {
                intMaxTransactionNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextTransactionNumber = intMaxTransactionNumber + 1;

            //return the value
            return intNextTransactionNumber;
        }

    }
}