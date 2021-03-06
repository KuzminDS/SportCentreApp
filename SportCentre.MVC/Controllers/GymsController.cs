using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportCentre.MVC.Models;

namespace SportCentre.MVC.Controllers
{
    public class GymsController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        // GET: Gyms
        public ActionResult Index()
        {
            var gyms = db.Gyms.Include(g => g.Sport);
            return View(gyms.ToList());
        }

        // GET: Gyms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = db.Gyms.Find(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // GET: Gyms/Create
        public ActionResult Create()
        {
            ViewBag.IdSport = new SelectList(db.Sports, "Id", "Name");
            return View();
        }

        // POST: Gyms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BeginningOfWork,WorkingHours,IdSport")] Gym gym)
        {
            if (ModelState.IsValid)
            {
                db.Gyms.Add(gym);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSport = new SelectList(db.Sports, "Id", "Name", gym.IdSport);
            return View(gym);
        }

        // GET: Gyms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = db.Gyms.Find(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSport = new SelectList(db.Sports, "Id", "Name", gym.IdSport);
            return View(gym);
        }

        // POST: Gyms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BeginningOfWork,WorkingHours,IdSport")] Gym gym)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gym).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSport = new SelectList(db.Sports, "Id", "Name", gym.IdSport);
            return View(gym);
        }

        // GET: Gyms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = db.Gyms.Find(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // POST: Gyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gym gym = db.Gyms.Find(id);
            db.Gyms.Remove(gym);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
