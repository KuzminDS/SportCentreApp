using SportCentre.MVC.Models;
using SportCentre.MVC.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportCentre.MVC.Controllers
{
    public class HomeController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        public ActionResult Index()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        public ActionResult Login([Bind(Include = "Id,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == 0 && user.LastName == "Admin")
                    return View("Admin");

                var client = db.Clients.FirstOrDefault(c => c.Id == user.Id && c.LastName == user.LastName);
                var trainer = db.Trainers.FirstOrDefault(t => t.Id == user.Id && t.LastName == user.LastName);

                if (client != null)
                    return RedirectToAction("Details", "Clients", new { Id = user.Id });

                if (trainer != null)
                    return RedirectToAction("Details", "Trainers", new { Id = user.Id });
            }

            return View("Modal");
        }
    }
}