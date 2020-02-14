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
	public partial class pedidos2 : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			this.divdetalle.Visible = false;
			this.divdetalle1.Visible = false;
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
			this.divdetalle1.Visible = true;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("SELECT P.IDPED,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET*D.CANDET * D.IVADET ),2 ) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 0 THEN 'ENTREGADO' WHEN P.ESTPED = 2 THEN 'APROBADO'END AS ESTADO FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO=D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI=P.IDCLI WHERE P.IDCLI = '" + Session["idusu"].ToString() + "' AND ESTPED=2  GROUP BY P.IDPED ,CONCAT (NOMCLI,' ',APECLI), P.ESTPED  ", cnn);
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
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					//SqlCommand cmd = new SqlCommand("  = '" + Session["idusu"].ToString() + ", cnn);
					SqlCommand cmd = new SqlCommand("SELECT D.IDDET, PR.IDPRO, PR.IMG, PR.DESPRO, D.PUDET, D.CANDET, (D.PUDET * D.CANDET) AS SUBTOTAL, (D.PUDET * D.CANDET * D.IVADET) AS TOTAL FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED = P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO = D.IDPRO WHERE IDCLI = '" + Session["idusu"].ToString() + "' AND P.IDPED = " + idp + "", cnn);
					cmd.ExecuteNonQuery();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);
					rptPedidosDetalle.DataSource = dt;
					rptPedidosDetalle.DataBind();
				}
				catch (Exception ex)
				{
					mimensaje("" + ex.Message.ToString());
				}
				string lat = "", lon = "";
				SqlCommand cmd2 = null;
				SqlDataReader dr = null;
				cmd2 = new SqlCommand("SELECT IDPED, DIRPED, LATPED, LOGPED FROM PEDIDO WHERE IDPED=" + idp + "", cnn);
				try
				{
					dr = cmd2.ExecuteReader();
					if (dr.Read() == true)
					{
						txtdire.Text = dr["DIRPED"].ToString();
						lat = dr["LATPED"].ToString();
						lon = dr["LOGPED"].ToString();
						lblcp.Text = dr["IDPED"].ToString();
					 
					}
					else
					{
						mimensaje("Consulte con su administrador");
					}
				}

				catch (Exception ex)
				{
					lblerror.Text = ex.Message.ToString();
				}
			}
		}
		public void confirmarpedido(int idp)
		{

			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(" UPDATE PEDIDO SET ESTPED = 2 WHERE IDPED = " + idp + "", cnn);
					cmd.ExecuteNonQuery();
					mimensaje("Pedido aprobado con exito");
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

		protected void Button1_Click(object sender, EventArgs e)
		{
			int cal = 0;
			int idp = Int32.Parse(lblcp.Text);
			if (this.rbb.Checked== true) {
				cal = 1;
			}
			if (this.rbr.Checked == true)
			{
				cal = 2;
			}
			if (this.rbm.Checked == true)
			{
				cal = 3;
			}
			if(cal == 0) {
				mimensaje("Seleccione un opcion de calificación");
            }
            else
		    {
				using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
				{
					try
					{
						cnn.Open();
						SqlCommand cmd = new SqlCommand(" UPDATE PEDIDO SET CALPED =" + cal + ", COMPED= '"+this.txtcp.Value+"' WHERE IDPED = " + idp + "", cnn);
						cmd.ExecuteNonQuery();
						mimensaje("Pedido calificado con exito");
					}
					catch (Exception ex)
					{
						mimensaje("" + ex.Message.ToString());
					}
				}
			}
		}
	}
}