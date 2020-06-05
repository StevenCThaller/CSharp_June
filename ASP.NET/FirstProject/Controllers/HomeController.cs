using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            string message = "Lorem ipsum blah blah blah blah blah";

            return View("Index", message);
        }

        [HttpGet("page2")]
        public ViewResult OtherPage()
        {
            int[] myArray = new int[]{1,2,3,4,5};

            return View("OtherPage", myArray);
        }

        [HttpGet("page3")]
        public ViewResult ThirdPage()
        {
            User ToDisplay = new User("Billy", "Gates");

            return View(ToDisplay);
        }

        [HttpGet("page4")]
        public ViewResult FourthPage()
        {
            List<User> ListOfUsers = new List<User>
            {
                new User("Billy", "Gates"),
                new User("Jeffington", "Bezos"),
                new User("Clyde", "Harrison"),
                new User("William", "Shatner")
            };

            return View(ListOfUsers);   
        }

        [HttpGet("bonusround")]
        public ViewResult BonusRound()
        {
            User nommer = new User("Nom", "Nommingtons");
            Pancake panqueque = new Pancake("Panqueue", true);

            BonusRoundWrapper ToDisplay = new BonusRoundWrapper();
            ToDisplay.User = nommer;
            ToDisplay.Pancake = panqueque;
            return View(ToDisplay);
        }
    }
}