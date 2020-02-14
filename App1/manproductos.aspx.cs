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
	public partial class manproductos : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{
		   	if (Session["usuario"].ToString() != "" && Session["idrol"].ToString() == "2")
				{

					this.divdetalle.Visible = false;
					cargardatos();

				}
				else
				{
					Response.Redirect("Default.aspx");
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
					SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE ESTPRO <> 0", cnn);
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
		public void cargardatos2(int idp)
		{
			this.divdetalle.Visible = true;
			this.divdetalle1.Visible = true; 
			SqlConnection cnn = new SqlConnection(conex.Conexion());
			cnn.Open();
			SqlCommand cmd = null;
			SqlDataReader dr = null;
			cmd = new SqlCommand("SELECT * FROM PRODUCTOS WHERE IDPRO="+idp+"", cnn);
			try
			{
				dr = cmd.ExecuteReader();
				if (dr.Read() == true)
				{
					txtdes.Value = dr["DESPRO"].ToString();
					txtpre.Value = dr["PREPRO"].ToString();
					txtpeso.Value = dr["PESPRO"].ToString();
					txtstock.Value = dr["STOCKPRO"].ToString();
					this.cbxestado.SelectedItem.Value = dr["ESTPRO"].ToString();
					imgpro.Src = dr["IMG"].ToString();
					lblidp.Text= dr["IDPRO"].ToString();

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
		protected void btnver_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string ac = btn.CommandArgument;
			this.divdetalle.Visible = true;
		    cargardatos2(Int32.Parse(ac));
			 
		}
		protected void btnguardar_Click(object sender, EventArgs e)
		{
			if (txtdes.Value.Equals("") && txtpre.Value.Equals("") && txtstock.Value.Equals("") && txtpeso.Value.Equals(""))
			{
				mimensaje("Todos los campos son requeridos.");
			}
			else {

			if (lblidp.Text.Equals(""))
			{
				if (subir() == "")
				{
					/// INSERTAMOS DATOS 

					using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
					{
						string est = this.cbxestado.SelectedItem.Value;
						subir();
						string ruta = lgen.Text;
						try
						{
							cnn.Open();
							SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTOS ([DESPRO],[PREPRO],[STOCKPRO],[FECPRO],[ESTPRO],[IMG],[DESPROP],[PESPRO]) VALUES ('" + txtdes.Value + "'," + txtpre.Value + "," + txtstock.Value + ",GETDATE(), " + est + ",'" + ruta + "',0," + txtpeso.Value + ")", cnn);
							cmd.ExecuteNonQuery();
							mimensaje("Producto registrado correctamente.");
							cnn.Close();
							lblerror.Text = "";
							cargardatos();
						}
						catch (Exception ex)
						{
							lblerror.Text = ex.Message.ToString();
						}
					}
				}
				else
				{
					mimensaje(""+ subir().ToString());
				}
			}
			else {
				using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
				{
					string est = this.cbxestado.SelectedItem.Value;
					subir();
					string ruta = lgen.Text;
					float pre = float.Parse(txtpre.Value);
					float peso = float.Parse(txtpeso.Value);
					float st= float.Parse(txtstock.Value);
					int idp = Int32.Parse(lblidp.Text);
					try
					{
						cnn.Open();
						SqlCommand cmd = new SqlCommand("UPDATE PRODUCTOS SET PESPRO = " +peso + ",STOCKPRO = " + st+ ", DESPRO = '" + txtdes.Value + "', PREPRO = " + pre+", ESTPRO="+ est + ",IMG ='"+ ruta + "' WHERE IDPRO = "+idp+" ", cnn);
						cmd.ExecuteNonQuery();
						mimensaje("Producto Modificado correctamente.");
						cnn.Close();
						lblerror.Text = "";
						cargardatos();
					}
					catch (Exception ex)
					{
						lblerror.Text = ex.Message.ToString();
					}
				}
			}
			}
		}
		public string subir()
		{
			string res = "";
			if (fileimg.HasFile)
			{
				// Se verifica que la extensión sea de un formato válido
				
				string ext = fileimg.PostedFile.FileName;
				string rutas = fileimg.FileName;
				ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
				string[] formatos =
				  new string[] { "jpg", "jpeg", "bmp", "png", "gif" , "webp" };
				if (Array.IndexOf(formatos, ext) < 0)
				{
					//Response.Write("<script language=javascript>alert('Formato de imagen inválido.');</script>");
					res = "Formato de imagen inválido Formatos aceptados -> jpg, jpeg, bmp, png, gif";
				}
				else
				{
					string ruta = Server.MapPath("/img");

					// Si el directorio no existe, crearlo
					if (!Directory.Exists(ruta))
						Directory.CreateDirectory(ruta);

					string archivo = String.Format("{0}\\{1}", ruta, fileimg.FileName);

					// Verificar que el archivo no exista
					if (File.Exists(archivo))
					{
						// MensajeError(String.Format(
						//Response.Write("<script language=javascript>alert('Ya existe una imagen con nombre " + fileimg.FileName + "');</script>");
						//res = "Ya existe una imagen con nombre " + fileimg.FileName + "";
						 string foto = "/img/" + rutas;
						 fileimg.SaveAs(archivo);
						 lgen.Text = foto;
					}
					else
					{
						string foto = "/img/" + rutas;
						fileimg.SaveAs(archivo);
						lgen.Text = foto;
					}
				}

			}
			else
			{
				//Response.Write("<script language=javascript>alert('No ha seleccionado  ninguna imagen.');</script>");
				res = "No ha seleccionado  ninguna imagen.";
			}
			return res;
		}

		protected void btnagregar_Click(object sender, EventArgs e)
		{
			this.divdetalle.Visible = true;
			//this.imgpro.Src = "imgs/logo.png";
		}
		protected void btneli_Click(object sender, EventArgs e)
		{
			ImageButton btn = (ImageButton)(sender);
			string idp = btn.CommandArgument;
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				string est = this.cbxestado.SelectedItem.Value;				 
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("UPDATE PRODUCTOS SET ESTPRO = 0 WHERE IDPRO="+idp+" ", cnn);
					cmd.ExecuteNonQuery();
					mimensaje("Producto eliminado correctamente.");
					cnn.Close();
					lblerror.Text = "";
					cargardatos();
				}
				catch (Exception ex)
				{
					lblerror.Text = ex.Message.ToString();
				}
			}


		}
	}
}