using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task1_Hosptial.Models;

namespace Task1_Hosptial.Controllers
{
    public class SurgeonsController : Controller
    {
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Surgeons
        public ActionResult Index()
        {
            var surgeons = db.Surgeons.Include(s => s.Hospital);
            return View(surgeons.ToList());
        }

        // GET: Surgeons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            return View(surgeon);
        }

        // GET: Surgeons/Create
        public ActionResult Create()
        {
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName");
            return View();
        }

        // POST: Surgeons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurgeonId,Firstname,Lastname,Qualifications,HospitalId")] Surgeon surgeon)
        {
            if (ModelState.IsValid)
            {
                db.Surgeons.Add(surgeon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", surgeon.HospitalId);
            return View(surgeon);
        }

        // GET: Surgeons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", surgeon.HospitalId);
            return View(surgeon);
        }

        // POST: Surgeons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurgeonId,Firstname,Lastname,Qualifications,HospitalId")] Surgeon surgeon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surgeon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", surgeon.HospitalId);
            return View(surgeon);
        }

        // GET: Surgeons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            return View(surgeon);
        }

        // POST: Surgeons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Surgeon surgeon = db.Surgeons.Find(id);
            db.Surgeons.Remove(surgeon);
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
