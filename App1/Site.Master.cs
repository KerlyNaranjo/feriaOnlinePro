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
	public partial class SiteMaster : MasterPage		
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			this.menuadmin.Visible = false;
			this.lblcerrar.Visible = false;
			if (Session["usuario"].ToString() != "")
				{
					this.lbluser.Text = Session["usuario"].ToString();
					this.lblregistro.Visible = false;
					this.lblres.Visible = false;
					this.lblcerrar.Visible = true;
					cargarcarrito();
				    cargarpedidos();
					if (Session["idrol"].ToString() == "2")
					{
						this.menuadmin.Visible = true;
					}
					else
					{
						this.menuadmin.Visible = false;
					}
				}
				else
				{
					this.lblregistro.Visible = true;
					this.lblres.Visible = true;
					lblcarrito.Text = "0";
				}

			
						 
		}
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		public void cargarcarrito()
		{
			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null;

			cmd = new SqlCommand("SELECT SUM(CANDET) AS TOTAL FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED WHERE IDCLI ='" + Session["idusu"].ToString() + "' AND P.ESTPED <> 3", cnn);
			try
			{
				 
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					Session["total"] = dr["TOTAL"].ToString(); 
					lblcarrito.Text = Session["total"].ToString();
				}			
			}
			catch (Exception ex)
			{
				mimensaje("Contacte con su administrador" + ex);
			}
		}

		public void cargarpedidos()
		{
			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null;

			cmd = new SqlCommand("SELECT TOP 1 IDPED  FROM PEDIDO  WHERE IDCLI ='"+Session["idusu"].ToString()+"'  AND ESTPED =1 ORDER BY IDPED DESC", cnn);
			try
			{
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					Session["idpedido"] = dr["IDPED"].ToString();
				}
				else
				{
					Session["idpedido"] = "";
				}
			}
			catch (Exception ex)
			{
				mimensaje("Contacte con su administrador" + ex);
			}
			cnn.Close();
		}

	}
}