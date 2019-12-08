﻿using System;
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
                rptOrders.DataSource = objDB.GetDataSet(strSQL);
                rptOrders.DataBind();
            }

        }

        protected void rptOrders_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)

        {

            // Retrieve the row index for the item that fired the ItemCommand event

            int rowIndex = e.Item.ItemIndex;


            // Retrieve a value from a control in the Repeater's Items collection

            Label myLabel = (Label)rptOrders.Items[rowIndex].FindControl("lblOrderID");
            String OrderID = myLabel.Text;


            lblDisplay.Text = "You selected OrderID " + OrderID;

            DropDownList ddlStatus = e.Item.FindControl("ddlStatus") as DropDownList;
            if (ddlStatus != null)
            {

                foreach (RepeaterItem dataItem in rptOrders.Items)
                {
                    string ProductSelected = ((DropDownList)dataItem.FindControl("ddlStatus")).SelectedItem.Text; //No error

                }
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Event Code here.
        }

        protected void lnkBtnViewCurrentOrders_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ViewOrders.Visible = true;
        }
    }
}