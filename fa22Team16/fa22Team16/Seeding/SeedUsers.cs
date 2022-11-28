
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

    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();


            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cbaker@freezing.co.uk",
                    Email = "cbaker@freezing.co.uk",
                    PhoneNumber = "5125571146.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    MiddleInitial = "L",
                    LastName = "Baker",
                    StreetAddress = "1245 Lake Austin Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78733",
                    Birthday = Convert.ToDateTime("1991-02-07 00:00:00"),
                    ActiveStatus = true
                },
                Password = "gazing",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mb@aool.com",
                    Email = "mb@aool.com",
                    PhoneNumber = "2102678873.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Michelle",
                    MiddleInitial = "nan",
                    LastName = "Banks",
                    StreetAddress = "1300 Tall Pine Lane",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78261",
                    Birthday = Convert.ToDateTime("1990-06-23 00:00:00"),
                    ActiveStatus = true
                },
                Password = "banquet",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "fd@aool.com",
                    Email = "fd@aool.com",
                    PhoneNumber = "8175659699.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Franco",
                    MiddleInitial = "V",
                    LastName = "Broccolo",
                    StreetAddress = "62 Browning Rd",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77019",
                    Birthday = Convert.ToDateTime("1986-05-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "666666.0",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wendy@ggmail.com",
                    Email = "wendy@ggmail.com",
                    PhoneNumber = "5125943222.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wendy",
                    MiddleInitial = "L",
                    LastName = "Chang",
                    StreetAddress = "202 Bellmont Hall",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78713",
                    Birthday = Convert.ToDateTime("1964-12-21 00:00:00"),
                    ActiveStatus = true
                },
                Password = "clover",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "limchou@yaho.com",
                    Email = "limchou@yaho.com",
                    PhoneNumber = "2107724599.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lim",
                    MiddleInitial = "nan",
                    LastName = "Chou",
                    StreetAddress = "1600 Teresa Lane",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78266",
                    Birthday = Convert.ToDateTime("1950-06-14 00:00:00"),
                    ActiveStatus = true
                },
                Password = "austin",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "Dixon@aool.com",
                    Email = "Dixon@aool.com",
                    PhoneNumber = "2142643255.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Shan",
                    MiddleInitial = "D",
                    LastName = "Dixon",
                    StreetAddress = "234 Holston Circle",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75208",
                    Birthday = Convert.ToDateTime("1930-05-09 00:00:00"),
                    ActiveStatus = true
                },
                Password = "mailbox",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "louann@ggmail.com",
                    Email = "louann@ggmail.com",
                    PhoneNumber = "8172556749.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lou Ann",
                    MiddleInitial = "K",
                    LastName = "Feeley",
                    StreetAddress = "600 S 8th Street W",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77010",
                    Birthday = Convert.ToDateTime("1930-02-24 00:00:00"),
                    ActiveStatus = true
                },
                Password = "aggies",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tfreeley@minntonka.ci.state.mn.us",
                    Email = "tfreeley@minntonka.ci.state.mn.us",
                    PhoneNumber = "8173255687.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Tesa",
                    MiddleInitial = "P",
                    LastName = "Freeley",
                    StreetAddress = "4448 Fairview Ave.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77009",
                    Birthday = Convert.ToDateTime("1935-09-01 00:00:00"),
                    ActiveStatus = true
                },
                Password = "raiders",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mgar@aool.com",
                    Email = "mgar@aool.com",
                    PhoneNumber = "8176593544.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Margaret",
                    MiddleInitial = "L",
                    LastName = "Garcia",
                    StreetAddress = "594 Longview",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77003",
                    Birthday = Convert.ToDateTime("1990-07-03 00:00:00"),
                    ActiveStatus = true
                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "chaley@thug.com",
                    Email = "chaley@thug.com",
                    PhoneNumber = "2148475583.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    MiddleInitial = "E",
                    LastName = "Haley",
                    StreetAddress = "One Cowboy Pkwy",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75261",
                    Birthday = Convert.ToDateTime("1985-09-17 00:00:00"),
                    ActiveStatus = true
                },
                Password = "region",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jeff@ggmail.com",
                    Email = "jeff@ggmail.com",
                    PhoneNumber = "5126978613.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeffrey",
                    MiddleInitial = "T",
                    LastName = "Hampton",
                    StreetAddress = "337 38th St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1995-01-23 00:00:00"),
                    ActiveStatus = true
                },
                Password = "hungry",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wjhearniii@umch.edu",
                    Email = "wjhearniii@umch.edu",
                    PhoneNumber = "2148965621.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    MiddleInitial = "B",
                    LastName = "Hearn",
                    StreetAddress = "4225 North First",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75237",
                    Birthday = Convert.ToDateTime("1994-01-08 00:00:00"),
                    ActiveStatus = true
                },
                Password = "logicon",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "hicks43@ggmail.com",
                    Email = "hicks43@ggmail.com",
                    PhoneNumber = "2105788965.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anthony",
                    MiddleInitial = "J",
                    LastName = "Hicks",
                    StreetAddress = "32 NE Garden Ln., Ste 910",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78239",
                    Birthday = Convert.ToDateTime("1990-10-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "doofus",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "bradsingram@mall.utexas.edu",
                    Email = "bradsingram@mall.utexas.edu",
                    PhoneNumber = "5124678821.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    MiddleInitial = "S",
                    LastName = "Ingram",
                    StreetAddress = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78736",
                    Birthday = Convert.ToDateTime("1984-04-12 00:00:00"),
                    ActiveStatus = true
                },
                Password = "mother",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mother.Ingram@aool.com",
                    Email = "mother.Ingram@aool.com",
                    PhoneNumber = "5124653365.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    MiddleInitial = "L",
                    LastName = "Jacobs",
                    StreetAddress = "4564 Elm St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78731",
                    Birthday = Convert.ToDateTime("1983-04-04 00:00:00"),
                    ActiveStatus = true
                },
                Password = "whimsical",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "victoria@aool.com",
                    Email = "victoria@aool.com",
                    PhoneNumber = "5129457399.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Victoria",
                    MiddleInitial = "M",
                    LastName = "Lawrence",
                    StreetAddress = "6639 Butterfly Ln.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78761",
                    Birthday = Convert.ToDateTime("1961-02-03 00:00:00"),
                    ActiveStatus = true
                },
                Password = "nothing",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "lineback@flush.net",
                    Email = "lineback@flush.net",
                    PhoneNumber = "2102449976.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Erik",
                    MiddleInitial = "W",
                    LastName = "Lineback",
                    StreetAddress = "1300 Netherland St",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78293",
                    Birthday = Convert.ToDateTime("1946-09-03 00:00:00"),
                    ActiveStatus = true
                },
                Password = "GoodFellow",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "elowe@netscrape.net",
                    Email = "elowe@netscrape.net",
                    PhoneNumber = "2105344627.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ernest",
                    MiddleInitial = "S",
                    LastName = "Lowe",
                    StreetAddress = "3201 Pine Drive",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78279",
                    Birthday = Convert.ToDateTime("1992-02-07 00:00:00"),
                    ActiveStatus = true
                },
                Password = "impede",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "luce_chuck@ggmail.com",
                    Email = "luce_chuck@ggmail.com",
                    PhoneNumber = "2106983548.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Chuck",
                    MiddleInitial = "B",
                    LastName = "Luce",
                    StreetAddress = "2345 Rolling Clouds",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78268",
                    Birthday = Convert.ToDateTime("1942-10-25 00:00:00"),
                    ActiveStatus = true
                },
                Password = "LuceyDucey",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mackcloud@pimpdaddy.com",
                    Email = "mackcloud@pimpdaddy.com",
                    PhoneNumber = "5124748138.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    MiddleInitial = "D",
                    LastName = "MacLeod",
                    StreetAddress = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78731",
                    Birthday = Convert.ToDateTime("1965-08-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "cloudyday",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "liz@ggmail.com",
                    Email = "liz@ggmail.com",
                    PhoneNumber = "5124579845.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Elizabeth",
                    MiddleInitial = "P",
                    LastName = "Markham",
                    StreetAddress = "7861 Chevy Chase",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78732",
                    Birthday = Convert.ToDateTime("1959-04-13 00:00:00"),
                    ActiveStatus = true
                },
                Password = "emarkbark",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mclarence@aool.com",
                    Email = "mclarence@aool.com",
                    PhoneNumber = "8174955201.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clarence",
                    MiddleInitial = "A",
                    LastName = "Martin",
                    StreetAddress = "87 Alcedo St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77045",
                    Birthday = Convert.ToDateTime("1990-01-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "smartinmartin",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "smartinmartin.Martin@aool.com",
                    Email = "smartinmartin.Martin@aool.com",
                    PhoneNumber = "8178746718.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gregory",
                    MiddleInitial = "R",
                    LastName = "Martinez",
                    StreetAddress = "8295 Sunset Blvd.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77030",
                    Birthday = Convert.ToDateTime("1987-10-09 00:00:00"),
                    ActiveStatus = true
                },
                Password = "looter",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cmiller@mapster.com",
                    Email = "cmiller@mapster.com",
                    PhoneNumber = "8177458615.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    MiddleInitial = "R",
                    LastName = "Miller",
                    StreetAddress = "8962 Main St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77031",
                    Birthday = Convert.ToDateTime("1984-07-21 00:00:00"),
                    ActiveStatus = true
                },
                Password = "chucky33",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "nelson.Kelly@aool.com",
                    Email = "nelson.Kelly@aool.com",
                    PhoneNumber = "5122926966.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Kelly",
                    MiddleInitial = "T",
                    LastName = "Nelson",
                    StreetAddress = "2601 Red River",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78703",
                    Birthday = Convert.ToDateTime("1956-07-04 00:00:00"),
                    ActiveStatus = true
                },
                Password = "orange",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jojoe@ggmail.com",
                    Email = "jojoe@ggmail.com",
                    PhoneNumber = "2143125897.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Joe",
                    MiddleInitial = "C",
                    LastName = "Nguyen",
                    StreetAddress = "1249 4th SW St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75238",
                    Birthday = Convert.ToDateTime("1963-01-29 00:00:00"),
                    ActiveStatus = true
                },
                Password = "victorious",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "orielly@foxnets.com",
                    Email = "orielly@foxnets.com",
                    PhoneNumber = "2103450925.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Bill",
                    MiddleInitial = "T",
                    LastName = "O'Reilly",
                    StreetAddress = "8800 Gringo Drive",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78260",
                    Birthday = Convert.ToDateTime("1983-01-07 00:00:00"),
                    ActiveStatus = true
                },
                Password = "billyboy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "or@aool.com",
                    Email = "or@aool.com",
                    PhoneNumber = "2142345566.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anka",
                    MiddleInitial = "L",
                    LastName = "Radkovich",
                    StreetAddress = "1300 Elliott Pl",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75260",
                    Birthday = Convert.ToDateTime("1980-03-31 00:00:00"),
                    ActiveStatus = true
                },
                Password = "radicalone",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "megrhodes@freezing.co.uk",
                    Email = "megrhodes@freezing.co.uk",
                    PhoneNumber = "5123744746.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    MiddleInitial = "C",
                    LastName = "Rhodes",
                    StreetAddress = "4587 Enfield Rd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78707",
                    Birthday = Convert.ToDateTime("1944-08-12 00:00:00"),
                    ActiveStatus = true
                },
                Password = "gohorns",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "erynrice@aool.com",
                    Email = "erynrice@aool.com",
                    PhoneNumber = "5123876657.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    MiddleInitial = "M",
                    LastName = "Rice",
                    StreetAddress = "3405 Rio Grande",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1934-08-02 00:00:00"),
                    ActiveStatus = true
                },
                Password = "iloveme",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jorge@hootmail.com",
                    Email = "jorge@hootmail.com",
                    PhoneNumber = "8178904374.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jorge",
                    MiddleInitial = "nan",
                    LastName = "Rodriguez",
                    StreetAddress = "6788 Cotter Street",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77057",
                    Birthday = Convert.ToDateTime("1989-08-11 00:00:00"),
                    ActiveStatus = true
                },
                Password = "greedy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ra@aoo.com",
                    Email = "ra@aoo.com",
                    PhoneNumber = "5128752943.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    MiddleInitial = "B",
                    LastName = "Rogers",
                    StreetAddress = "4965 Oak Hill",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78732",
                    Birthday = Convert.ToDateTime("1967-08-27 00:00:00"),
                    ActiveStatus = true
                },
                Password = "familiar",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "st-jean@home.com",
                    Email = "st-jean@home.com",
                    PhoneNumber = "2104145678.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Olivier",
                    MiddleInitial = "M",
                    LastName = "Saint-Jean",
                    StreetAddress = "255 Toncray Dr.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78292",
                    Birthday = Convert.ToDateTime("1950-07-08 00:00:00"),
                    ActiveStatus = true
                },
                Password = "historical",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ss34@ggmail.com",
                    Email = "ss34@ggmail.com",
                    PhoneNumber = "5123497810.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Sarah",
                    MiddleInitial = "J",
                    LastName = "Saunders",
                    StreetAddress = "332 Avenue C",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1977-10-29 00:00:00"),
                    ActiveStatus = true
                },
                Password = "guiltless",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "willsheff@email.com",
                    Email = "willsheff@email.com",
                    PhoneNumber = "5124510084.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "William",
                    MiddleInitial = "T",
                    LastName = "Sewell",
                    StreetAddress = "2365 51st St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78709",
                    Birthday = Convert.ToDateTime("1941-04-21 00:00:00"),
                    ActiveStatus = true
                },
                Password = "frequent",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "sheff44@ggmail.com",
                    Email = "sheff44@ggmail.com",
                    PhoneNumber = "5125479167.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    MiddleInitial = "J",
                    LastName = "Sheffield",
                    StreetAddress = "3886 Avenue A",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1937-11-10 00:00:00"),
                    ActiveStatus = true
                },
                Password = "history",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "johnsmith187@aool.com",
                    Email = "johnsmith187@aool.com",
                    PhoneNumber = "2108321888.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    MiddleInitial = "A",
                    LastName = "Smith",
                    StreetAddress = "23 Hidden Forge Dr.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78280",
                    Birthday = Convert.ToDateTime("1954-10-26 00:00:00"),
                    ActiveStatus = true
                },
                Password = "squirrel",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dustroud@mail.com",
                    Email = "dustroud@mail.com",
                    PhoneNumber = "2142346667.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Dustin",
                    MiddleInitial = "P",
                    LastName = "Stroud",
                    StreetAddress = "1212 Rita Rd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75221",
                    Birthday = Convert.ToDateTime("1932-09-01 00:00:00"),
                    ActiveStatus = true
                },
                Password = "snakes",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ericstuart@aool.com",
                    Email = "ericstuart@aool.com",
                    PhoneNumber = "5128178335.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    MiddleInitial = "D",
                    LastName = "Stuart",
                    StreetAddress = "5576 Toro Ring",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    Birthday = Convert.ToDateTime("1930-12-28 00:00:00"),
                    ActiveStatus = true
                },
                Password = "landus",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "peterstump@hootmail.com",
                    Email = "peterstump@hootmail.com",
                    PhoneNumber = "8174560903.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Peter",
                    MiddleInitial = "L",
                    LastName = "Stump",
                    StreetAddress = "1300 Kellen Circle",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77018",
                    Birthday = Convert.ToDateTime("1989-08-13 00:00:00"),
                    ActiveStatus = true
                },
                Password = "rhythm",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tanner@ggmail.com",
                    Email = "tanner@ggmail.com",
                    PhoneNumber = "8174590929.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    MiddleInitial = "S",
                    LastName = "Tanner",
                    StreetAddress = "4347 Almstead",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77044",
                    Birthday = Convert.ToDateTime("1982-05-21 00:00:00"),
                    ActiveStatus = true
                },
                Password = "kindly",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "taylordjay@aool.com",
                    Email = "taylordjay@aool.com",
                    PhoneNumber = "5124748452.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    MiddleInitial = "R",
                    LastName = "Taylor",
                    StreetAddress = "467 Nueces St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1960-01-08 00:00:00"),
                    ActiveStatus = true
                },
                Password = "instrument",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "TayTaylor@aool.com",
                    Email = "TayTaylor@aool.com",
                    PhoneNumber = "5124512631.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Rachel",
                    MiddleInitial = "K",
                    LastName = "Taylor",
                    StreetAddress = "345 Longview Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1975-07-27 00:00:00"),
                    ActiveStatus = true
                },
                Password = "arched",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "teefrank@hootmail.com",
                    Email = "teefrank@hootmail.com",
                    PhoneNumber = "8178765543.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Frank",
                    MiddleInitial = "J",
                    LastName = "Tee",
                    StreetAddress = "5590 Lavell Dr",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77004",
                    Birthday = Convert.ToDateTime("1968-04-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "median",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tuck33@ggmail.com",
                    Email = "tuck33@ggmail.com",
                    PhoneNumber = "2148471154.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clent",
                    MiddleInitial = "J",
                    LastName = "Tucker",
                    StreetAddress = "312 Main St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75315",
                    Birthday = Convert.ToDateTime("1978-05-19 00:00:00"),
                    ActiveStatus = true
                },
                Password = "approval",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "avelasco@yaho.com",
                    Email = "avelasco@yaho.com",
                    PhoneNumber = "2143985638.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    MiddleInitial = "G",
                    LastName = "Velasco",
                    StreetAddress = "679 W. 4th",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75207",
                    Birthday = Convert.ToDateTime("1963-10-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "decorate",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "westj@pioneer.net",
                    Email = "westj@pioneer.net",
                    PhoneNumber = "2148475244.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jake",
                    MiddleInitial = "T",
                    LastName = "West",
                    StreetAddress = "RR 3287",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75323",
                    Birthday = Convert.ToDateTime("1993-10-14 00:00:00"),
                    ActiveStatus = true
                },
                Password = "grover",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "louielouie@aool.com",
                    Email = "louielouie@aool.com",
                    PhoneNumber = "2145650098.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Louis",
                    MiddleInitial = "L",
                    LastName = "Winthorpe",
                    StreetAddress = "2500 Padre Blvd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75220",
                    Birthday = Convert.ToDateTime("1952-05-31 00:00:00"),
                    ActiveStatus = true
                },
                Password = "sturdy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "rwood@voyager.net",
                    Email = "rwood@voyager.net",
                    PhoneNumber = "5124545242.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Reagan",
                    MiddleInitial = "B",
                    LastName = "Wood",
                    StreetAddress = "447 Westlake Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    Birthday = Convert.ToDateTime("1992-04-24 00:00:00"),
                    ActiveStatus = true
                },
                Password = "decorous",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dman@wdwebsolutions.com",
                    Email = "dman@wdwebsolutions.com",
                    PhoneNumber = "5556409287.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Derek",
                    MiddleInitial = "nan",
                    LastName = "Dreibrodt",
                    StreetAddress = "423 Brentwood Dr",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("2001-01-01 00:00:00"),
                    ActiveStatus = true
                },
                Password = "nasus123",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jman@outlook.com",
                    Email = "jman@outlook.com",
                    PhoneNumber = "5558471234.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jacob",
                    MiddleInitial = "nan",
                    LastName = "Foster",
                    StreetAddress = "700 Fancy St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("2000-09-01 00:00:00"),
                    ActiveStatus = true
                },
                Password = "pres4baseball",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "t.jacobs@longhornbank.neet",
                    Email = "t.jacobs@longhornbank.neet",
                    PhoneNumber = "8176593544.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    MiddleInitial = "L",
                    LastName = "Jacobs",
                    StreetAddress = "4564 Elm St.",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77003",
                    Birthday = Convert.ToDateTime("1990-01-01 00:00:00"),
                    ActiveStatus = true
                },
                Password = "society",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.rice@longhornbank.neet",
                    Email = "e.rice@longhornbank.neet",
                    PhoneNumber = "2148475583.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    MiddleInitial = "M",
                    LastName = "Rice",
                    StreetAddress = "3405 Rio Grande",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75261",
                    Birthday = Convert.ToDateTime("1990-01-02 00:00:00"),
                    ActiveStatus = true
                },
                Password = "ricearoni",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "b.ingram@longhornbank.neet",
                    Email = "b.ingram@longhornbank.neet",
                    PhoneNumber = "5126978613.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    MiddleInitial = "S",
                    LastName = "Ingram",
                    StreetAddress = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1990-01-03 00:00:00"),
                    ActiveStatus = true
                },
                Password = "ingram45",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.taylor@longhornbank.neet",
                    Email = "a.taylor@longhornbank.neet",
                    PhoneNumber = "2148965621.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    MiddleInitial = "R",
                    LastName = "Taylor",
                    StreetAddress = "467 Nueces St.",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75237",
                    Birthday = Convert.ToDateTime("1990-01-04 00:00:00"),
                    ActiveStatus = true
                },
                Password = "nostalgic",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.martinez@longhornbank.neet",
                    Email = "g.martinez@longhornbank.neet",
                    PhoneNumber = "2105788965.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gregory",
                    MiddleInitial = "R",
                    LastName = "Martinez",
                    StreetAddress = "8295 Sunset Blvd.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78239",
                    Birthday = Convert.ToDateTime("1990-01-05 00:00:00"),
                    ActiveStatus = true
                },
                Password = "fungus",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.sheffield@longhornbank.neet",
                    Email = "m.sheffield@longhornbank.neet",
                    PhoneNumber = "5124678821.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    MiddleInitial = "J",
                    LastName = "Sheffield",
                    StreetAddress = "3886 Avenue A",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78736",
                    Birthday = Convert.ToDateTime("1990-01-06 00:00:00"),
                    ActiveStatus = true
                },
                Password = "longhorns",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.macleod@longhornbank.neet",
                    Email = "j.macleod@longhornbank.neet",
                    PhoneNumber = "5124653365.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    MiddleInitial = "D",
                    LastName = "MacLeod",
                    StreetAddress = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78731",
                    Birthday = Convert.ToDateTime("1990-01-07 00:00:00"),
                    ActiveStatus = true
                },
                Password = "smitty",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.tanner@longhornbank.neet",
                    Email = "j.tanner@longhornbank.neet",
                    PhoneNumber = "5129457399.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    MiddleInitial = "S",
                    LastName = "Tanner",
                    StreetAddress = "4347 Almstead",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78761",
                    Birthday = Convert.ToDateTime("1990-01-08 00:00:00"),
                    ActiveStatus = true
                },
                Password = "tanman",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.rhodes@longhornbank.neet",
                    Email = "m.rhodes@longhornbank.neet",
                    PhoneNumber = "2102449976.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    MiddleInitial = "C",
                    LastName = "Rhodes",
                    StreetAddress = "4587 Enfield Rd.",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78293",
                    Birthday = Convert.ToDateTime("1990-01-09 00:00:00"),
                    ActiveStatus = true
                },
                Password = "countryrhodes",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.stuart@longhornbank.neet",
                    Email = "e.stuart@longhornbank.neet",
                    PhoneNumber = "2105344627.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    MiddleInitial = "F",
                    LastName = "Stuart",
                    StreetAddress = "5576 Toro Ring",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78279",
                    Birthday = Convert.ToDateTime("1990-01-10 00:00:00"),
                    ActiveStatus = true
                },
                Password = "stewboy",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.chung@longhornbank.neet",
                    Email = "l.chung@longhornbank.neet",
                    PhoneNumber = "2106983548.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lisa",
                    MiddleInitial = "N",
                    LastName = "Chung",
                    StreetAddress = "234 RR 12",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78268",
                    Birthday = Convert.ToDateTime("1990-01-11 00:00:00"),
                    ActiveStatus = true
                },
                Password = "lisssa",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.swanson@longhornbank.neet",
                    Email = "l.swanson@longhornbank.neet",
                    PhoneNumber = "5124748138.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Leon",
                    MiddleInitial = "nan",
                    LastName = "Swanson",
                    StreetAddress = "245 River Rd",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78731",
                    Birthday = Convert.ToDateTime("1990-01-12 00:00:00"),
                    ActiveStatus = true
                },
                Password = "swansong",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "w.loter@longhornbank.neet",
                    Email = "w.loter@longhornbank.neet",
                    PhoneNumber = "5124579845.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wanda",
                    MiddleInitial = "K",
                    LastName = "Loter",
                    StreetAddress = "3453 RR 3235",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78732",
                    Birthday = Convert.ToDateTime("1990-01-13 00:00:00"),
                    ActiveStatus = true
                },
                Password = "lottery",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.white@longhornbank.neet",
                    Email = "j.white@longhornbank.neet",
                    PhoneNumber = "8174955201.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jason",
                    MiddleInitial = "M",
                    LastName = "White",
                    StreetAddress = "12 Valley View",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77045",
                    Birthday = Convert.ToDateTime("1990-01-14 00:00:00"),
                    ActiveStatus = true
                },
                Password = "evanescent",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "w.montgomery@longhornbank.neet",
                    Email = "w.montgomery@longhornbank.neet",
                    PhoneNumber = "8178746718.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wilda",
                    MiddleInitial = "K",
                    LastName = "Montgomery",
                    StreetAddress = "210 Blanco Dr",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77030",
                    Birthday = Convert.ToDateTime("1990-01-15 00:00:00"),
                    ActiveStatus = true
                },
                Password = "monty3",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "h.morales@longhornbank.neet",
                    Email = "h.morales@longhornbank.neet",
                    PhoneNumber = "8177458615.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Hector",
                    MiddleInitial = "N",
                    LastName = "Morales",
                    StreetAddress = "4501 RR 140",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77031",
                    Birthday = Convert.ToDateTime("1990-01-16 00:00:00"),
                    ActiveStatus = true
                },
                Password = "hecktour",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.rankin@longhornbank.neet",
                    Email = "m.rankin@longhornbank.neet",
                    PhoneNumber = "5122926966.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Mary",
                    MiddleInitial = "T",
                    LastName = "Rankin",
                    StreetAddress = "340 Second St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78703",
                    Birthday = Convert.ToDateTime("1990-01-17 00:00:00"),
                    ActiveStatus = true
                },
                Password = "rankmary",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.walker@longhornbank.neet",
                    Email = "l.walker@longhornbank.neet",
                    PhoneNumber = "2143125897.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Larry",
                    MiddleInitial = "G",
                    LastName = "Walker",
                    StreetAddress = "9 Bison Circle",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75238",
                    Birthday = Convert.ToDateTime("1990-01-18 00:00:00"),
                    ActiveStatus = true
                },
                Password = "walkamile",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.chang@longhornbank.neet",
                    Email = "g.chang@longhornbank.neet",
                    PhoneNumber = "2103450925.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "George",
                    MiddleInitial = "M",
                    LastName = "Chang",
                    StreetAddress = "9003 Joshua St",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78260",
                    Birthday = Convert.ToDateTime("1990-01-19 00:00:00"),
                    ActiveStatus = true
                },
                Password = "changalang",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "g.gonzalez@longhornbank.neet",
                    Email = "g.gonzalez@longhornbank.neet",
                    PhoneNumber = "2142345566.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gwen",
                    MiddleInitial = "J",
                    LastName = "Gonzalez",
                    StreetAddress = "103 Manor Rd",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75260",
                    Birthday = Convert.ToDateTime("1990-01-20 00:00:00"),
                    ActiveStatus = true
                },
                Password = "offbeat",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dman@longhornbank.neet",
                    Email = "dman@longhornbank.neet",
                    PhoneNumber = "5556409287.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Derek",
                    MiddleInitial = "nan",
                    LastName = "Dreibrodt",
                    StreetAddress = "423 Brentwood Dr",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1990-01-21 00:00:00"),
                    ActiveStatus = true
                },
                Password = "nasus123",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jman@longhornbank.neet",
                    Email = "jman@longhornbank.neet",
                    PhoneNumber = "5558471234.0",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jacob",
                    MiddleInitial = "nan",
                    LastName = "Foster",
                    StreetAddress = "700 Fancy St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Birthday = Convert.ToDateTime("1990-01-22 00:00:00"),
                    ActiveStatus = true
                },
                Password = "pres4baseball",
                RoleName = "Admin"
            });

            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    // Took Utilities.AddUser from Relational Data Demo -> this is "Utilities/AddUser.cs"
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: " 
                    + errorFlag, ex);
            }

            return result;

        }
    }
}
