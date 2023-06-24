using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skill> repo = new GenericRepository<Skill>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(Skill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveSkill(int id)
        {
            //id bulduruyoruz.
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Skills = t.Skills;
            y.Rate = t.Rate;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }


    }
}