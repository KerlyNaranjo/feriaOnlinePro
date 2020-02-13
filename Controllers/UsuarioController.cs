using LoginArtesanos.Models;
using LoginArtesanos.Repositorio;
using LoginArtesanos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginArtesanos.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        MainModel Modelo = new MainModel();
        public FERIA_ARTESANALEntities db = new FERIA_ARTESANALEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }

            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

            if (Modelo.Usuario.IdRol == (int)Utils.Categorias.ARTESANO)
            {
                return RedirectToAction("Index", "Artesano", Modelo);
            }

            return View(Modelo);
        }
    }
}