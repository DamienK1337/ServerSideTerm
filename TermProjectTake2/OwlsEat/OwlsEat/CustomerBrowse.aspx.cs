﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OwlsEat
{
	public partial class CustomerBrowse : System.Web.UI.Page
	{
		DBConnect objDB = new DBConnect();
		SqlCommand objCommand = new SqlCommand();
		ArrayList UpdateInformationError = new ArrayList();
		protected void Page_Load(object sender, EventArgs e)
		{


			if (!IsPostBack)
			{
				if (string.IsNullOrEmpty(Session["userEmail"] as string))
				{
					Response.Redirect("NoAccess.aspx");
				}
				else
				{
					if (!IsPostBack)
						ShowCuisine();

					divGvRestaurant.Visible = false;
					divCart.Visible = false;

					//ShowRestaurantByCuisine();
				}
			}
		}

		public void ShowCuisine()
		{
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCommand.CommandText = "TPGetCuisineType";

			DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand);

			//for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			//{
			//	ddlCuisine.Items.Insert(i, new ListItem(dataSet.Tables[0].Rows[i][0].ToString()));
			//}

			ddlCuisine.DataTextField = "Cuisine";
			ddlCuisine.DataValueField = "Cuisine";
			ddlCuisine.DataSource = dataSet;
			ddlCuisine.DataBind();

		}

		public void ShowRestaurantByCuisine()
		{

			SqlCommand sqlCommand1 = new SqlCommand();
			sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			string choice = ddlCuisine.SelectedValue;
			objCommand.Parameters.Clear();
			sqlCommand1.CommandText = "TPGetRestaurantsbyCuisine";


			SqlParameter CuisineParam = new SqlParameter("@Cuisine", choice);
			CuisineParam.Direction = System.Data.ParameterDirection.Input;
			CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
			CuisineParam.Size = 50;
			sqlCommand1.Parameters.Add(CuisineParam);



			DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);



			gvRestaurant.DataSource = dataSet;
			gvRestaurant.DataBind();


		}

		protected void ddlCuisine_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowRestaurantByCuisine();
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					string strScript = "uncheckOthers(" + ((CheckBox)e.Row.Cells[0].FindControl("chbxRestaurant")).ClientID + ");";
					((CheckBox)e.Row.Cells[0].FindControl("chbxRestaurant")).Attributes.Add("onclick", strScript);
				}
			}
			catch (Exception Ex)
			{
				//report error
			}
		}

		protected void btnSelectRestaurant_Click(object sender, EventArgs e)
		{
			ArrayList arrProducts = new ArrayList();    // used to store the ProductNumber for each selected product
			int count = 0;                              // used to count the number of selected products
			int RID;                                            // Iterate through the rows (records) of the GridView and store the ProductNumber
																// for each row that is checked

			for (int row = 0; row < gvRestaurant.Rows.Count; row++)
			{
				CheckBox CBox;
				// Get the reference for the chkSelect control in the current row

				CBox = (CheckBox)gvRestaurant.Rows[row].FindControl("chbxRestaurant");
				if (CBox.Checked)

				{
					string ItemID = "";
					// Get the ProductNumber from the BoundField from the GridView for the current row

					// and store the value in the array of selected products.

					ItemID = gvRestaurant.Rows[row].Cells[1].Text;
					arrProducts.Add(ItemID);
					count = count + 1;
					//	lbltest.Text = arrProducts[0].ToString();

					string RestaurantName = arrProducts[0].ToString();

					//lbltest.Text = RestaurantName;

					objCommand.CommandType = CommandType.StoredProcedure;
					objCommand.CommandText = "TPGetRestaurantIdUsingRestaurantName";


					objCommand.Parameters.AddWithValue("@RestaurantName", RestaurantName);
					DataSet dataset = objDB.GetDataSetUsingCmdObj(objCommand);



					RID = (int)objDB.GetField("RestaurantId", 0);

					//lbltest.Text = RID.ToString();

					objCommand.Parameters.Clear();

					objCommand.CommandType = CommandType.StoredProcedure;
					objCommand.CommandText = "TPGetMenusByRestarauntID";


					objCommand.Parameters.AddWithValue("@RestaurantId", RID.ToString());



					ddlMenu.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
					ddlMenu.DataTextField = "MenuName";
					ddlMenu.DataValueField = "MenuId";
					ddlMenu.DataBind();


				}

			}

		}

		protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
		{

			string Menuid = ddlMenu.SelectedValue;

			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetMenuItemsbyMenuId";


			objCommand.Parameters.AddWithValue("@MenuID", Menuid);
			DataSet dataset = objDB.GetDataSetUsingCmdObj(objCommand);

			gvMenuItems.DataSource = dataset;
			gvMenuItems.DataBind();



		}

		protected void btnAddToCart_Click(object sender, EventArgs e)
		{
			ArrayList arrayMenuItems = new ArrayList();    // used to store the ProductNumber for each selected product

			int count = 0;                              // used to count the number of selected products
			ArrayList OrderItems = new ArrayList(Items);                                            // Iterate through the rows (records) of the GridView and store the ProductNumber
																									// for each row that is checked


			for (int row = 0; row < gvMenuItems.Rows.Count; row++)
			{
				CheckBox CBox;
				// Get the reference for the chkSelect control in the current row

				CBox = (CheckBox)gvMenuItems.Rows[row].FindControl("chbxMenuItems");
				if (CBox.Checked)

				{
					String MenuItemName = "";
					// Get the ProductNumber from the BoundField from the GridView for the current row

					// and store the value in the array of selected products.

					Items selectedItem = new Items();

					selectedItem.ItemID = gvMenuItems.Rows[row].Cells[1].Text;
					selectedItem.RestaurantId = gvMenuItems.Rows[row].Cells[2].Text;
					selectedItem.Title = gvMenuItems.Rows[row].Cells[3].Text;
					selectedItem.ImgURL = gvMenuItems.Rows[row].Cells[4].Text;
					selectedItem.Description = gvMenuItems.Rows[row].Cells[5].Text;
					string price = gvMenuItems.Rows[row].Cells[6].Text.Split('$')[1];
					selectedItem.Price = float.Parse(price);

					OrderItems.Add(selectedItem);

					MenuItemName = gvMenuItems.Rows[row].Cells[1].Text;
					arrayMenuItems.Add(MenuItemName);
					count = count + 1;
					//lbltest.Text = arrayMenuItems[1].ToString();



					Session.Add("Cart", OrderItems);
					lbltest.Text = Session["Cart"].ToString();

					Items newItems = Session["Cart"] as Items;

					gvCart.DataSource = newItems;
					gvCart.DataBind();





				}

			}

		}

		protected void lnkBtnBrowse_Click(object sender, EventArgs e)
		{
			divGvRestaurant.Visible = true;
			divCart.Visible = false;
		}

		protected void lnkBtnPurchase_Click(object sender, EventArgs e)
		{

			divGvRestaurant.Visible = false;
			divCart.Visible = true;

			ArrayList CustCart = new ArrayList(Items);

			CustCart = (ArrayList)Session["Cart"];

			gvCart.DataSource = CustCart;
			gvCart.DataBind();

			float OrderTotal = 0;
			

			for (int row = 0; row < gvCart.Rows.Count; row++)
			{
				string price = gvCart.Rows[row].Cells[6].Text.Split('$')[1];
				OrderTotal = OrderTotal + float.Parse(price);

			}

			LblOrderTotal.Text = OrderTotal.ToString();


		}
		protected void lnkBtnManageOrder_Click(object sender, EventArgs e)
		{

		}

		protected void btnRemoveITems_Click(object sender, EventArgs e)
		{
			ArrayList CustCart = new ArrayList(Items);

			CustCart = (ArrayList)Session["Cart"];

			for (int row = 0; row < gvCart.Rows.Count; row++)
			{
				CheckBox CBox;
				// Get the reference for the chkSelect control in the current row

				CBox = (CheckBox)gvCart.Rows[row].FindControl("chbxDeleteCartItem");
				if (CBox.Checked)

				{
					//LblCartTest.Text = row.ToString();
					//LblCartTest.Text = CustCart.Count.ToString();
					CustCart.RemoveAt(row);
					Session.Add("Cart", CustCart);

					


				}

			}


			gvCart.DataSource = CustCart;
			gvCart.DataBind();

		}

		protected void btnPlaceOrder_Click(object sender, EventArgs e)
		{

			float OrderTotal = 0;
			string addMoney = "Please add funds to Account";
			string RestaurantId = "";
			string RestaurantVWID = "";

			for (int row = 0; row < gvCart.Rows.Count; row++)
			{
				RestaurantId = gvCart.Rows[row].Cells[2].Text;
				string price = gvCart.Rows[row].Cells[6].Text.Split('$')[1];
				OrderTotal = OrderTotal + float.Parse(price);

			}

			LblCartTest.Text = GetVirtualWalletID(RestaurantId);
			RestaurantVWID = GetVirtualWalletID(RestaurantId);

			if (OrderTotal > GetCurrentBalance(Session["userVWID"].ToString()))
			{
				LblCartTest.Text = addMoney;
			}

			else
			{
				Merchant CurrMerchant = new Merchant();
				APIKey CurrAPIKey = new APIKey();

				CurrMerchant.MerchantID = "78735";
				CurrAPIKey.Key = "7636";


				

				Transactions newTransaction = new Transactions();

				newTransaction.VWIDSender = Session["userVWID"].ToString();
				newTransaction.VWIDReceiver = RestaurantVWID;
				newTransaction.Amount = OrderTotal.ToString();
				newTransaction.Type = "Payment";


				JavaScriptSerializer js = new JavaScriptSerializer();  //Converts Object into JSON String
				String jsonTransaction = js.Serialize(newTransaction);

				try
				{
					String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tuf05666/WebAPI/api/service/PaymentGateway/ProcessPayment";

					url = url + "/" + CurrMerchant.MerchantID + "/" + CurrAPIKey.Key;

					WebRequest request = WebRequest.Create(url);
					request.Method = "POST";

					request.ContentLength = jsonTransaction.Length;
					request.ContentType = "application/json";


					StreamWriter writer = new StreamWriter(request.GetRequestStream());
					writer.Write(jsonTransaction);
					writer.Flush();
					writer.Close();

					WebResponse response = request.GetResponse();
					Stream theDataStream = response.GetResponseStream();
					StreamReader reader = new StreamReader(theDataStream);
					String data = reader.ReadToEnd();
					reader.Close();
					response.Close();
					if (data == "true")
					{
						Response.Write("Funds added");
					}
					else
					{
						Response.Write("Error Occured on the database.");
					}
				}
				catch (Exception errorException)
				{
					Response.Write(errorException.Message);
				}
			}
			
		}


			

		public float GetCurrentBalance(string VWID)
		{
			float CurrentBalance=0;

			DataSet MyCurrentBalance = new DataSet();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetCurrentBalance";
			objCommand.Parameters.Clear();


			objCommand.Parameters.AddWithValue("@VWID", VWID);
			MyCurrentBalance = objDB.GetDataSetUsingCmdObj(objCommand);

			foreach (DataRow record in MyCurrentBalance.Tables[0].Rows)
			{

				string gcb = record["Balance"].ToString();

				CurrentBalance = int.Parse(gcb);

			}

			return CurrentBalance;
		}


		public string GetVirtualWalletID(string RestaurantId)
		{
			string id = "";
			DataSet MyCurrentBalance = new DataSet();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetVWID";
			objCommand.Parameters.Clear();


			objCommand.Parameters.AddWithValue("@RestaurantId", RestaurantId);
			MyCurrentBalance = objDB.GetDataSetUsingCmdObj(objCommand);

			foreach (DataRow record in MyCurrentBalance.Tables[0].Rows)
			{

				 id = record["VWID"].ToString();

				

			}

			return id;

		}






	}
}
