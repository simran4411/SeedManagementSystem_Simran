using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeedManagementSystem_Simran.Models;

namespace SeedManagementSystem_Simran.Controllers
{
    [Authorize]
    public class CropRatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CropRates
        public ActionResult Index()
        {
            var cropRates = db.CropRates.Include(c => c.CropVariety);
            return View(cropRates.ToList());
        }

        // GET: CropRates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropRate cropRate = db.CropRates.Find(id);
            if (cropRate == null)
            {
                return HttpNotFound();
            }
            return View(cropRate);
        }

        // GET: CropRates/Create
        public ActionResult Create()
        {
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName");
            return View();
        }

        // POST: CropRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CropVarietyID,Rate,Quantity")] CropRate cropRate)
        {
            if (ModelState.IsValid)
            {
                db.CropRates.Add(cropRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", cropRate.CropVarietyID);
            return View(cropRate);
        }

        // GET: CropRates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropRate cropRate = db.CropRates.Find(id);
            if (cropRate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", cropRate.CropVarietyID);
            return View(cropRate);
        }

        // POST: CropRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CropVarietyID,Rate,Quantity")] CropRate cropRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", cropRate.CropVarietyID);
            return View(cropRate);
        }

        // GET: CropRates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropRate cropRate = db.CropRates.Find(id);
            if (cropRate == null)
            {
                return HttpNotFound();
            }
            return View(cropRate);
        }

        // POST: CropRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropRate cropRate = db.CropRates.Find(id);
            db.CropRates.Remove(cropRate);
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
