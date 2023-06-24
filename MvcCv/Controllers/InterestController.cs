using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class InterestController : Controller
    {
        GenericRepository<Interest>  repo = new GenericRepository<Interest>();

        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }

        [HttpPost]
        public ActionResult Index(Interest p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
           
        }
    }
}