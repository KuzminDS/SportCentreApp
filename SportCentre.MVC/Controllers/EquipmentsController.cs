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
    public class EquipmentsController : Controller
    {
        private SportCentreEntities db = new SportCentreEntities();

        // GET: Equipments
        public ActionResult Index()
        {
            var equipments = db.Equipments.Include(e => e.Gym).Include(e => e.Inventory);
            return View(equipments.ToList());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name");
            ViewBag.IdInventory = new SelectList(db.Inventories, "Id", "Name");
            return View();
        }

        // POST: Equipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdGym,IdInventory")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", equipment.IdGym);
            ViewBag.IdInventory = new SelectList(db.Inventories, "Id", "Name", equipment.IdInventory);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", equipment.IdGym);
            ViewBag.IdInventory = new SelectList(db.Inventories, "Id", "Name", equipment.IdInventory);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdGym,IdInventory")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGym = new SelectList(db.Gyms, "Id", "Name", equipment.IdGym);
            ViewBag.IdInventory = new SelectList(db.Inventories, "Id", "Name", equipment.IdInventory);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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
