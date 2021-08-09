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

        public ActionResult Buy(tbl_Booking tbl_Booking)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var tbl_Product = db.tbl_Product.Where(x => x.product_Id == id).FirstOrDefault();
            //tbl_Product tbl_Product = db.tbl_Product.Find(id);
            //tbl_Product tbl_Product = db.tbl_Product.Where(x => x.product_Id == id).FirstOrDefault();

            //if (tbl_Product == null)
            //{
            //    return HttpNotFound();
            //}
            return View(tbl_Booking);
        }
        [HttpPost]
        public ActionResult Buy(tbl_Booking booking, int id)
        {
            //var  tbl_Product = db.tbl_Booking.Include("tbl_Product").Include("tbl_User").Where(x => x.product_Id == id).FirstOrDefault();
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            int userid = Convert.ToInt32(Session["uid"]);
            var total=tbl_Product.product_Price;
            int grandtotal = Convert.ToInt32(total);
            //var total = tbl_Product.tbl_Product.product_Price;

            if (ModelState.IsValid)
            {
                booking.product_Id = id;
                booking.booking_Total = booking.booking_Quantity * grandtotal;
                booking.user_Id = userid;
                db.tbl_Booking.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index","User");
            }
            return View(tbl_Product);

        }

        public ActionResult ViewProfile()
        {
            int userid = Convert.ToInt32(Session["uid"]);
            var result = (tbl_User)db.tbl_User.Where(x =>x.user_Id ==userid).FirstOrDefault();
            return View(result);
        }

    }
}