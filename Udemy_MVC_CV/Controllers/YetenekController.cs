using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var degerler=repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYetenek p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniYetenek");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYetenek y = repo.Find(x => x.ID == id);
            repo.TDelete(y);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TblYetenek yeniYetenek=repo.Find(x=>x.ID==id);
            return View(yeniYetenek);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TblYetenek p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniYetenek");
            }
            TblYetenek yetenek=repo.Find(x=>x.ID == p.ID);
            yetenek.Yetenek=p.Yetenek;
            yetenek.Oran=p.Oran;
            repo.TUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}