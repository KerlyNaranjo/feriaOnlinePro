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
	public partial class _Default : Page
	{
		Clases.conexion conex = new Clases.conexion();
		//Clases.sql_productos pro = new Clases.sql_productos();
		public static string proid = "";
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			listarproductos();
		}
	 
		protected void listarproductos()
		{
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE ESTPRO=1", cnn);

					cmd.ExecuteNonQuery();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);

					rptProductos.DataSource = dt;
					rptProductos.DataBind();

				}
				catch (Exception ex)
				{
					mimensaje("" + ex.Message.ToString());
				}
			}
		}

		protected void btncarrito_Click(object sender, EventArgs e)
		{			 
			LinkButton btn = (LinkButton)(sender);
			string ac = btn.CommandArgument;
			Response.Redirect("detproducto.aspx?idpro="+ac);

		}
		}
	}
