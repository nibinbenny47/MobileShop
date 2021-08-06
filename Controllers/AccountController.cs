using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;
namespace MobileShop.Controllers
{
    public class AccountController : Controller
    {
        private MobileShopDbEntities db = new MobileShopDbEntities();
        // GET: Account
        //-----login-------
        public ActionResult Index()
        {

            return View();
        }
        //-----user registration----
        public ActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(tbl_User user)
        {
            db.tbl_User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}