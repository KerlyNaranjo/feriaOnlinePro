using LoginArtesanos.Models;
using LoginArtesanos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginArtesanos.Repositorio
{
    public class UsuarioRepositorio: Repositorio
    {
        public Usuarios GetUsuarioByClaim(string claimUsuario) {
            Usuarios user = null;

            string[] claim = claimUsuario.Split('|');
            string usuario = claim[1];

            user = db.Usuarios.FirstOrDefault(x => x.Usuario == usuario);

            return user;
        }

        //desencriptar correo
        public Usuarios GetUsuarioByLogin(string correo, string password) {
            Usuarios user = null;

            string _password = Criptografia.CryptData(password);

            user = db.Usuarios.FirstOrDefault(x => x.Correo == correo && x.Clave == _password);

            return user;


        }
    }
}