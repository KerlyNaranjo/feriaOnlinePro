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
	public partial class solpedidos2 : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["usuario"].ToString() != "" && Session["idrol"].ToString() == "2")
			{
				 

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
					SqlCommand cmd = new SqlCommand("SELECT P.IDPED, COMPED , PGPED,CASE WHEN CALPED=1 THEN 'EXCELENTE' WHEN CALPED=2 THEN 'REGULAR'WHEN CALPED=1 THEN 'MALO' END AS CALI  ,CONCAT (NOMCLI,' ',APECLI) AS CLIENTE, SUM (D.CANDET) AS CANTIDAD , ROUND(SUM(D.PUDET*D.CANDET ) , 2) AS SUBTOTAL,ROUND(SUM(D.PUDET*D.CANDET * D.IVADET ),2 ) AS TOTAL ,CASE WHEN P.ESTPED = 1 THEN 'PENDIENTE' WHEN P.ESTPED = 3 THEN 'ENTREGADO' WHEN P.ESTPED = 2 THEN 'APROBADO'END AS ESTADO ,(SELECT CONCAT(NOMREP,' ',APEREP) FROM REPARTIDOR WHERE IDREP =P.IDREP) AS REPARTIDOR FROM PEDIDO P INNER JOIN DETALLEPEDIDO D ON D.IDPED=P.IDPED INNER JOIN PRODUCTOS PR ON PR.IDPRO=D.IDPRO INNER JOIN CLIENTES C ON C.IDCLI=P.IDCLI WHERE ESTPED <> 1 AND CAST(FECPED AS DATE) BETWEEN  '" + fi + "' AND '" + ff + "' GROUP BY P.IDPED ,CONCAT (NOMCLI,' ',APECLI), P.ESTPED ,P.IDREP ,COMPED,PGPED,CALPED", cnn);
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


		protected void btnbuscar_Click(object sender, ImageClickEventArgs e)
		{
			cargardatos(this.txtfi.Value, txtff.Value);
		}
	}
}