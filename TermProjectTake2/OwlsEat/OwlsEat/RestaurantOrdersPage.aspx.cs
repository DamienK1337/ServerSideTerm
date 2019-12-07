using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OwlsEat
{
    public partial class RestaurantOrdersPage : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {


			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();

			string strSQL = "SELECT * FROM TPOrders";
			rptOrders.DataSource = objDB.GetDataSet(strSQL);
			rptOrders.DataBind();




			if (!IsPostBack)

            {
                //DBConnect objDB = new DBConnect();
                //SqlCommand objCommand = new SqlCommand();

                //string strSQL = "SELECT * FROM TPOrders";

                //objCommand.CommandType = CommandType.StoredProcedure;
                //objCommand.CommandText = "TPGetOrders";
                //objCommand.Parameters.Clear();

                //objCommand.Parameters.AddWithValue("@RestaurantID", Session["userID"].ToString());


                //DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                // Set the datasource of the Repeater and bind the data

                //rptOrders.DataSource = objDB.GetDataSet(strSQL);
                //rptOrders.DataBind();

            }
        }

        protected void lnkBtnViewOrders_Click(object sender, EventArgs e)
        {
           
        }
        protected void rptOrders_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)

        {

            // Retrieve the row index for the item that fired the ItemCommand event

            int rowIndex = e.Item.ItemIndex;


            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblItemID");
            String ItemID = myLabel.Text;


            lblDisplay.Text = "You selected ItemID " + ItemID;

        }
    }
}