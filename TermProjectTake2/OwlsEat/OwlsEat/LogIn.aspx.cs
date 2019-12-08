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
	public partial class LogIn : System.Web.UI.Page
	{
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

		


        protected void Page_Load(object sender, EventArgs e)
        {
           
            rdoNormalLogin.Checked = true;
            // Read email from cookie
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie myCookie = Request.Cookies["LoginCookie"];
                txtEmail.Text = myCookie.Values["Email"];

            }

                if (txtPassword.Text != "")
                {
                    rdoAutoLogin.Checked = true;
                }
            }
        

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //validate textboxes; done!
            //check if valid user; done!
            //check if there is a username and/or password saved in cookies
            //store userAccount in Session so they can't access all pages by typing in URL
            //maybe add radiobuttons to select which type of login??
            bool allGood = true;
            if (txtEmail.Text == "")
            {
                allGood = false;
                lblMessage.Text = "You must enter a username and password in the boxes below.";
            }
            if (txtPassword.Text == "")
            {
                allGood = false;
                lblMessage.Text = "You must enter a username and password in the boxes below.";
            }
            if ((allGood) && (ddlUserTypeID.SelectedValue == "Customer"))
			{

				string UserType = "Customer";

				objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.CommandText = "TPValidateCustomer";
				objCommand.Parameters.Clear();

				objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
				objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);

				DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

				//LOGIN SUCCESSFUL
				if (myAccount.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Text = "You logged in good job!";
                    //might need to switch this to a UserAccount Object, not sure tho

                    Session.Add("userEmail", txtEmail.Text);
					Session.Add("userName", objDB.GetField("FirstName", 0) + " " + objDB.GetField("LastName", 0));
					Session.Add("userPassword", txtPassword.Text);
                    Session.Add("userID", objDB.GetField("CustomerID", 0));
                    Session.Add("userVWID", objDB.GetField("VWID", 0));
                    Session.Add("userType", UserType);


                    if (objDB.GetField("LoginPreference", 0) != System.DBNull.Value)
                    {
                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["Email"] = txtEmail.Text;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        Response.Cookies.Add(myCookie);
                    }

                    if (rdoAutoLogin.Checked)
                    {
                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["Email"] = txtEmail.Text;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        Response.Cookies.Add(myCookie);
                    }
                    else
                    {

                        //delete cookies from computer
                        if (Request.Cookies["LoginCookie"] != null)
                        {
                            Response.Cookies.Remove("LoginCookie");
                        }

                    }
                    Response.Redirect("CustomerHomePage.aspx");
                }
                else
                {
                    lblMessage.Text = "Error: username or password incorrect";
                }
            }
			else if ((allGood) && (ddlUserTypeID.SelectedValue == "Restaurant"))
			{

				string UserType = "Restaurant";

				objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.CommandText = "TPValidateRestaurant";
				objCommand.Parameters.Clear();

				objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
				objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);

				DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

				//LOGIN SUCCESSFUL
				if (myAccount.Tables[0].Rows.Count > 0)
				{
					

					lblMessage.Text = "You logged in good job!";
					//adds user info to session
					Session.Add("userEmail", txtEmail.Text);
					Session.Add("userPassword", txtPassword.Text);
                    Session.Add("userID", objDB.GetField("RestaurantID", 0));
                    Session.Add("userVWID", objDB.GetField("VWID", 0));
                    Session.Add("userType", UserType);

					if (objDB.GetField("LoginPreference", 0) != System.DBNull.Value)
					{
                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["Email"] = txtEmail.Text;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        Response.Cookies.Add(myCookie);
                    }
				
					if (rdoAutoLogin.Checked)
					{
                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["Email"] = txtEmail.Text;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        Response.Cookies.Add(myCookie);
                    }
					else
					{
						
						//delete cookies from computer
						if (Request.Cookies["LoginCookie"] != null)
						{
							Response.Cookies.Remove("LoginCookie");
						}

					}
					Response.Redirect("RestaurantHomePage.aspx");
				}
				else
				{
					lblMessage.Text = "Error: username or password incorrect";
				}
			}
		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}