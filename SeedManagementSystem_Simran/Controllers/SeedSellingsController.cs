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
    public class SeedSellingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SeedSellings
        public ActionResult Index()
        {
            var seedSellings = db.SeedSellings.Include(s => s.CropVariety).Include(s => s.Customer);
            return View(seedSellings.ToList());
        }

        // GET: SeedSellings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeedSelling seedSelling = db.SeedSellings.Find(id);
            if (seedSelling == null)
            {
                return HttpNotFound();
            }
            return View(seedSelling);
        }

        // GET: SeedSellings/Create
        public ActionResult Create()
        {
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName");
            return View();
        }

        // POST: SeedSellings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,CropVarietyID,NoofBags,Amount")] SeedSelling seedSelling)
        {
            if (ModelState.IsValid)
            {
                db.SeedSellings.Add(seedSelling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", seedSelling.CropVarietyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", seedSelling.CustomerID);
            return View(seedSelling);
        }

        // GET: SeedSellings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeedSelling seedSelling = db.SeedSellings.Find(id);
            if (seedSelling == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", seedSelling.CropVarietyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", seedSelling.CustomerID);
            return View(seedSelling);
        }

        // POST: SeedSellings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,CropVarietyID,NoofBags,Amount")] SeedSelling seedSelling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seedSelling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropVarietyID = new SelectList(db.CropVarieties, "ID", "VarietyName", seedSelling.CropVarietyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "CustomerName", seedSelling.CustomerID);
            return View(seedSelling);
        }

        // GET: SeedSellings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeedSelling seedSelling = db.SeedSellings.Find(id);
            if (seedSelling == null)
            {
                return HttpNotFound();
            }
            return View(seedSelling);
        }

        // POST: SeedSellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeedSelling seedSelling = db.SeedSellings.Find(id);
            db.SeedSellings.Remove(seedSelling);
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
