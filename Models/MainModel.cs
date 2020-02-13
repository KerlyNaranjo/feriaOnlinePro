using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginArtesanos.Models
{
    public class MainModel
    {
        public Usuarios Usuario { get; set; }
        public Productos Producto { get; set; }
        public List<Productos> Productos { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
    }
}