using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            //Eğer validation durumlar geçerli olmazsa veri girişi yapılmıcak ve aynı sayfaya yönlendirecek.
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation t)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            var education = repo.Find(x => x.ID == t.ID);
            education.Heading = t.Heading;
            education.subtitle1 = t.subtitle1;
            education.subtitle2 = t.subtitle2;
            education.Date = t.Date;
            education.GNO = t.GNO;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}