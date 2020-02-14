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
	public partial class pedidos : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			this.divdetalle.Visible = false;
			this.divdetalle1.Visible = false;
			idv3.Visible = false;
			if (Session["usuario"].ToString() != "")
			{
				lblep.Text = "";
				cargardatos();
			}
			else
			{
				lblep.Text = "Debe Iniciar Sesión para vizualizar sus pedidos";
			}
		}
		 
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}

		public void cargardatos()
		{
			idv3.Visible = false;
			this.divdetalle1.Visible = true;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
				{
					try
					{
						cnn.Open();
						SqlCommand cmd = new SqlCommand("SELECT P.IDPED,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET*D.CANDET * D.IVADET ),2 ) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 0 THEN 'ENTREGADO' WHEN P.ESTPED = 2 THEN 'APROBADO'END AS ESTADO FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO=D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI=P.IDCLI WHERE P.IDCLI = '" + Session["idusu"].ToString() + "' AND ESTPED=1  GROUP BY P.IDPED ,CONCAT (NOMCLI,' ',APECLI), P.ESTPED  ", cnn);
					    //SqlCommand cmd = new SqlCommand("SELECT P.IDPED,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET * D.CANDET * D.IVADET), 2) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 0 THEN 'ENTREGADO'END AS ESTADO FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED = P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO = D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI = P.IDCLI WHERE P.IDCLI = '" + Session["idusu"].ToString() + "' AND ESTPED = 1  GROUP BY P.IDPED, CONCAT(NOMCLI,' ', APECLI), P.ESTPED", cnn);

					cmd.ExecuteNonQuery();
						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						da.Fill(dt);

						rptPedidos.DataSource = dt;
					    rptPedidos.DataBind();

					}
					catch (Exception ex)
					{
						mimensaje("" + ex.Message.ToString());
					}
				}
			
		}
		public void cargardetalle(int idp)
		{
			idv3.Visible = false;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					//SqlCommand cmd = new SqlCommand("  = '" + Session["idusu"].ToString() + ", cnn);
					SqlCommand cmd = new SqlCommand("SELECT D.IDDET, PR.IDPRO, PR.IMG, PR.DESPRO, D.PUDET, D.CANDET, (D.PUDET * D.CANDET) AS SUBTOTAL, (D.PUDET * D.CANDET * D.IVADET) AS TOTAL FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED = P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO = D.IDPRO WHERE IDCLI = '" + Session["idusu"].ToString()+"' AND P.IDPED = "+idp+"", cnn);
					cmd.ExecuteNonQuery();	

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					rptPedidosDetalle.DataSource = dt;
					rptPedidosDetalle.DataBind();  
				}
				catch (Exception ex1)
				{
					lblerror.Text = ex1.Message.ToString();
				}
				
				cnn.Close();
			}
		}
		public void confirmarpedido(string idp, string lat, string lon, string dir, string fp)
		{ 

			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					///mimensaje("Pedid "+lat+" lon "+lon +"dir "+dir);
					cnn.Open(); 
					SqlCommand cmd = new SqlCommand(" UPDATE PEDIDO SET ESTPED = 2 , PGPED= '" + fp + "', DIRPED= '" + dir+ "' , LATPED = '" + lat + "', LOGPED = '" + lon + "'   WHERE IDPED = " + idp + "", cnn);
					cmd.ExecuteNonQuery();
					cargardatos();
					mimensaje("Pedido aprobado con exito");
					cnn.Close();
				}
				catch (Exception ex)
				{
					//mimensaje("" + ex.Message.ToString());
					lblerror.Text=""+ex.Message.ToString();
				}
			}
		}
		protected void btneli_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string idp = btn.CommandArgument;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM PEDIDO WHERE IDPED = " + idp + "", cnn);
					cmd.ExecuteNonQuery();
					mimensaje("Pedido eliminado con exito");
				}
				catch (Exception ex)
				{
					mimensaje("" + ex.Message.ToString());
				}
			}
		}
		protected void btncon_Click(object sender, EventArgs e)
		{
			idv3.Visible = true;
			ImageButton btn = (ImageButton)(sender);
			string ac = btn.CommandArgument;
			//confirmarpedido(Int32.Parse(ac));
			//Response.Write("<script> $('#desp').modal({backdrop: 'static', keyboard: false});</script>");
			txtidpd.InnerHtml = ac;

		}
		protected void btnelipro_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string idp= btn.CommandArgument;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM DETALLEPEDIDO WHERE IDDET = " + idp + "", cnn);
					cmd.ExecuteNonQuery();
					mimensaje("Producto eliminado con exito");
				}
				catch (Exception ex)
				{
					mimensaje("" + ex.Message.ToString());
				}
			}
		}
		protected void btnver_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string ac = btn.CommandArgument;
			this.divdetalle.Visible = true;
			cargardetalle(Int32.Parse(ac));
			//mimensaje("ID PRO   " + ac);
		}
		protected void btnguardardireccion_Click(object sender, EventArgs e)
		{
			string fp = this.conbpago.SelectedItem.ToString();
			idv3.Visible = true;
			if (txtde.Value.Equals(""))
			{
				lbled.Text = "Ingrese una dirección de entrega";
			}
			else
			{
				lbled.Text = ""; 
				confirmarpedido(txtidpd.InnerHtml, lbllat.Value, lbllog.Value, txtde.Value, fp);
			}
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			lbled.Text = "Ingrese una dirección de entrega";
		}
	}
}