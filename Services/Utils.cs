using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginArtesanos.Services
{
    public static class Utils
    {
        public static string ReturnUniqueId()
        {
            int longitud = new Random().Next(30, 40);
            Guid miGuid = Guid.NewGuid();
            Guid miGuid2 = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "").Replace("\\", "").Replace("/", "");

            string token2 = Convert.ToBase64String(miGuid2.ToByteArray());
            token2 = token2.Replace("=", "").Replace("+", "").Replace("\\", "").Replace("/", "");

            string token3 = ($"{DateTime.Now.Ticks.ToString()}{token}{token2}");

            return token3.Substring(0, longitud);
        }

        public enum Categorias {
            ARTESANO = 1, CONSUMIDOR
        }
    }
}