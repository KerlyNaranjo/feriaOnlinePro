using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App1.imgs
{
	public partial class cerrar : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.Params["cerrar"] != null)
			{
				Session["usuario"] = "";
				Response.Redirect("../Default.aspx");

			}
			else
			{
				Session["usuario"] = "";
				Response.Redirect("../Default.aspx");

			}

		}
	}
}