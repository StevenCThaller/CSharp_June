using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SecretSecret.Controllers
{
    public class Dummy
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dummy(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public class HomeController : Controller 
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            string ErrorMaybe = HttpContext.Session.GetString("ErrorCode");

            if(ErrorMaybe != null)
            {
                ViewBag.Error = ErrorMaybe;
                HttpContext.Session.Clear();
            }
            Dummy myobject = new Dummy("Cody", 29);
            HttpContext.Session.SetObjectAsJson("MyObject", myobject);

            return View();
        }

        [HttpPost("tellsecret")]
        public RedirectToActionResult TellSecret(string Secret, int SecretNumber)
        {
            // Adding a string into session
            HttpContext.Session.SetString("MySecret", Secret);

            // Adding a number into session
            HttpContext.Session.SetInt32("MyCode", SecretNumber);
            return RedirectToAction("Index");
        }

        [HttpGet("whatsthecode")]
        public IActionResult SecretCode()
        {
            int? SecretCode = HttpContext.Session.GetInt32("MyCode");

            if(SecretCode == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost("confirmcode")]
        public RedirectToActionResult ConfirmCode(int FormCode)
        {
            int? SessionCode = HttpContext.Session.GetInt32("MyCode");

            if(SessionCode == null)
            {
                return RedirectToAction("Index");
            }
            else if(FormCode == SessionCode)
            {
                return RedirectToAction("ShowSecret");
            }
            else
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("ErrorCode", "Due to an attempted security breach, we have cleared your message!");
                return RedirectToAction("Index");
            }
        }

        [HttpGet("yoursecret")]
        public IActionResult ShowSecret()
        {
            string SessionSecret = HttpContext.Session.GetString("MySecret");

            if(SessionSecret == null)
            {
                return RedirectToAction("Index");
            }
            else 
            {   
                Dummy MyObject = HttpContext.Session.GetObjectFromJson<Dummy>("MyObject");
                ViewBag.MyObject = MyObject;
                ViewBag.YourSecret = SessionSecret;
                return View();
            }
        }

        [HttpGet("forgetmysecret")]
        public RedirectToActionResult ForgetSecret()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}