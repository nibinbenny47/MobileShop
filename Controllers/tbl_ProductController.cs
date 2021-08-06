using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class tbl_ProductController : Controller
    {
        private MobileShopDbEntities db = new MobileShopDbEntities();

        // GET: tbl_Product
        public ActionResult Index()
        {
            var tbl_Product = db.tbl_Product.Include(t => t.tbl_Company).Include(t => t.tbl_Product1).Include(t => t.tbl_Product2);
            return View(tbl_Product.ToList());
        }

        // GET: tbl_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // GET: tbl_Product/Create
        public ActionResult Create()
        {
            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name");
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name");
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name");
            return View();
        }

        // POST: tbl_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(file.FileName);
                tbl_Product.product_Image = filename;
                string path = Path.Combine(Server.MapPath("~/Photos"), filename);
                file.SaveAs(path);
                db.tbl_Product.Add(tbl_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name", tbl_Product.company_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            return View(tbl_Product);
        }

        // GET: tbl_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name", tbl_Product.company_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            return View(tbl_Product);
        }

        // POST: tbl_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_Id,product_Name,product_Price,company_Id,product_Description,product_Image")] tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name", tbl_Product.company_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            ViewBag.product_Id = new SelectList(db.tbl_Product, "product_Id", "product_Name", tbl_Product.product_Id);
            return View(tbl_Product);
        }

        // GET: tbl_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: tbl_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            db.tbl_Product.Remove(tbl_Product);
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
