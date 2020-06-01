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
    public class CropVarietiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CropVarieties
        public ActionResult Index()
        {
            var cropVarieties = db.CropVarieties.Include(c => c.Crop);
            return View(cropVarieties.ToList());
        }

        // GET: CropVarieties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropVariety cropVariety = db.CropVarieties.Find(id);
            if (cropVariety == null)
            {
                return HttpNotFound();
            }
            return View(cropVariety);
        }

        // GET: CropVarieties/Create
        public ActionResult Create()
        {
            ViewBag.CropID = new SelectList(db.Crops, "ID", "CropName");
            return View();
        }

        // POST: CropVarieties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CropID,VarietyName")] CropVariety cropVariety)
        {
            if (ModelState.IsValid)
            {
                db.CropVarieties.Add(cropVariety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropID = new SelectList(db.Crops, "ID", "CropName", cropVariety.CropID);
            return View(cropVariety);
        }

        // GET: CropVarieties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropVariety cropVariety = db.CropVarieties.Find(id);
            if (cropVariety == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropID = new SelectList(db.Crops, "ID", "CropName", cropVariety.CropID);
            return View(cropVariety);
        }

        // POST: CropVarieties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CropID,VarietyName")] CropVariety cropVariety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropVariety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropID = new SelectList(db.Crops, "ID", "CropName", cropVariety.CropID);
            return View(cropVariety);
        }

        // GET: CropVarieties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropVariety cropVariety = db.CropVarieties.Find(id);
            if (cropVariety == null)
            {
                return HttpNotFound();
            }
            return View(cropVariety);
        }

        // POST: CropVarieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropVariety cropVariety = db.CropVarieties.Find(id);
            db.CropVarieties.Remove(cropVariety);
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
