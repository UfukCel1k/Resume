using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ID == p.ID);
            t.Heading = p.Heading;
            t.subtitle = p.subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}