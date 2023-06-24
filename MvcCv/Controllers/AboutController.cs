using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        DbPortfolioEntities db = new DbPortfolioEntities();
        GenericRepository<About> repo = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(About p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Phone = p.Phone;
            t.Mail = p.Mail;
            t.Description = p.Description;
            t.İmage = p.İmage;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}