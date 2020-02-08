using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryFeriaOnline.COMUN
{
    public class cm_ClsUsuario
    {
        private int idUsuario;
        private string NombreUser;
        private string Apellido;
        private string TipoDocumento;
        private string NumeroDocumento;
        private string Correo;
        private string Usuario;
        private string Clave;
        private int IdRol; //Comerciante 1, Artesano 2

        public cm_ClsUsuario()
        {
        }

        public cm_ClsUsuario(int idUsuario, string nombre, string apellido, string tipoDocumento, string numeroDocumento, string correo, string usuario, string clave, int idRol)
        {
            this.idUsuario = idUsuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.TipoDocumento = tipoDocumento;
            this.NumeroDocumento = numeroDocumento;
            this.Correo = correo;
            this.Usuario = usuario;
            this.Clave = clave;
            this.IdRol = idRol;
        }

        public cm_ClsUsuario(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public cm_ClsUsuario(int idUsuario, string nombre, string apellido, int idRol)
        {
            this.idUsuario = idUsuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdRol = idUsuario;
        }

        //getter and setter
        public string Nombre{
            get { return Nombre;}
            set { Nombre = value; }
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Apellido1
        {
            get
            {
                return Apellido;
            }

            set
            {
                Apellido = value;
            }
        }

        public string TipoDocumento1
        {
            get
            {
                return TipoDocumento;
            }

            set
            {
                TipoDocumento = value;
            }
        }

        public string Correo1
        {
            get
            {
                return Correo;
            }

            set
            {
                Correo = value;
            }
        }

        public string Usuario1
        {
            get
            {
                return Usuario;
            }

            set
            {
                Usuario = value;
            }
        }

        public string Clave1
        {
            get
            {
                return Clave;
            }

            set
            {
                Clave = value;
            }
        }

        public int IdRol1
        {
            get
            {
                return IdRol;
            }

            set
            {
                IdRol = value;
            }
        }
    }
}