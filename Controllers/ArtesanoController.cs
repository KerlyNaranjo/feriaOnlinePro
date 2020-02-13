using LoginArtesanos.Models;
using LoginArtesanos.Repositorio;
using LoginArtesanos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginArtesanos.Controllers
{
    [Authorize]
    public class ArtesanoController : Controller
    {
        MainModel Modelo = new MainModel();
        public FERIA_ARTESANALEntities db = new FERIA_ARTESANALEntities();
        string RutaSitio = System.Web.Hosting.HostingEnvironment.MapPath("~/");

        // GET: Artesano
        [Authorize]
        public ActionResult Index()
        {

            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

            if (Modelo.Usuario.IdRol == (int)Utils.Categorias.CONSUMIDOR) {
                return RedirectToAction("Index", "Usuario", Modelo);
            }

            Modelo.Productos = db.Productos.Where(x => x.IdUsuario == Modelo.Usuario.IdUsuario).ToList();

            return View(Modelo);
        }

        [HttpGet]
        public ActionResult AgregarProducto() {

            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

            return View(Modelo);
        }

        [HttpPost]
        public ActionResult AgregarProducto(MainModel model)
        {
            model.Producto.IdUsuario = model.Usuario.IdUsuario;

            //subir imagen
            string extension = System.IO.Path.GetExtension(model.Archivo.FileName);
            string nombre = Utils.ReturnUniqueId();
            var InputFileName = Path.GetFileName(model.Archivo.FileName);
            var ServerSavePath = Path.Combine($"{RutaSitio}/Upload/{nombre}{extension}");
            model.Archivo.SaveAs(ServerSavePath);

            model.Producto.Foto = string.Format($"{nombre}{extension}");
            db.Productos.Add(model.Producto);
            db.SaveChanges();

            return RedirectToAction("Index", "Artesano");
        }

        public ActionResult EliminarProducto(int Id) {

            if (!User.Identity.IsAuthenticated) {
                return HttpNotFound();
            }

            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);


            Productos producto = db.Productos.FirstOrDefault(x => x.IdProducto == Id && x.IdUsuario == Modelo.Usuario.IdUsuario);

            if (producto == null)
            {
                return HttpNotFound();
            }

            string rutaImagenes = string.Format($"{RutaSitio}Upload/{producto.Foto}");

            if (System.IO.File.Exists(rutaImagenes))
            {
                System.IO.File.Delete(rutaImagenes);
            }

            db.Entry(producto).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index", "Artesano");
        }

        [HttpGet]
        public ActionResult Editarproducto(int Id) {

            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }
            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

            Modelo.Producto = db.Productos.FirstOrDefault(x => x.IdProducto == Id && x.IdUsuario == Modelo.Usuario.IdUsuario);

            if (Modelo.Producto == null)
            {
                return HttpNotFound();
            }


            return View(Modelo);
        }

        [HttpPost]
        public ActionResult Editarproducto(MainModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return HttpNotFound();
            }

            Modelo.Usuario = new UsuarioRepositorio().GetUsuarioByClaim(User.Identity.Name);

            Productos producto = db.Productos.FirstOrDefault(x => x.IdProducto == model.Producto.IdProducto && x.IdUsuario == Modelo.Usuario.IdUsuario);

            if (producto == null) {
                return HttpNotFound();
            }

            producto.Nombre = model.Producto.Nombre;
            producto.Peso = model.Producto.Peso;
            producto.Stock = model.Producto.Stock;
            producto.Precio = model.Producto.Precio;

            if (model.Archivo != null) {
                string rutaImagenes = string.Format($"{RutaSitio}Upload/{producto.Foto}");

                if (System.IO.File.Exists(rutaImagenes))
                {
                    System.IO.File.Delete(rutaImagenes);
                }

                //subir imagen
                string extension = System.IO.Path.GetExtension(model.Archivo.FileName);
                string nombre = producto.Foto;
                var InputFileName = Path.GetFileName(model.Archivo.FileName);
                var ServerSavePath = Path.Combine($"{RutaSitio}/Upload/{nombre}");
                model.Archivo.SaveAs(ServerSavePath);
            }

            db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Artesano");
        }
    }
}