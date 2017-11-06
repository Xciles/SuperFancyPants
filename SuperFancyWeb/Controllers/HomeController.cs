using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperFancyWeb.Models;

namespace SuperFancyWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var x = new { Name = "Hans", Ammount = 400 };

            var list = new List<Person>()
            {
                new Person() { Age = 1, Name = "Test", Description = "Omschrijving", Ammount = 400},
                new Person() { Age = 1, Name = "Test", Description = "Omschrijving", Ammount = 400},
                new Person() { Age = 1, Name = "Test", Description = "Omschrijving", Ammount = 400},
                new Person() { Age = 1, Name = "Test", Description = "Omschrijving", Ammount = 400},
                new Person() { Age = 1, Name = "Test", Description = "Omschrijving", Ammount = 400},
            };

            var result = from person in list
                         select new { person.Name, person.Age };

            foreach (var person in result)
            {
            }




            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
