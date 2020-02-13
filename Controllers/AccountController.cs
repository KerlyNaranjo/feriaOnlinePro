using FeriaOnline.Controllers;
using LoginArtesanos.Models;
using LoginArtesanos.Repositorio;
using LoginArtesanos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginArtesanos.Controllers
{
    public class AccountController : Controller
    {
        FERIA_ARTESANALEntities db = new FERIA_ARTESANALEntities();
        MainModel Modelo = new MainModel();

        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //lo utilizan como login
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

                if (Modelo.Usuario == null)
                {
                    return View();
                }
                else
                {
                    if (Modelo.Usuario.IdRol == 1)
                    {
                        return RedirectToAction("Index", "Artesano", Modelo);
                    }
                    else
                    {
                        return RedirectToAction("Usuario", "Home", Modelo);
                    }
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(String correo, String password)
        {
            Usuarios user = new UsuarioRepositorio().GetUsuarioByLogin(correo, password);


            if (user == null)
            {
                Session["respLogin"] = "El correo o contraseña son incorrectos";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (user.Roles.Nombre.ToUpper() == "ARTESANO")
                {
                    //FormsAuthentication.SetAuthCookie(user.Usuario1, true);
                    FormsAuthentication.Authenticate(user.Usuario, user.Clave);
                    FormsAuthentication.SetAuthCookie(user.Roles.Nombre + "|" + user.Usuario, true);
                    return RedirectToAction("Index", "Artesano");
                }
                else
                {
                    //FormsAuthentication.SetAuthCookie(user.Usuario1, true);
                    FormsAuthentication.Authenticate(user.Usuario, user.Clave);
                    FormsAuthentication.SetAuthCookie(user.Roles.Nombre + "|" + user.Usuario, true);
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Registro()
        {
            var roles = db.Roles.Select(r => r).ToList();

            return View(roles);
        }
        [HttpPost]
        public ActionResult Registro(String Nombre, String Apellido, String TipoDocumento, String NumeroDocumento,
            String Correo, String Usuario, String Password, String PasswordConfirm, String cmbTipoUsuario)
        {
            ActionResult Result;

            try
            {
                if (!Password.Equals(PasswordConfirm)) {
                    throw new ApplicationException("Las contraseñas ingresadas no coinciden.");
                }

                //valida que el correo ingresado no exista
                Usuarios user = db.Usuarios.FirstOrDefault(x => x.Correo == Correo || x.Usuario == Usuario);
                if (user != null) {
                    throw new ApplicationException("El email o nombre de usuario ya se encuentran registrado. Prueba con otros valores");
                }

                Usuarios usuario = new Usuarios();

                usuario.Nombre = Nombre.ToUpper();
                usuario.Apellido = Apellido.ToUpper();
                usuario.TipoDocumento = TipoDocumento.ToUpper();
                usuario.NumeroDocumento = NumeroDocumento;
                usuario.Correo = Correo.ToLower();
                usuario.Usuario = Usuario.ToUpper();
                usuario.Clave = Criptografia.CryptData(Password);
                usuario.IdRol = cmbTipoUsuario == "ARTESANO" ? 1 : 2;

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                Session.Remove("Error");

                return Login(usuario.Correo, Password);
            }
            catch (Exception ex) {
                Session["Error"] = ex.Message;

                Result = RedirectToAction("Registro", "Account", Usuario);
            }

            return Result;
        }
    }
}