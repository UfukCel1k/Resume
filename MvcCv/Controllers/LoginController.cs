using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login p)
        {
            DbPortfolioEntities db = new DbPortfolioEntities();
            var value = db.Login.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password); 
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["UserName"] = value.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "About");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}