using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult Education()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skills()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult Interests()
        {
            var values = db.TblInterests.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certificates()
        {
            var values = db.TblCertificates.ToList();
            return PartialView(values);
        }

        //Sayfamız yüklendiği zaman çıkacak
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        //Sayfada etkileşime girildiğinde burası çalışacak
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            //Ekleme işlemi yapmadan önce bugünün kısa tarihini getir
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}