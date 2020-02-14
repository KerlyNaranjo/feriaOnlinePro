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
	public partial class verpedidos : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{

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
		protected void btnbuscar_Click(object sender, ImageClickEventArgs e)
		{
			 

			mimensaje(""+ this.txtfi.Value);
		}
	}
}