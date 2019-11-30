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
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
			Main.Visible = false;
        }

		protected void btnGetUser_Click(object sender, EventArgs e)
		{
			Main.Visible = true;

			if ((txtEmail.Text != "") && (ddlUserTypeID.SelectedValue == "Customer"))
			{


				objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.CommandText = "TPGetCustomerSecurityQuestion";
				objCommand.Parameters.Clear();

				objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
				DataSet myUserAccount = objDB.GetDataSetUsingCmdObj(objCommand);

				if (myUserAccount.Tables[0].Rows.Count > 0)
				{
					DataRow account = myUserAccount.Tables[0].Rows[0];
					if (account[0].ToString() != "")
					{
						lblSecurityQuestion.Text = account[0].ToString();

					}
					else
					{
						lblMessage.Text = "You did not create any security questions. Your password will be sent to your email address.";
					}
				}
			}
			else if ((txtEmail.Text != "") && (ddlUserTypeID.SelectedValue == "Restaurant"))
				{


					objCommand.CommandType = CommandType.StoredProcedure;
					objCommand.CommandText = "TPGetRestaurantSecurityQuestion";
					objCommand.Parameters.Clear();

					objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
					DataSet myUserAccount = objDB.GetDataSetUsingCmdObj(objCommand);

					if (myUserAccount.Tables[0].Rows.Count > 0)
					{
						DataRow account = myUserAccount.Tables[0].Rows[0];
						if (account[0].ToString() != "")
						{
							lblSecurityQuestion.Text = account[0].ToString();

						}
						else
						{
							lblMessage.Text = "You did not create any security questions. Your password will be sent to your email address.";
						}
					}
				}
		}

		protected void btnSubmitQuestions_Click(object sender, EventArgs e)
        {
			Main.Visible = true;
			bool allGood = true;

            if (txtEmail.Text == "")
            {
                lblMessage.Text = "Please enter your email and answer your security question. Answers are case sensitive.";
                allGood = false;
            }
            if (txtAnswer.Text == "")
            {
                lblMessage.Text = "Please enter your email and answer your security question. Answers are case sensitive.";
                allGood = false;
            }


           
				if ((allGood) && (ddlUserTypeID.SelectedValue == "Customer"))
				{
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPGetCustomerSecurityAnswer";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                objCommand.Parameters.AddWithValue("@Answer", txtAnswer.Text);

                DataSet myPassword = objDB.GetDataSetUsingCmdObj(objCommand);

                if(myPassword.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Text = "Your password is: " + myPassword.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    lblMessage.Text = "Error: Recheck your email address and the answers to your security questions and try again.";
                }
            }

				else if ((allGood) && (ddlUserTypeID.SelectedValue == "Restaurant"))
			{
				objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.CommandText = "TPGetRestaurantSecurityAnswer";
				objCommand.Parameters.Clear();

				objCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
				objCommand.Parameters.AddWithValue("@Answer", txtAnswer.Text);

				DataSet myPassword = objDB.GetDataSetUsingCmdObj(objCommand);

				if (myPassword.Tables[0].Rows.Count > 0)
				{
					lblMessage.Text = "Your password is: " + myPassword.Tables[0].Rows[0][0].ToString();
				}
				else
				{
					lblMessage.Text = "Error: Recheck your email address and the answers to your security questions and try again.";
				}
			}
		}

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

		protected void ddlUserTypeID_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlUserTypeID.SelectedValue != "None")
			{
				Main.Visible = true;
			}
		}
	}
}