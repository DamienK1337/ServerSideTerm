using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OwlsEat
{
    public partial class RestaurantManageOrders : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        ArrayList UpdateInformationError = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["userEmail"] as string))
            {
                Response.Redirect("NoAccess.aspx");
            }
            ViewOrders.Visible = false;
            if (!IsPostBack)

            {

                string strSQL = "SELECT * FROM TPOrders";
                gvOrders.DataSource = objDB.GetDataSet(strSQL);
                gvOrders.DataBind();
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);


                // Select the status of OrderID in DropDownList
                string Status = (e.Row.FindControl("lblStatus") as Label).Text;
                ddlStatus.Items.FindByValue(Status).Selected = true;

                string OrderID = (e.Row.FindControl("lblOrderID") as Label).Text;
                ddlStatus.Items.FindByText(Status).Selected = true;
                
            }
        }


        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlStatus = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;

            Label lblOrderID = (Label)row.FindControl("lblOrderID");

            string text = ddlStatus.SelectedItem.Text;
            string value = ddlStatus.SelectedItem.Value;

            string OrderID = lblOrderID.Text;

            lblOrderID.Text = OrderID;

            ViewOrders.Visible = true; //Event Code here.

            //string status = ddlStatus.SelectedIndex.ToString();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPUpdateOrderStatus";

            objCommand.Parameters.AddWithValue("@Status", text);


            //objCommand.Parameters[0].Value = s;
            objCommand.Parameters.AddWithValue("@OrderID", OrderID);
            var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
            objCommand.Parameters.Clear();
            if (ResponseReceived == 1)
            {
                string strSQL = "SELECT * FROM TPOrders";
                gvOrders.DataSource = objDB.GetDataSet(strSQL);
                gvOrders.DataBind();
                lblConfirm.Text = "Thank you for Updating the Order!";
                lblConfirm.Visible = true;
            }


            else
            {

                lblConfirm.Text = "Failed";
                lblConfirm.Visible = true;

            }
        }


        protected void lnkBtnViewCurrentOrders_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ViewOrders.Visible = true;
        }
    }
}
