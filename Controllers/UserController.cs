using System;
using System.Collections.Generic;
using System.Linq;
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
      

    }
}