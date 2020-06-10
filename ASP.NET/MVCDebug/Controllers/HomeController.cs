using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCDebug.Models;

namespace MVCDebug.Controllers
{
    public class HomeController : Controller
    {
        public static void CountToTen()
        {
            for(int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(i);
            }
            PrintMe();
        }

        public static void PrintMe()
        {
            System.Console.WriteLine("Me!");
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Ryan = "Terrible Pun Man";
            return View();
        }


        [HttpPost("submit")]
        public IActionResult SubmitForm(User FromForm)
        {
            CountToTen();
            return RedirectToAction("Index");
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
