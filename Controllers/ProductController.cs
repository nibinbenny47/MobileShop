using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MobileShop.Models;
using System.Net;

namespace MobileShop.Controllers
{
    public class ProductController : Controller
    {
        private MobileShopDbEntities db = new MobileShopDbEntities();
        // GET: Product
        public ActionResult Index()
        {
            var result = db.tbl_Product.Include("tbl_Company").ToList();

            return View(result);
        }
        public ActionResult Create()
        {
            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file,tbl_Product product)
        {
            string filename = Path.GetFileName(file.FileName);
            product.product_Image = filename;
            string path = Path.Combine(Server.MapPath("~/Photos"), filename);
            file.SaveAs(path);
            db.tbl_Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //------delete-----
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
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            db.tbl_Product.Remove(tbl_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //---edit ------
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
            //----dropdown company names---------
            ViewBag.company_Id = new SelectList(db.tbl_Company, "company_Id", "company_Name", tbl_Product.company_Id);
            return View(tbl_Product);
        }
    }
}