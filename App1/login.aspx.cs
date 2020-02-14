using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.IO;

namespace App1
{
	public partial class login : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		protected void btnlogin_Click(object sender, EventArgs e)
		{
			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null; 

			cmd = new SqlCommand("SELECT * FROM USUARIO U , CLIENTES C WHERE USU=C.EMACLI AND ESTUSU=1 AND USU='" + user.Text + "' AND PASS='" + pass.Text + "'", cnn);
			try
			{
				Session["usuario"] = "";
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					Session["usuario"] = dr["NOMCLI"].ToString() + " " + dr["APECLI"].ToString();
					Session["idusu"] = dr["IDCLI"].ToString();
					Session["idrol"] = dr["IDROL"].ToString();
					Response.Redirect("Default.aspx");
				}
				else {
					mimensaje("Usuario / Contraseña incorectos.");
				}
			}
			catch (Exception ex)
			{

				mimensaje("Verifique sus datos dentro del catcha..." + ex);
			}
	 

		}
	}
}