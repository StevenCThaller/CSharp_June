using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; // This contains our password hasher
using OneToMany.Models;
using System.Linq;

namespace OneToMany.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public ViewResult RegisterForm()
        {
            return View("RegisterForm");
        }

        [HttpPost("register")]
        public IActionResult Register(Killer FromForm)
        {
            if(ModelState.IsValid)
            {
                // This is checking for uniqueness based on alias
                if(dbContext.Killers.Any(k => k.Alias == FromForm.Alias))
                {
                    ModelState.AddModelError("Alias", "A killer with that alias already exists!");
                    return RegisterForm();
                }

                // Creating an instance of the imported pw hashing object
                PasswordHasher<Killer> Hasher = new PasswordHasher<Killer>();
                // And now, use that hasher to actually encrypt the password attached to the
                // killer submitted via the registration form
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);


                // Now that we have encrypted the password, let's go ahead and push it into the database
                dbContext.Killers.Add(FromForm);
                dbContext.SaveChanges();

                // Now that we've created the new killer, let's put their Id in session
                // so we've "logged them in"
                HttpContext.Session.SetInt32("KillerId", FromForm.KillerId);
                return RedirectToAction("Dashboard");
            }
            else 
            {
                return RegisterForm();
            }
        }

        [HttpGet("loginform")]
        public ViewResult LoginForm()
        {
            return View("LoginForm");
        }

        [HttpPost("login")]
        public IActionResult Login(LogKiller FromForm)
        {
            if(ModelState.IsValid)
            {
                // Grabs a killer from the database whose alias matches the alias passed in through the form
                Killer Existing = dbContext.Killers.FirstOrDefault(k => k.Alias == FromForm.LogAlias);


                // If that killer doesn't actually exist (basically, if there is no killer in our database
                // with that alias)
                if(Existing == null)
                {
                    // Then create an error message saying invalid
                    ModelState.AddModelError("LogAlias", "Invalid Alias/Password");
                    return LoginForm();
                }
                // If that existing check did not get tripped, and there is in fact a killer in our database
                // with the alias from the form, we now need to hash the password from the form, and check it against
                // the password in the database

                // This is the object that will actually run the password check
                PasswordHasher<LogKiller> Hasher = new PasswordHasher<LogKiller>();

                // This is the method that actually checks it. There is mystery behind it, but basically
                // it encrypts the password form the form, checks it against the encrypted password in the database,
                // and returns somethign to indicate whether or not it is a match
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(FromForm, Existing.Password, FromForm.LogPass);

                // If the result is 0, it is not a match, so we say no no
                if(result == 0)
                {
                    ModelState.AddModelError("LogAlias", "Invalid Alias/Password");
                    return LoginForm();
                }

                // If we got this far, the user is allowed to log in!

                // Let's put the logged in killer's Id in session.
                HttpContext.Session.SetInt32("KillerId", Existing.KillerId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return LoginForm();
            }
        }
    
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? LoggedKiller = HttpContext.Session.GetInt32("KillerId");
            if(LoggedKiller == null)
            {
                return RedirectToAction("RegisterForm");
            }

            ViewBag.LoggedKiller = dbContext.Killers.FirstOrDefault(k => k.KillerId == (int)LoggedKiller);



            return View("Dashboard");
        }
    }
}