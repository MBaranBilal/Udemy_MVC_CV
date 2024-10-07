using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo=new DeneyimRepository();
        // GET: Deneyim
        public ActionResult Index()
        {
            var deneyimler=repo.List();
            return View(deneyimler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("DeneyimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t=repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t=repo.Find(x=>x.ID==id);
            return View(t);
        }
        
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("DeneyimGetir");
            }
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Aciklama=p.Aciklama;
            t.Tarih=p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}