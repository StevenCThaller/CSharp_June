using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CamelBase.Models;
using Microsoft.EntityFrameworkCore;

namespace CamelBase.Controllers
{
    public class HomeController : Controller
    {

        // This is how we will actually communicate with the
        // database
        private MyContext dbContext;

        // I'd just like to point out here that this is a constructor.
        // It's how we set our dbContext to be the actual
        // context connecting to the database
        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("camels/create")]
        public IActionResult CreateCamel(Camel FromForm)
        {
            // Checking if the model submitted through the form
            // passes the validation check that we set up
            // in the class definition.
            if(ModelState.IsValid)
            {
                // Once we've decided that the camel from our form
                // we want to add it to the database
                dbContext.Add(FromForm);
                // And then, since our context is a local copy
                // of the database itself, we have to save the
                // changes to our actual database!!
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }

        [HttpGet("camels/all")]
        public ViewResult AllCamels()
        {
            // Since we want to show all the camels on our page,
            // we query the database for all the camels.
            // Because queries like this return an IEnumerable,
            // and Ryan wanted it to be an array, we converted it 
            // to an Array.
            Camel[] AllCamels = dbContext.Camels.ToArray();
            return View(AllCamels);
        }

        [HttpGet("camels/delete/{CamelId}")]
        public RedirectToActionResult DeleteCamel(int CamelId)
        {
            // Deleting from the database is, logically, simple.
            // We need to pull the object from our database
            Camel ToDelete = dbContext.Camels
                .FirstOrDefault(camel => camel.CamelId == CamelId);
            // Then delete it from the local context of our database
            dbContext.Remove(ToDelete);
            // And save the changes, which will push the changes to
            // the actual database itself.
            dbContext.SaveChanges();
            return RedirectToAction("AllCamels");
        }

        [HttpGet("camels/edit/{CamelId}")]
        public ViewResult EditCamel(int CamelId)
        {
            // Using our tag helpers makes Editing super easy!
            // All we need to do is pull the camel we want to edit
            // from our database, then send it to the cshtml page!
            Camel ToEdit = dbContext.Camels
                .FirstOrDefault(camel => camel.CamelId == CamelId);
            return View("EditCamel",ToEdit);
        }

        [HttpPost("camels/update/{CamelId}")]
        public IActionResult UpdateCamel(int CamelId, Camel FromForm)
        {
            // Now we need to check the submitted model for errors
            if(ModelState.IsValid)
            {
                // And this is the fancy new update method!

                // Apply the camel id from the route to the object
                FromForm.CamelId = CamelId;

                // Then, run the update method
                dbContext.Update(FromForm);

                // Now, we need to remove the modified flag on the CreatedAt
                // property, so Entity doesn't try to overwrite the CreatedAt method
                dbContext.Entry(FromForm).Property("CreatedAt").IsModified = false;

                // And finally, save the changes in our actual database.
                dbContext.SaveChanges();
                return RedirectToAction("AllCamels");
            }
            else
            {
                return EditCamel(CamelId);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
