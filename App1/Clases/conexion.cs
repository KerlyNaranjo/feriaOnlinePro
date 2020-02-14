using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App1.Clases
{
	public class conexion
	{
		public string Conexion()
		{
			// return @"DATA SOURCE = CARTERA-LP;INITIAL CATALOG=OPTICA;INTEGRATED SECURITY=TRUE ";
		//	return @"DATA SOURCE = 192.168.10.204;INITIAL CATALOG=CARRITO;INTEGRATED User ID=sa; Password=AdminCoimpexa.;";

			return @"server=192.168.10.204;Database=carrito;User id=sa;Password=AdminCoimpexa.;";
			///"Data Source=192.168.0.1;Initial Catalog=master;User ID=sa;Password=TuContraseña;Application Name=MyApp")
		}

	}
}