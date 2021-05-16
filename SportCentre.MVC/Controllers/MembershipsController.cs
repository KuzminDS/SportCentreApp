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
    public class MembershipsController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        // GET: Memberships
        public ActionResult Index()
        {
            var memberships = db.Memberships.Include(m => m.Client).Include(m => m.Group).Include(m => m.Subscription);
            return View(memberships.ToList());
        }

        // GET: Memberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "FirstName");
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name");
            ViewBag.IdSubscription = new SelectList(db.Subscriptions, "Id", "Type");
            return View();
        }

        // POST: Memberships/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdGroup,IdClient,IdSubscription,ExpirationDate")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "FirstName", membership.IdClient);
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", membership.IdGroup);
            ViewBag.IdSubscription = new SelectList(db.Subscriptions, "Id", "Type", membership.IdSubscription);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "FirstName", membership.IdClient);
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", membership.IdGroup);
            ViewBag.IdSubscription = new SelectList(db.Subscriptions, "Id", "Type", membership.IdSubscription);
            return View(membership);
        }

        // POST: Memberships/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdGroup,IdClient,IdSubscription,ExpirationDate")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "FirstName", membership.IdClient);
            ViewBag.IdGroup = new SelectList(db.Groups, "Id", "Name", membership.IdGroup);
            ViewBag.IdSubscription = new SelectList(db.Subscriptions, "Id", "Type", membership.IdSubscription);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membership membership = db.Memberships.Find(id);
            db.Memberships.Remove(membership);
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
