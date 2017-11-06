using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperFancyWeb.Models;

namespace SuperFancyWeb.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public IActionResult Index()
        {
            var person = new Person()
            {
                Name = "Hans",
                Description = "Eene omgesiuhvet",
                Age = 1249,
                Ammount = 122
            };
            
            return View(person);
        }

        public string Hello(string name, int id = 20)
        {
            return HtmlEncoder.Default.Encode($"De naam is: {name}, je id is {id}");
        }

        // GET: Welcome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Welcome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Welcome/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Welcome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Welcome/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Welcome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Welcome/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}