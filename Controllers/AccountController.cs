using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;
using System.Web.Security;
namespace MobileShop.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private MobileShopDbEntities db = new MobileShopDbEntities();
        // GET: Account
      
        public ActionResult Index()
        {

            return View();
        }
        //-----login-------
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            if (ModelState.IsValid)
            {
                var result = db.tbl_User.Where(x => x.user_Username.Equals(user.user_Username) && x.user_Password.Equals(user.user_Password)).FirstOrDefault();
                if (result != null)
                {
                    Session["uid"] = user.user_Id.ToString();
                    Session["uname"] = user.user_Name.ToString();
                    
                    return RedirectToAction("Index","Product");
                }
            }
            return View(user);
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