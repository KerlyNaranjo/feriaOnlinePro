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
	public partial class detproducto : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.Params["idpro"] != null)
			{
				int  idp = Int32.Parse( Request.Params["idpro"]);
				cargardatos(idp);
			}
			else
			{
			}
		}
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		public void cargardatos(int idp) {

			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null;

			cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE IDPRO='" + idp + "'", cnn);
			try
			{
				 
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					lbldes.Text = "Producto: "+dr["DESPRO"].ToString();
					lblprecio.Text =dr["PREPRO"].ToString();
					img1.ImageUrl = dr["IMG"].ToString(); ;
				}
				else
				{
					mimensaje("Usuario / Contraseña incorectos.");
				}
			}
			catch (Exception ex)
			{
				mimensaje("Verifique sus datos dentro del catcha..." + ex);
			}
		}

		protected void btnatras_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("Default.aspx");
		}

		public void guardarpedido(string idcli, int idpro, int cant, float precio, int idped)
		{
			//mimensaje(" CLI" +idcli+" id pro  "+idpro + " can  " + cant + " precio  " + precio + " id ped  " + idped);
			try
			{
				SqlConnection cnn = new SqlConnection(conex.Conexion());
				cnn.Open();
				SqlCommand cmd = new SqlCommand("SP_PEDIDO", cnn);
				cmd.Parameters.Add("@IDCLI", SqlDbType.VarChar, 25).Value = idcli;
				cmd.Parameters.Add("@IDPRO", SqlDbType.Int).Value = idpro;
				cmd.Parameters.Add("@CANT", SqlDbType.Int).Value = cant;
				cmd.Parameters.Add("@PRECIO", SqlDbType.Float).Value = precio;
				cmd.Parameters.Add("@IDPEDIDO", SqlDbType.Int).Value =idped;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.ExecuteNonQuery();				 
			    mimensaje("Producto agregado al carrito"); 
				cnn.Close();
			}
			catch (Exception ex)
			{
				mimensaje("Verifique sus datos dentro del catcha..." + ex);
			}		 
	   }
		protected void btncarrito_Click(object sender, ImageClickEventArgs e)
		{
			if (Session["usuario"].ToString() != "")
			{
				string idcli = Session["idusu"].ToString();
				int idpro = Int32.Parse(Request.Params["idpro"]);
				int cant = Int32.Parse(this.txtnum.Value);
				float precio = (float)Convert.ToDouble(this.lblprecio.Text);
				if (Session["idpedido"].ToString() == "")
				{
					Session["idpedido"] = 0;
				}
				int idped = Int32.Parse(Session["idpedido"].ToString());
				guardarpedido(idcli, idpro, cant, precio, idped);
			}
			else
			{ 
	           mimensaje( "Debe Iniciar Sesión para vagregar productos al carrito");
			}



		}
	}
}