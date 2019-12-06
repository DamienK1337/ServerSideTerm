using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OwlsEat
{
	public partial class CustomerBrowse : System.Web.UI.Page
	{
		DBConnect objDB = new DBConnect();
		SqlCommand objCommand = new SqlCommand();
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
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				ddlCuisine.Items.Insert(i, new ListItem(dataSet.Tables[0].Rows[i][0].ToString()));
			}
			//ddlCuisine.DataSource = dataSet;
			//ddlCuisine.DataBind();

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
														// Iterate through the rows (records) of the GridView and store the ProductNumber
														// for each row that is checked

			for (int row = 0; row < gvRestaurant.Rows.Count; row++)
			{
				CheckBox CBox;
				// Get the reference for the chkSelect control in the current row

				CBox = (CheckBox)gvRestaurant.Rows[row].FindControl("chbxRestaurant");
				if (CBox.Checked)

				{
					String ItemID = "";
					// Get the ProductNumber from the BoundField from the GridView for the current row

					// and store the value in the array of selected products.

					ItemID = gvRestaurant.Rows[row].Cells[1].Text;
					arrProducts.Add(ItemID);
					count = count + 1;
					lbltest.Text = arrProducts[0].ToString();



					SqlCommand sqlCommand1 = new SqlCommand();
					sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
					string RestaurantName = arrProducts[0].ToString();
					objCommand.Parameters.Clear();
					sqlCommand1.CommandText = "TPGetRestaurantIdUsingRestaurantName";


					SqlParameter CuisineParam = new SqlParameter("@RestaurantName", RestaurantName);
					CuisineParam.Direction = System.Data.ParameterDirection.Input;
					CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
					CuisineParam.Size = 50;
					sqlCommand1.Parameters.Add(CuisineParam);

					DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);

					

				}




			}






		}








	}
}
