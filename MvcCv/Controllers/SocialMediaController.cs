using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSocialMedia(int id)
        {
            var values = repo.Find(x => x.ID == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult GetSocialMedia(SocialMedia p)
        {
            var values = repo.Find(x => x.ID == p.ID);
            values.Name = p.Name;
            values.Durum = true;
            values.Link = p.Link;
            values.İcon = p.İcon;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveSocialMedia(int id)
        {
            var values  = repo.Find(x =>x.ID == id);
            values.Durum = false;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}