using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ManyToMany.Models;

namespace ManyToMany.Controllers
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
            ViewBag.Heroes = dbContext.Heroes
                // Include the intermediary table
                .Include(h => h.TeamsPartOf)
                // And from that middle table, include the object on the OTHER side of the
                // many to many relationship
                .ThenInclude(i => i.Team);
            ;
            ViewBag.Teams = dbContext.Teams
                // Including the navigation property of "HeroesOnTeam" in the Team class
                .Include(t => t.HeroesOnTeam)
                // Including the navigation property of "Hero" in the HeroOnTeam class that was already included
                .ThenInclude(i => i.Hero);
            return View("Index");
        }

        [HttpGet("heroes/new")]
        public ViewResult NewHero()
        {
            return View("NewHero");
        }

        [HttpPost("heroes/create")]
        public IActionResult CreateHero(Hero FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Heroes.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NewHero();
            }
        }

        [HttpGet("teams/new")]
        public ViewResult NewTeam()
        {
            return View("NewTeam");
        }
        [HttpPost("teams/create")]
        public IActionResult CreateTeam(Team FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Teams.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NewTeam();
            }
        }

        [HttpPost("teams/join")]
        public IActionResult JoinTeam(HeroOnTeam FromForm)
        {
            if(ModelState.IsValid)
            {
                // BONUS: Uniqueness check to prevent duplicate Many To Many entries
                if(dbContext.HeroesOnTeam.Any(h => h.HeroId == FromForm.HeroId && h.TeamId == FromForm.TeamId))
                {
                    ModelState.AddModelError("HeroId", "That hero is already on that team.");
                    return Index();
                }

                dbContext.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }
    }
}