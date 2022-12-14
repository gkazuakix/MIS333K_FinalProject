//this is just copied from HW4, might need to be changed

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using fa22Team16.DAL;
using fa22Team16.Models;
using fa22Team16.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace fa22Team16.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,

                //to do: Add the rest of the custom user fields here
                //FirstName is included as an example
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                StreetAddress = rvm.StreetAddress,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                Birthday = rvm.Birthday

            };

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,

                //TODO: You will need to change this value if you want to 
                //add the user to a different role - just specify the role name.
                RoleName = "Customer"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            { 
                //NOTE: This code logs the user into the account that they just created
                //You may or may not want to log a user in directly after they register - check
                //the business rules!
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);
                Utilities.EmailMessaging.SendEmail(newUser.Email, "Congrats on registering for your account", "You have successfully registered");
                //Send the user to the home page
                return RedirectToAction("Index", "Home");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }


            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                //return ?? "/" means if returnUrl is null, substitute "/" (home)
                return Redirect(returnUrl ?? "/");
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Settings
        public async Task<IActionResult> Settings()
        {
            AppUser appUser = _context.Users.FirstOrDefault(m => m.UserName == User.Identity.Name);
            if (appUser == null)
            {
                return NotFound();
            }

            //AppUser appUser = _context.Users.FirstOrDefault(m => m.Id == id);

            //if (appUser == null)
            //{
            //    return NotFound();
            //}

            //if (User.IsInRole("Customer") == false)
            //{
            //    return View("Error", new String[] { "This is not your order!  Don't be such a snoop!" });
            //}

            return View(appUser);
        }

        ////GET: Account/Edit
        //public IActionResult Edit(int? id)
        //{
        //    return View();
        //}

        ////Post: Account/Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public Task<IActionResult> Edit(AppUser appUser)
        //{
        //    return View();
        //} 

        //Get: Account/Edit
        public async Task<IActionResult> CustomerEdit()
        {

            ////find the profile in the database
            //AppUser appUser = await _context.Users.FindAsync(id);

            ////see if the profile exists in the database
            //if (appUser == null)
            //{
            //    return View("Error", new String[] { "This profile does not exist in the database!" });
            //}

            //send the user to the edit profile page
            AppUser appUser = new AppUser();
            appUser = await _userManager.FindByNameAsync(User.Identity.Name);

//# make view model
            UserProfileEdit model = new UserProfileEdit();
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.MiddleInitial = appUser.MiddleInitial;
            model.StreetAddress = appUser.StreetAddress;
            model.City = appUser.City;
            model.ZipCode = appUser.ZipCode;
            model.State = appUser.State;
            model.PhoneNumber = appUser.PhoneNumber;
            return View(model);
        }

        // POST: Account/Edit/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerEdit( UserProfileEdit userProfile)
        {
            //this is a security measure to make sure they are editing the correct profile
            //if (id != appUser.Id)
            //{
            //    return View("Error", new String[] { "There was a problem editing this profile. Try again!" });
            //}

            //if the user messed up, send them back to the view to try again
            if (ModelState.IsValid == false)
            {
                return View(userProfile);
            }

            //if code gets this far, make the updates
            try
            {
                string username = User.Identity.Name;
                // Get the userprofile
                AppUser user = _context.Users.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields
                user.FirstName = userProfile.FirstName;
                user.LastName = userProfile.LastName;
                user.MiddleInitial = userProfile.MiddleInitial;
                user.StreetAddress = userProfile.StreetAddress;
                user.City = userProfile.City;
                user.ZipCode = userProfile.ZipCode;
                user.State = userProfile.State;
                user.PhoneNumber = userProfile.PhoneNumber;


                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was a problem editing this profile.", ex.Message });
            }

            //send the user back to the view with all the suppliers
            return RedirectToAction(nameof(Settings));
        }


        public async Task<IActionResult> EmployeeEdit()
        {

            ////find the profile in the database
            //AppUser appUser = await _context.Users.FindAsync(id);

            ////see if the profile exists in the database
            //if (appUser == null)
            //{
            //    return View("Error", new String[] { "This profile does not exist in the database!" });
            //}

            //send the user to the edit profile page
            AppUser appUser = new AppUser();
            appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //# make view model
            UserProfileEdit model = new UserProfileEdit();
            model.StreetAddress = appUser.StreetAddress;
            model.City = appUser.City;
            model.ZipCode = appUser.ZipCode;
            model.State = appUser.State;
            model.PhoneNumber = appUser.PhoneNumber;
            return View(model);
        }

        // POST: Account/Edit/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeEdit(UserProfileEdit userProfile)
        {
            //this is a security measure to make sure they are editing the correct profile
            //if (id != appUser.Id)
            //{
            //    return View("Error", new String[] { "There was a problem editing this profile. Try again!" });
            //}

            //if the user messed up, send them back to the view to try again
            if (ModelState.IsValid == false)
            {
                return View(userProfile);
            }

            //if code gets this far, make the updates
            try
            {
                string username = User.Identity.Name;
                // Get the userprofile
                AppUser user = _context.Users.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields
                
                user.StreetAddress = userProfile.StreetAddress;
                user.City = userProfile.City;
                user.ZipCode = userProfile.ZipCode;
                user.State = userProfile.State;
                user.PhoneNumber = userProfile.PhoneNumber;


                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was a problem editing this profile.", ex.Message });
            }

            //send the user back to the view with all the suppliers
            return RedirectToAction(nameof(Settings));
        }


        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;

            //send data to the view
            return View(ivm);
        }

        // GET: /Account/ManageUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageUsersIndex()
        {
            List<AppUser> appUsers = new List<AppUser>();

            appUsers = _context.Users.Include(ba => ba.BankAccounts).Include(ba => ba.StockPortfolio).ToList();


            return View(appUsers);
        }


        // GET: /Account/ManageUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageUsers(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            //if (User.IsInRole("Admin") == false && transaction.Account.appUser.UserName != User.Identity.Name)
            //{
            //    return View("Error", new string[] { "You are not authorized to edit this transaction!" });
            //}

            return View(user);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUsers(string id, AppUser appUser)
        {
            //if (id != transaction.TransactionID)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
                AppUser editedUser = _context.Users.Include(d => d.BankAccounts).Include(d => d.StockPortfolio).FirstOrDefault(d => d.Id == id);
                //try
                //{
                    editedUser.ActiveStatus = false;
                    //editedUser.Account.Balance = editedTransaction.Account.Balance + editedTransaction.Amount;
                    _context.Update(editedUser);
                    await _context.SaveChangesAsync();
                    //Utilities.EmailMessaging.SendEmail(editedTransaction.Account.appUser.Email, "Your deposit was approved", "You have successfully deposited your money");
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!TransactionExists(transaction.TransactionID))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction("ManageUsersIndex", "Account");
            //}
            //return View();
        }



        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }           
    }
}