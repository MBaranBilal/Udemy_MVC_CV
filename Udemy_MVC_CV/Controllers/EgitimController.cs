using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepository repo=new EgitimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TblEgitim e = repo.Find(x=>x.ID==id);
            repo.TDelete(e);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var degerler=repo.Find(x=>x.ID==id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TblEgitim e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            TblEgitim guncel = repo.Find(x => x.ID == e.ID);
            guncel.Baslik=e.Baslik;
            guncel.AltBaslik1 = e.AltBaslik1;
            guncel.AltBaslik2= e.AltBaslik2;
            guncel.GNO=e.GNO;
            guncel.Tarih=e.Tarih;
            repo.TUpdate(guncel);
            return RedirectToAction("Index");
        }
    }
}