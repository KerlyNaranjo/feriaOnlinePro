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
	public partial class imprimir : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.Params["id"] != null)
			{

				int idp = Int32.Parse(Request.Params["id"]);
				//mimensaje("" + idp);
				cargar(idp);
			}
			else
			{
				
				
			}

		}
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}
		public void cargar(int idp)
		{
			lblnp.Text = idp.ToString();
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open(); 
					//SqlCommand cmd = new SqlCommand("  = '" + Session["idusu"].ToString() + ", cnn);
					SqlCommand cmd = new SqlCommand("SELECT D.IDDET, PR.IDPRO, PR.IMG, PR.DESPRO, D.PUDET, D.CANDET, ROUND ((D.PUDET * D.CANDET),2) AS SUBTOTAL, ROUND ((D.PUDET * D.CANDET * D.IVADET),2) AS TOTAL FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED = P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO = D.IDPRO WHERE  P.IDPED = " + idp + "", cnn);
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
				SqlCommand cmd2 = null;
				SqlDataReader dr = null;
				//cmd2 = new SqlCommand("SELECT * FROM PEDIDO P INNER JOIN CLIENTES C ON P.IDCLI=C.IDCLI WHERE IDPED =" + idp + "", cnn);
				cmd2 = new SqlCommand("SELECT NOMCLI , APECLI,TELCLI,DIRPED, EMACLI ,NOMREP , APEREP, ROUND (sum(D.PUDET * D.CANDET),2) AS SUBTOTAL, ROUND (sum(D.PUDET * D.CANDET * D.IVADET),2) AS TOTAL FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED = P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO = D.IDPRO INNER JOIN CLIENTES C ON P.IDCLI=C.IDCLI INNER JOIN REPARTIDOR R ON P.IDREP=R.IDREP  WHERE P.IDPED = " + idp + " GROUP BY   P.IDPED,  NOMCLI , APECLI, TELCLI,DIRPED ,EMACLI ,NOMREP , APEREP ", cnn);

				try
				{
					dr = cmd2.ExecuteReader();
					if (dr.Read() == true)
					{ 
						lblcli.Text= dr["NOMCLI"].ToString()+" "+ dr["APECLI"].ToString();
						lbltel.Text = dr["TELCLI"].ToString();
						lbldir.Text = dr["DIRPED"].ToString();
						lblema.Text= dr["EMACLI"].ToString();
						lblsub.Text = dr["SUBTOTAL"].ToString();
						lbltotal.Text = dr["TOTAL"].ToString();
						lblre.Text = dr["NOMREP"].ToString() + " " + dr["APEREP"].ToString();
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




	}
}