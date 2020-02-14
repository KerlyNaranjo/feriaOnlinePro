using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App1
{
	public partial class mantenimiento : System.Web.UI.Page
	{
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
	}
}