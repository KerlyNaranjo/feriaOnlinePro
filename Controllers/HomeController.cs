using LoginArtesanos.Models;
using LoginArtesanos.Repositorio;
using LoginArtesanos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FeriaOnline.Controllers
{
    public class HomeController : Controller
    {
        FERIA_ARTESANALEntities db = new FERIA_ARTESANALEntities();
        MainModel Modelo = new MainModel();

        //lo utilizan como login
        public ActionResult Index()
        {
            Modelo.Productos = db.Productos.ToList();

            return View(Modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Artesano()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Usuario()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Verproducto(int Id) { 
        
            Modelo.Producto = db.Productos.FirstOrDefault(x => x.IdProducto == Id);

            return View(Modelo);

        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = "Cierre de sesión correcta.";

            return RedirectToAction("Index", "Home");
        }
        
    }
}