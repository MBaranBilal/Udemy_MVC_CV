using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy_MVC_CV.Repositories;

namespace Udemy_MVC_CV.Controllers
{
    public class IletisimController : Controller
    {
        iletisimRepository repo=new iletisimRepository();
        // GET: Iletisim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}