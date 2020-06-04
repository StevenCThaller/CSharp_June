using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            int num1 = 10;
            int num2 = 4;


            ViewBag.Elephant = "hello there!";
            ViewBag.NumberOne = num1;
            ViewBag.NumberTwo = num2;


            return View("Index");
        }

        [HttpGet("page2")]
        public ViewResult OtherPage()
        {
            return View();
        }

        [HttpGet("redirect")]
        public RedirectResult Redirecting()
        {
            return Redirect("/page2");
        }
    }
}