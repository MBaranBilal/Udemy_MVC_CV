using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();
        // GET: Sertifika
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarim s = repo.Find(x => x.ID == id);
            repo.TDelete(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim s)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifikalarim s=repo.Find(x => x.ID == id);
            return View(s);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim s)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            TblSertifikalarim guncel = repo.Find(x => x.ID == s.ID);
            guncel.Tarih = s.Tarih;
            guncel.Aciklama = s.Aciklama;
            repo.TUpdate(guncel);
            return RedirectToAction("Index");
        }

    }
}