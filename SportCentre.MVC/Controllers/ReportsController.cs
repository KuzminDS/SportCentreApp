using SportCentre.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportCentre.MVC.Controllers
{
    public class ReportsController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        public ActionResult ClientsBySubscription()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientsBySubscription(string name)
        {
            var clients = db.GetClientsBySubscription(name);
            return View(clients.ToList());
        }

        public ActionResult LessonsBySport()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LessonsBySport(string name)
        {
            var lessons = db.GetLessonsBySport(name);
            return View(lessons.ToList());
        }

        public ActionResult TrainersBySport()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrainersBySport(string name)
        {
            var trainers = db.GetTrainersBySport(name);
            return View(trainers.ToList());
        }
    }
}