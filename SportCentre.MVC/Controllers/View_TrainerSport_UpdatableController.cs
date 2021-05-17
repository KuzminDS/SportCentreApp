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
    public class View_TrainerSport_UpdatableController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        // GET: View_TrainerSport_Updatable
        public ActionResult Index()
        {
            return View(db.View_TrainerSport_Updatable.ToList());
        }

        // GET: View_TrainerSport_Updatable/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_TrainerSport_Updatable view_TrainerSport_Updatable = db.View_TrainerSport_Updatable.Find(id);
            if (view_TrainerSport_Updatable == null)
            {
                return HttpNotFound();
            }
            return View(view_TrainerSport_Updatable);
        }

        // GET: View_TrainerSport_Updatable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: View_TrainerSport_Updatable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Age,Name")] View_TrainerSport_Updatable view_TrainerSport_Updatable)
        {
            if (ModelState.IsValid)
            {
                db.View_TrainerSport_Updatable.Add(view_TrainerSport_Updatable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_TrainerSport_Updatable);
        }

        // GET: View_TrainerSport_Updatable/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_TrainerSport_Updatable view_TrainerSport_Updatable = db.View_TrainerSport_Updatable.Find(id);
            if (view_TrainerSport_Updatable == null)
            {
                return HttpNotFound();
            }
            return View(view_TrainerSport_Updatable);
        }

        // POST: View_TrainerSport_Updatable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,Age,Name")] View_TrainerSport_Updatable view_TrainerSport_Updatable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_TrainerSport_Updatable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_TrainerSport_Updatable);
        }

        // GET: View_TrainerSport_Updatable/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_TrainerSport_Updatable view_TrainerSport_Updatable = db.View_TrainerSport_Updatable.Find(id);
            if (view_TrainerSport_Updatable == null)
            {
                return HttpNotFound();
            }
            return View(view_TrainerSport_Updatable);
        }

        // POST: View_TrainerSport_Updatable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            View_TrainerSport_Updatable view_TrainerSport_Updatable = db.View_TrainerSport_Updatable.Find(id);
            db.View_TrainerSport_Updatable.Remove(view_TrainerSport_Updatable);
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
