using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class tbl_CompanyController : Controller
    {
        private MobileShopDbEntities db = new MobileShopDbEntities();

        // GET: tbl_Company
        public ActionResult Index()
        {
            return View(db.tbl_Company.ToList());
        }

        // GET: tbl_Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Company tbl_Company = db.tbl_Company.Find(id);
            if (tbl_Company == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Company);
        }

        // GET: tbl_Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "company_Id,company_Name")] tbl_Company tbl_Company)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Company.Add(tbl_Company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Company);
        }

        // GET: tbl_Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Company tbl_Company = db.tbl_Company.Find(id);
            if (tbl_Company == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Company);
        }

        // POST: tbl_Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "company_Id,company_Name")] tbl_Company tbl_Company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Company);
        }

        // GET: tbl_Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Company tbl_Company = db.tbl_Company.Find(id);
            if (tbl_Company == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Company);
        }

        // POST: tbl_Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Company tbl_Company = db.tbl_Company.Find(id);
            db.tbl_Company.Remove(tbl_Company);
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
