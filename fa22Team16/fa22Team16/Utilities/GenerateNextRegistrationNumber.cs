using fa22Team16.DAL;
using System;
using System.Linq;


namespace fa22Team16.Utilities
{
    public static class GenerateNextAccountNumber
    {
        public static Int64 GetNextAccountNumber(AppDbContext _context)
        {
            //set a constant to designate where the registration numbers 
            //should start
            const Int64 START_NUMBER = 2290000001;

            Int64 intMaxAccountNumber; //the current maximum course number
            Int64 intNextAccountNumber; //the course number for the next class

            if (_context.Accounts.Count() == 0) //there are no registrations in the database yet
            {
                intMaxAccountNumber = START_NUMBER; //registration numbers start at 101
            }
            else
            {
                intMaxAccountNumber = _context.Accounts.Max(c => c.AccountNumber); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxAccountNumber < START_NUMBER)
            {
                intMaxAccountNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextAccountNumber = intMaxAccountNumber + 1;

            //return the value
            return intNextAccountNumber;
        }

    }
}