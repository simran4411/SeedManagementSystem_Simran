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
    public class BankPaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankPayments
        public ActionResult Index()
        {
            return View(db.BankPayments.ToList());
        }

        // GET: BankPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankPayment bankPayment = db.BankPayments.Find(id);
            if (bankPayment == null)
            {
                return HttpNotFound();
            }
            return View(bankPayment);
        }

        // GET: BankPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,TransactionDate,TransactionNumber,AmountReceived")] BankPayment bankPayment)
        {
            if (ModelState.IsValid)
            {
                db.BankPayments.Add(bankPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankPayment);
        }

        // GET: BankPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankPayment bankPayment = db.BankPayments.Find(id);
            if (bankPayment == null)
            {
                return HttpNotFound();
            }
            return View(bankPayment);
        }

        // POST: BankPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,TransactionDate,TransactionNumber,AmountReceived")] BankPayment bankPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankPayment);
        }

        // GET: BankPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankPayment bankPayment = db.BankPayments.Find(id);
            if (bankPayment == null)
            {
                return HttpNotFound();
            }
            return View(bankPayment);
        }

        // POST: BankPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankPayment bankPayment = db.BankPayments.Find(id);
            db.BankPayments.Remove(bankPayment);
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
