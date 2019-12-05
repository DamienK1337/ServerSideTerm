using System;
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
			//SqlParameter UsernameParam = new SqlParameter("@Cuisine", ddlCuisine.SelectedValue);
			//objCommand.Parameters.AddWithValue("@Cuisine", choice);

			SqlParameter CuisineParam = new SqlParameter("@Cuisine", choice);
			CuisineParam.Direction = System.Data.ParameterDirection.Input;
			CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
			CuisineParam.Size = 50;
			sqlCommand1.Parameters.Add(CuisineParam);



			DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);

			String[] names = new String[1];

			names[0] = "RestaurantId";
			gvRestaurant.DataKeyNames = names;
			gvRestaurant.DataSource = dataSet;
			gvRestaurant.DataBind();
		}

		protected void ddlCuisine_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowRestaurantByCuisine();
		}

		protected void gvRestaurant_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)

		{

			// Get the index of the row that a command was issued on

			int rowIndex = int.Parse(e.CommandArgument.ToString());

			//int rowIndex = Convert.ToInt32(e.CommandArgument);



			// Get the ProductNumber from the DataKeys colletion of the row

			// The values were previously stored in the DataKeys collection during the DataBind method

			// because the GridView control's property DataKeyNames="ProductNumber"

			String RestaurantId = gvRestaurant.DataKeys[rowIndex].Value.ToString();



			//These IF statements use the GridViewCommandEventArgs object to determine which ButtonField was clicked by the event argument CommandName Property.

			//The value of CommandName Property of the object e corresponds to the value set in the ASPX markup for the ButtonField’s CommandName attribute.


			if (e.CommandName == "ViewMenu")
			{

				lblRestaurantID.Text = RestaurantId;

				SqlCommand sqlCommand1 = new SqlCommand();
				sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
				objCommand.Parameters.Clear();
				sqlCommand1.CommandText = "TPGetRestaurantMenuById";
				//SqlParameter UsernameParam = new SqlParameter("@Cuisine", ddlCuisine.SelectedValue);
				//objCommand.Parameters.AddWithValue("@Cuisine", choice);

				SqlParameter CuisineParam = new SqlParameter("@RestaurantId", RestaurantId);
				CuisineParam.Direction = System.Data.ParameterDirection.Input;
				CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
				CuisineParam.Size = 50;
				sqlCommand1.Parameters.Add(CuisineParam);



				DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);






				//String[] names = new String[1];
				String[] MenuName = new String[1];

				//names[0] = "RestaurantId";
				MenuName[0] = "MenuName";

				gvMenu.DataKeyNames = MenuName;
				//gvMenu.DataKeyNames = names;
				gvMenu.DataSource = dataSet;
				gvMenu.DataBind();
			}

			else

				Label4.Text = "";



		}

		protected void gvMenu_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)

		{

			// Get the index of the row that a command was issued on

			int rowIndex = int.Parse(e.CommandArgument.ToString());

			//int rowIndex = Convert.ToInt32(e.CommandArgument);



			// Get the ProductNumber from the DataKeys colletion of the row

			// The values were previously stored in the DataKeys collection during the DataBind method

			// because the GridView control's property DataKeyNames="ProductNumber"

			String MenuChoice = gvMenu.DataKeys[rowIndex].Value.ToString();



			//These IF statements use the GridViewCommandEventArgs object to determine which ButtonField was clicked by the event argument CommandName Property.

			//The value of CommandName Property of the object e corresponds to the value set in the ASPX markup for the ButtonField’s CommandName attribute.


			if (e.CommandName == "ViewItems")
			{

				lblMenu.Text = MenuChoice;

				SqlCommand sqlCommand1 = new SqlCommand();
				sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
				string choice = ddlCuisine.SelectedValue;
				objCommand.Parameters.Clear();
				sqlCommand1.CommandText = "TPGetRestaurantMenuItemIDs";
				//SqlParameter UsernameParam = new SqlParameter("@Cuisine", ddlCuisine.SelectedValue);
				//objCommand.Parameters.AddWithValue("@Cuisine", choice);

				SqlParameter CuisineParam = new SqlParameter("@RestaurantId", lblRestaurantID.Text);
				SqlParameter CuisineParam2 = new SqlParameter("@MenuName", lblMenu.Text);
				CuisineParam.Direction = System.Data.ParameterDirection.Input;
				CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
				CuisineParam.Size = 50;
				sqlCommand1.Parameters.Add(CuisineParam);
				sqlCommand1.Parameters.Add(CuisineParam2);


				DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);
				string[] Items = new string[dataSet.Tables[0].Rows.Count];
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{

					Items[i] = (dataSet.Tables[0].Rows[i]["ItemId"].ToString());

				}
				Label4.Text = ConvertStringArrayToString(Items);

				//String[] names = new String[1];
				String[] MenuName = new String[1];

				//names[0] = "RestaurantId";
				MenuName[0] = "ItemId";

				gvTest.DataKeyNames = MenuName;
				//gvMenu.DataKeyNames = names;
				gvTest.DataSource = dataSet;
				gvTest.DataBind();

			}
			else

				lblMenu.Text = "";



		}

		public void ShowMenuItems()
		{
			SqlCommand sqlCommand1 = new SqlCommand();
			sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			string choice = ddlCuisine.SelectedValue;
			objCommand.Parameters.Clear();
			sqlCommand1.CommandText = "TPGetRestaurantMenuItemIDs";
			//SqlParameter UsernameParam = new SqlParameter("@Cuisine", ddlCuisine.SelectedValue);
			//objCommand.Parameters.AddWithValue("@Cuisine", choice);

			SqlParameter CuisineParam = new SqlParameter("@RestaurantId", lblRestaurantID.Text);
			SqlParameter CuisineParam2 = new SqlParameter("@MenuName", lblMenu.Text);
			CuisineParam.Direction = System.Data.ParameterDirection.Input;
			CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
			CuisineParam.Size = 50;
			sqlCommand1.Parameters.Add(CuisineParam);
			sqlCommand1.Parameters.Add(CuisineParam2);


			DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);
			string[] Items = new string[dataSet.Tables[0].Rows.Count];
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{

				Items[i] = (dataSet.Tables[0].Rows[i]["ItemId"].ToString());

			}
			Label4.Text = ConvertStringArrayToString(Items);

			//String[] names = new String[1];
			String[] MenuName = new String[1];

			//names[0] = "RestaurantId";
			MenuName[0] = "ItemId";

			gvTest.DataKeyNames = MenuName;
			//gvMenu.DataKeyNames = names;
			gvTest.DataSource = dataSet;
			gvTest.DataBind();

		}

		//protected void gvMenuItems_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)

		//{

		//	// Get the index of the row that a command was issued on

		//	int rowIndex = int.Parse(e.CommandArgument.ToString());

		//	//int rowIndex = Convert.ToInt32(e.CommandArgument);



		//	// Get the ProductNumber from the DataKeys colletion of the row

		//	// The values were previously stored in the DataKeys collection during the DataBind method

		//	// because the GridView control's property DataKeyNames="ProductNumber"

		//	String MenuChoice = gvMenu.DataKeys[rowIndex].Value.ToString();



		//	//These IF statements use the GridViewCommandEventArgs object to determine which ButtonField was clicked by the event argument CommandName Property.

		//	//The value of CommandName Property of the object e corresponds to the value set in the ASPX markup for the ButtonField’s CommandName attribute.


		//	if (e.CommandName == "AddToCart")
		//	{

		//		lblMenu.Text = MenuChoice;

		//		SqlCommand sqlCommand1 = new SqlCommand();
		//		sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
		//		string choice = ddlCuisine.SelectedValue;
		//		objCommand.Parameters.Clear();
		//		sqlCommand1.CommandText = "TPGetRestaurantMenuItemIDs";
		//		//SqlParameter UsernameParam = new SqlParameter("@Cuisine", ddlCuisine.SelectedValue);
		//		//objCommand.Parameters.AddWithValue("@Cuisine", choice);

		//		SqlParameter CuisineParam = new SqlParameter("@RestaurantId", lblRestaurantID.Text);
		//		SqlParameter CuisineParam2 = new SqlParameter("@MenuName", lblMenu.Text);
		//		CuisineParam.Direction = System.Data.ParameterDirection.Input;
		//		CuisineParam.SqlDbType = System.Data.SqlDbType.VarChar;
		//		CuisineParam.Size = 50;
		//		sqlCommand1.Parameters.Add(CuisineParam);
		//		sqlCommand1.Parameters.Add(CuisineParam2);


		//		DataSet dataSet = objDB.GetDataSetUsingCmdObj(sqlCommand1);
		//		string[] Items = new string[dataSet.Tables[0].Rows.Count];
		//		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		//		{

		//			Items[i] = (dataSet.Tables[0].Rows[i]["ItemId"].ToString());

		//		}
		//		Label4.Text = ConvertStringArrayToString(Items);

		//		//String[] names = new String[1];
		//		String[] MenuName = new String[1];

		//		//names[0] = "RestaurantId";
		//		MenuName[0] = "ItemId";

		//		gvTest.DataKeyNames = MenuName;
		//		//gvMenu.DataKeyNames = names;
		//		gvTest.DataSource = dataSet;
		//		gvTest.DataBind();

		//	}
		//	else

		//		lblMenu.Text = "";



		//}

		public string ConvertStringArrayToString(string[] array)
		{
			// Concatenate all the elements into a StringBuilder.
			StringBuilder builder = new StringBuilder();
			foreach (string value in array)
			{
				builder.Append(value);
				builder.Append(", ");
			}
			return builder.ToString();
		}



	}
}