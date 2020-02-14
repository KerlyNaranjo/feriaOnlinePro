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
	public partial class solpedidos : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			
			if (Session["usuario"].ToString() != "" && Session["idrol"].ToString()=="2")
			{
				this.divdetalle1.Visible = false;
				this.divdetalle.Visible = false;
				
			}
			else
			{
				Response.Redirect("Default.aspx");
			}
		}

		public void cargardatos(string fi, string ff)
		{
			this.divdetalle1.Visible = true;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("SELECT P.IDPED,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET*D.CANDET * D.IVADET ),2 ) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 3 THEN 'ENTREGADO' WHEN P.ESTPED = 2 THEN 'APROBADO'END AS ESTADO ,(SELECT CONCAT(NOMREP,' ',APEREP) FROM REPARTIDOR WHERE IDREP =P.IDREP) AS REPARTIDOR FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO=D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI=P.IDCLI WHERE ESTPED <> 1 AND CAST(FECPED AS DATE) BETWEEN  '" + fi + "' AND '" + ff+ "' GROUP BY P.IDPED ,CONCAT (NOMCLI,' ',APECLI), P.ESTPED ,P.IDREP ", cnn);
					cmd.ExecuteNonQuery();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					rptPedidos.DataSource = dt;
					rptPedidos.DataBind();
					cnn.Close();
				}
				catch (Exception ex)
				{
					//mimensaje("" + ex.Message.ToString());
					lblerror.Text = ex.Message.ToString();
				}
			}
		}

		public void cargarrepartidor()
		{
			this.divdetalle1.Visible = true;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{ 
					SqlCommand cmd = new SqlCommand("SELECT IDREP, CONCAT(NOMREP,' ', APEREP) AS NOM FROM REPARTIDOR", cnn);
					cmd.CommandType = CommandType.Text;
					cmd.Connection = cnn;
					cnn.Open();
					cbxrepartidor.DataSource = cmd.ExecuteReader();
					cbxrepartidor.DataTextField = "NOM";
					cbxrepartidor.DataValueField= "IDREP";
					cbxrepartidor.DataBind();
					cnn.Close();
				}
				catch (Exception ex)
				{
					lblerror.Text = ex.Message.ToString();
				}
			}
		}

		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
		{
			cargardatos(this.txtfi.Value, txtff.Value);
		}

		protected void btnguardar_Click(object sender, EventArgs e)
		{
			int idp = Int32.Parse(lblidped.Text);
			string idr =  this.cbxrepartidor.SelectedItem.Value;
		  
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open(); 
					SqlCommand cmd = new SqlCommand("UPDATE PEDIDO SET IDREP=" + idr + " WHERE IDPED = " + idp + "", cnn);
					cmd.ExecuteNonQuery(); 
					mimensaje("Repartidor asignado correctamente."); 
					cnn.Close();
					lblerror.Text = "";
					cargardatos(this.txtfi.Value, txtff.Value);
				}
				catch (Exception ex)
				{ 
					lblerror.Text = ex.Message.ToString();
				}
			}
		}
		public void cargardatos2(int idp)
		{
			this.divdetalle.Visible = true;
			this.divdetalle1.Visible = true;
			cargarrepartidor();
			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			  cmd = new SqlCommand("SELECT P.IDPED,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET*D.CANDET * D.IVADET ),2 ) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 3 THEN 'ENTREGADO' WHEN P.ESTPED = 2 THEN 'APROBADO'END AS ESTADO ,(SELECT CONCAT(NOMREP,' ',APEREP) FROM REPARTIDOR WHERE IDREP =P.IDREP) AS REPARTIDOR FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO=D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI=P.IDCLI WHERE  ESTPED <> 1 AND P.IDPED="+idp+" GROUP BY P.IDPED ,CONCAT (NOMCLI,' ',APECLI), P.ESTPED ,P.IDREP ", cnn);
         try
			{
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					lblidped.Text =  dr["IDPED"].ToString();
					lblcli.Text = dr["CLIENTE"].ToString();
					lblcant.Text = dr["CANTIDAD"].ToString();
					lbltotal.Text = dr["TOTAL"].ToString();
					lblra.Text = dr["REPARTIDOR"].ToString();
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
		protected void btnver_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string ac = btn.CommandArgument;
			this.divdetalle.Visible = true;
			cargardatos2(Int32.Parse(ac));
			//mimensaje("ID PRO   " + ac);
		}
		 

	}
}