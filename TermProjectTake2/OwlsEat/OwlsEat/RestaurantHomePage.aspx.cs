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
    public partial class RestaurantHomePage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
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


            gvRestaurant.DataSource = dataSet;
            gvRestaurant.DataBind();
        }

        protected void ddlCuisine_SelectedIndexChanged(object sender, EventArgs e)
        {

            ShowRestaurantByCuisine();

        }
    }
}