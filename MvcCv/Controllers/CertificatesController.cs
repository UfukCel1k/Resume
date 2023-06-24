using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificatesController : Controller
    {

        GenericRepository<Certificates> repo = new GenericRepository<Certificates>();
        public ActionResult Index()
        {
            var certifica = repo.List();
            return View(certifica);
        }

        [HttpGet]
        public ActionResult GetCertificaDetails(int id)
        {
            var certifica = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certifica);
        }

        [HttpPost]
        public ActionResult GetCertificaDetails(Certificates t)
        {
            var certifica = repo.Find(x => x.ID ==  t.ID);
            certifica.Description = t.Description;
            certifica.Date = t.Date;
            repo.TUpdate(certifica);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCertificate(Certificates t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCertificate(int id)
        {
            var certifica = repo.Find(x => x.ID == id);
            repo.TDelete(certifica);
            return RedirectToAction("Index");   
        }
    }
}