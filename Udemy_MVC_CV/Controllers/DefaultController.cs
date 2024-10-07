using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Models.Entity;

namespace Udemy_MVC_CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DinamikCVEntities db=new DinamikCVEntities();

        public ActionResult Index()
        {
            var degerler=db.TblHakkinda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var values=db.TblDeneyimlerim.ToList();
            return PartialView(values);
        }

        public PartialViewResult Egitim()
        {
            var values=db.TblEgitim.ToList();
            return PartialView(values);
        }

        public PartialViewResult Yeteneklerim() 
        {
            var values=db.TblYetenek.ToList();
            return PartialView(values);
        }

        public PartialViewResult Hobilerim()
        {
            var values=db.TblHobilerim.ToList();
            return PartialView(values);
        }

        public PartialViewResult Sertifikalarım() 
        {
            var values=db.TblSertifikalarim.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TblIletisim iletisim)
        {
            iletisim.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(iletisim);
            db.SaveChanges();
            return PartialView();
        }

    }
}