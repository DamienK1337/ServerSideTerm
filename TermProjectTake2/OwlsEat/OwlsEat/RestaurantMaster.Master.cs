using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OwlsEat
{
    public partial class RestaurantMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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