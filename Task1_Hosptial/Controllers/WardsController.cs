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
    public class WardsController : Controller
    {
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Wards
        public ActionResult Index()
        {
            var wards = db.Wards.Include(w => w.Hospital);
            return View(wards.ToList());
        }

        // GET: Wards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // GET: Wards/Create
        public ActionResult Create()
        {
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WardId,WardName,HospitalId")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.Wards.Add(ward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", ward.HospitalId);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", ward.HospitalId);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WardId,WardName,HospitalId")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", ward.HospitalId);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return HttpNotFound();
            }
            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ward ward = db.Wards.Find(id);
            db.Wards.Remove(ward);
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
