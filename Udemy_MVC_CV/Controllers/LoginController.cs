using Udemy_MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Mvc5Cv.Controllers
{
    
    [AllowAnonymous] 
    public class LoginController : Controller
    {

        DinamikCVEntities db = new DinamikCVEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p1)
        {
            var login = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == p1.KullaniciAdi && x.Sifre == p1.Sifre);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.KullaniciAdi, false); 
                return RedirectToAction("Index", "Hakkımda"); 
            }
            else
            {
                return RedirectToAction("Index", "Login"); 
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); 
            Session.Abandon(); 
            return RedirectToAction("Index", "Login");
        }
    }
}