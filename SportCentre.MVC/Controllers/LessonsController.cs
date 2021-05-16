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
    public class LessonsController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        // GET: Lessons
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Group).Include(l => l.Gym).Include(l => l.Trainer);
            return View(lessons.ToList());
        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name");
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name");
            ViewBag.IdTrainer = new SelectList(db.Trainers, "Id", "FirstName");
            return View();
        }

        // POST: Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdGroup,Beginning,Duration,IdTrainer,IdGym")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", lesson.IdGroup);
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", lesson.IdGym);
            ViewBag.IdTrainer = new SelectList(db.Trainers, "Id", "FirstName", lesson.IdTrainer);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", lesson.IdGroup);
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", lesson.IdGym);
            ViewBag.IdTrainer = new SelectList(db.Trainers, "Id", "FirstName", lesson.IdTrainer);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdGroup,Beginning,Duration,IdTrainer,IdGym")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", lesson.IdGroup);
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", lesson.IdGym);
            ViewBag.IdTrainer = new SelectList(db.Trainers, "Id", "FirstName", lesson.IdTrainer);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
