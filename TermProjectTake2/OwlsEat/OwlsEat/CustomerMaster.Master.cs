using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace OwlsEat
{
    public partial class CustomerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["userEmail"] as string))
            {
                Response.Redirect("NoAccess.aspx");
            }
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            Session["userEmail"] = null;
            Session["userPassword"] = null;
            Session["userType"] = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}