using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Validations.Models;

namespace Validations.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("submitmyform")]
        public ViewResult Results(Person FromForm)
        {
            if(ModelState.IsValid)
            {
                return View(FromForm);
            }
            return View("Index");
        }
    }
}