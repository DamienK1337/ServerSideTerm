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
    public partial class CustomerSettings : System.Web.UI.Page
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
            ViewAccountInformation.Visible = false;
        }
        void ValidateUpdateInformation()
        {
            if (txtFirstName.Text == "")
            {
                UpdateInformationError.Add("Enter First Name");

            }
            if (txtLastName.Text == "")
            {
                UpdateInformationError.Add("Enter Last Name");
            }
            if (txtStreet.Text == "")
            {
                UpdateInformationError.Add("Enter City");
            }
            if (txtCity.Text == "")
            {
                UpdateInformationError.Add("Enter City");
            }
            if (txtState.Text == "")
            {
                UpdateInformationError.Add("Enter State");
            }
            if (txtState.Text.Length != 2)
            {
                UpdateInformationError.Add("State is 2 Characters like VA, WY or CA");
            }
            if (txtZip.Text == "" || txtZip.Text.Length < 5 || txtZip.Text.Length > 5)
            {
                UpdateInformationError.Add("Valid Zip-Code Length is 5");
            }

        }

        void ValidatePassword()
        {

            if (txtPassword.Text == "" && txtCPassword.Text == "" && txtCurrentPassword.Text == "")
            {
                UpdateInformationError.Add("Enter Password");
            }
            if (txtPassword.Text != txtCPassword.Text)
            {
                UpdateInformationError.Add("Passwords Do not  Match");
            }

        }

        void ValidateSecurityQuestion()
        {

            if (txtSecurityQuestion.Text == "")
            {
                UpdateInformationError.Add("Enter Question");

            }
            if (txtAnswer.Text == "")
            {
                UpdateInformationError.Add("Enter Answer");

            }

        }

        protected void lnkBtnViewAccountInformation_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ChangePassword.Visible = false;
            ChangeSecurtiyQuestions.Visible = false;
            ViewAccountInformation.Visible = true;

            if (UpdateInformationError.Count == 0)
            {


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPValidateCustomer";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@Password", Session["userPassword"].ToString());

                DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                txtFirstName.Text = (string)objDB.GetField("FirstName", 0);
                txtLastName.Text = (string)objDB.GetField("LastName", 0);
                lblDeliveryAddress.Text = (string)objDB.GetField("DeliveryAddress", 0);
                lblBillingAddress.Text = (string)objDB.GetField("BillingAddress", 0);

                string DeliveryAddress = (string)objDB.GetField("DeliveryAddress", 0);
                var array = DeliveryAddress.Split(',');

                txtStreet.Text = (array[0]);
                txtCity.Text = (array[1]);
                txtState.Text = (array[2]);
                txtZip.Text = (array[3]);
                string BillingAddress = (string)objDB.GetField("BillingAddress", 0);
                var array1 = BillingAddress.Split(',');

                txtBillingStreet.Text = (array1[0]);
                txtBillingCity.Text = (array1[1]);
                txtBillingState.Text = (array1[2]);
                txtBillingZip.Text = (array1[3]);

                txtPhoneNumber.Text = (string)objDB.GetField("PhoneNumber", 0);

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }

        }

        protected void lnkBtnChangePassword_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ViewAccountInformation.Visible = false;
            ChangeSecurtiyQuestions.Visible = false;
            ChangePassword.Visible = true;
        }

        protected void lnkBtnChangeSecurityQuestion_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ViewAccountInformation.Visible = false;
            ChangePassword.Visible = false;
            ChangeSecurtiyQuestions.Visible = true;
        }



        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            ValidateUpdateInformation();
            ChangePassword.Visible = false;
            ChangeSecurtiyQuestions.Visible = false;

            if (UpdateInformationError.Count == 0)
            {
                string FullAddress = txtStreet.Text + "," + txtCity.Text + "," + txtState.Text + "," + txtZip.Text;
                string FullBillingAddress = txtBillingStreet.Text + "," + txtBillingCity.Text + "," + txtBillingState.Text + "," + txtBillingZip.Text;

                string CustomerFirstName = txtFirstName.Text;
                string CustomerLastName = txtLastName.Text;
                string CustomerPhoneNumber = txtPhoneNumber.Text;
                string CustomerDeliveryAddress = FullAddress;
                string CustomerBillingAddress = FullBillingAddress;


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPUpdateCustomerInfo";

                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@Password", Session["userPassword"].ToString());

                objCommand.Parameters.AddWithValue("@FirstName", CustomerFirstName);
                objCommand.Parameters.AddWithValue("@LastName", CustomerLastName);
                objCommand.Parameters.AddWithValue("@DeliveryAddress", CustomerDeliveryAddress);
                objCommand.Parameters.AddWithValue("@BillingAddress", CustomerBillingAddress);
                objCommand.Parameters.AddWithValue("@PhoneNumber", CustomerPhoneNumber);


                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {
                    lblConfirm.Text = "Thank you for updating your information!";
                    lblConfirm.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }



        protected void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            ValidatePassword();

            //string Password = txtPassword.Text;

            string EnteredCurrentPassword = txtCurrentPassword.Text;
            string CurrentPassword = "";
            if (UpdateInformationError.Count == 0)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPValidatePasswordCustomer";

                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@Password", EnteredCurrentPassword);

                DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                CurrentPassword = (string)objDB.GetField("Password", 0);

                if (EnteredCurrentPassword != CurrentPassword)
                {
                    lblPwMsg.Text = "The entered password did not match the password on file.";
                }
                else
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TPUpdatePasswordCustomer";

                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                    objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);

                    var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                    if (ResponseReceived == 1)
                    {
                        Session["userPassword"] = txtPassword.Text;
                        lblConfirm.Text = "Thank you for updating your password!";
                        lblConfirm.Visible = true;
                        ChangePassword.Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }

        protected void btnSubmitQuestion_Click(object sender, EventArgs e)
        {
            ValidateSecurityQuestion();
            ChangePassword.Visible = false;
            ViewAccountInformation.Visible = false;


            string EnteredCurrentPassword = txtCurrentPassword1.Text;
            string CurrentPassword = "";
            if (UpdateInformationError.Count == 0)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPValidatePasswordCustomer";

                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@Password", EnteredCurrentPassword);

                DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                CurrentPassword = (string)objDB.GetField("Password", 0);

                if (EnteredCurrentPassword != CurrentPassword)
                {
                    lblPwMsg.Text = "The entered password did not match the password on file.";
                }
                else
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TPUpdateSecurityCustomer";

                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                    objCommand.Parameters.AddWithValue("@SecurityQuestion", txtSecurityQuestion.Text);
                    objCommand.Parameters.AddWithValue("@SecurityAnswer", txtAnswer.Text);

                    var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                    if (ResponseReceived == 1)
                    {
                        lblConfirm.Text = "Thank you for updating your Security Questions";
                        lblConfirm.Visible = true;
                        ChangeSecurtiyQuestions.Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
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