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
	public partial class registro : System.Web.UI.Page
	{
		Clases.conexion conex = new Clases.conexion();
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public void mimensaje(string men)
		{
			Response.Write("<script>window.alert('" + men + "');</script>");
		}

		public bool validarcedula(char[] validarCedula)
		{
			int aux = 0, par = 0, impar = 0, verifi;
			for (int i = 0; i < 9; i += 2)
			{
				aux = 2 * int.Parse(validarCedula[i].ToString());
				if (aux > 9)
					aux -= 9;
				par += aux;
			}
			for (int i = 1; i < 9; i += 2)
			{
				impar += int.Parse(validarCedula[i].ToString());
			}

			aux = par + impar;
			if (aux % 10 != 0)
			{
				verifi = 10 - (aux % 10);
			}
			else
				verifi = 0;
			if (verifi == int.Parse(validarCedula[9].ToString()))
				return true;
			else
				return false;
		}


		public int validarcedula2(string ced)
		{
			char[] valced = new char[9];
			int par = 0, impar = 0, res = 0 , respuesta = 0;
			int x;
			if (ced.Length < 10)
			{
				x = 0;
				//mimensaje("Cédula incorrecta.");
			}
			else
			{
				valced = ced.Trim().ToCharArray();
				string valor = ""; 
				for (int j = 0; j <  ced.Length; j++)
				{
					if ((j % 2) == 0)
					{
						valor = valced[j].ToString();
						par = par + int.Parse(valor);
					}
					else
					{
						valor = valced[j].ToString();
						impar = int.Parse(valor);
					}
				}
				res = par - impar;
				respuesta = par - res;
				if (impar == respuesta)
				{
					x = 1;

				}
				else
				{
					x = 0;
					//mimensaje("Cédula incorrecta.");
				}
				
			}
			return x;
		}
		public void guardarregistros(string ced, string nom, string ape,string dir, string ema, string pass ,string tel) {
			using (SqlConnection cnn = new SqlConnection(conex.Conexion()))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand(" INSERT INTO CLIENTES ([IDCLI] ,[NOMCLI] ,[APECLI],[DIRCLI] ,[FECCLI] ,[ESTCLI] ,[EMACLI],[TELCLI]) VALUES ( '" + ced + "','" + nom + "','" + ape + "','" + dir + "',GETDATE(), 1,'" + ema + "','" + tel + "')", cnn);
					cmd.ExecuteNonQuery();
					 
					SqlCommand cmd2 = new SqlCommand(" INSERT INTO USUARIO ([USU] ,[IDROL] ,[PASS] ,[ESTUSU]) VALUES ('" + ema+ "',1, '" + pass + "',1 )", cnn);
					cmd2.ExecuteNonQuery();
					mimensaje("Registro Exitoso");
					//Response.Redirect("login.aspx");
					cnn.Close();
					lblerror.Text = "";
				}
				catch (Exception ex)
				{
					//mimensaje("" + ex.Message.ToString());
					lblerror.Text = ex.Message.ToString();
				}
			}

		}

		protected void btnguardar_Click(object sender, EventArgs e)
		{
			char[] valced = new char[13];
			valced = txtced.Value.Trim().ToCharArray();
			if (validarcedula(valced) == true)
			{
				//mimensaje("Cédula Correcta");
				if (txtpass.Text == txtpass2.Text)
				{
					valpass.Text = "";
					guardarregistros(txtced.Value, txtnom.Value, txtape.Value, txtdir.Value, txtema.Text, txtpass.Text, txttel.Value);

				}
				else
				{
					valpass.Text = "Las contaseñas no coinciden.";
				}

			}
			else
			{
				mimensaje("Cédula inCorrecta");
			}

		}

		protected void btncancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("registro.aspx");
		}
	}
}