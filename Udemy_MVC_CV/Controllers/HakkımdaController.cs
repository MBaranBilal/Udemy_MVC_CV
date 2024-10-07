using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        HakkımdaRepository repo = new HakkımdaRepository();
        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TblHakkinda h)
        {
            var yeni = repo.Find(x => x.ID == 1);
            yeni.Aciklama = h.Aciklama;
            yeni.Adres = h.Adres;
            yeni.Ad = h.Ad;
            yeni.Soyad = h.Soyad;
            yeni.Telefon = h.Telefon;
            yeni.Mail = h.Mail;
            yeni.Resim = h.Resim;
            repo.TUpdate(yeni);
            return RedirectToAction("Index");
        }
    }
}