using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TwoFormsOnePage.Models;

namespace TwoFormsOnePage.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            Drank WMod = new Drank();
            WMod.AllBooze = dbContext.Liquors.ToList();
            WMod.NotBooze = dbContext.Mixers.ToList();
            return View("Index", WMod);
        }

        [HttpPost("liquor/create")]
        public IActionResult CreateLiquor(Drank FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Liquors.Add(FromForm.LiquorForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return Index();
        }

        [HttpPost("mixer/create")]
        public IActionResult CreateMixer(Drank FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Mixers.Add(FromForm.MixerForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return Index();
        }
    }
}