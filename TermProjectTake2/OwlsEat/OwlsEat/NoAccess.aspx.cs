using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OwlsEat
{
	public partial class NoAccess : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnGoToLogin_Click(object sender, EventArgs e)
		{
			Response.Redirect("Login.aspx");
		}
	}
}