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
        DbPortfolioEntities db = new DbPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values = db.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.SocialMedia.Where(x => x.Durum == true).ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Education()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skills()
        {
            var values = db.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult Interests()
        {
            var values = db.Interest.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certificates()
        {
            var values = db.Certificates.ToList();
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
        public PartialViewResult Contact(Contact t)
        {
            //Ekleme işlemi yapmadan önce bugünün kısa tarihini getir
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}
