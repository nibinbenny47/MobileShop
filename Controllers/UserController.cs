using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;



namespace MobileShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private MobileShopDbEntities db = new MobileShopDbEntities();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult Redmi()
        {
            var result = db.tbl_Product.Where(x => x.company_Id == 2).ToList();
            return PartialView("_ProductCard", result);

        }
        public PartialViewResult Samsung()
        {
            var result = db.tbl_Product.Where(x => x.company_Id == 1).ToList();
            return PartialView("_ProductCard", result);

        }
        public PartialViewResult Oppo()
        {
            var result = db.tbl_Product.Where(x => x.company_Id == 3).ToList();
            return PartialView("_ProductCard", result);

        }
        //-----buy products-----

        //public ActionResult Buy(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_Product tbl_Product = db.tbl_Product.Find(id);
        //    if (tbl_Product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_Product);
        //}
        //[HttpPost]
        //public ActionResult Buy(tbl_Booking booking, int id)
        //{
        //    tbl_Product tbl_Product = db.tbl_Product.Find(id);
        //    var total = db.tbl_Booking.Include("tbl_Product").ToList();

        //    if (ModelState.IsValid)
        //    {
        //        booking.product_Id = tbl_Product.product_Id;
        //        booking.booking_Total =

        //    }


        //}

    }
}