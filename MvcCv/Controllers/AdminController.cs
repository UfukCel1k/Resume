using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Login> repo = new GenericRepository<Login>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Login p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveAdmin(int id)
        {
            Login t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            Login t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Login p)
        {
            Login t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}