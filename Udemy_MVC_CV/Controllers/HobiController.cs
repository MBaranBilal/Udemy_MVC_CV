using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository repo=new HobiRepository();
        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim h)
        {
            var yeni = repo.Find(x => x.ID == 1);
            yeni.Aciklama1 = h.Aciklama1;
            yeni.Aciklama2 = h.Aciklama2; 
            repo.TUpdate(yeni);
            return RedirectToAction("Index");
        }

    }
}