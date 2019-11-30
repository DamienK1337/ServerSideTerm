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
    public partial class RestaurantManageMenu : System.Web.UI.Page
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
            CreateItems.Visible = false;
        }
        void ValidateItemInformation()
        {
            if (txtItemTitle.Text == "")
            {
                UpdateInformationError.Add("Enter Item");

            }
            if (txtItemImgUrl.Text == "")
            {
                UpdateInformationError.Add("Please Upload Image");
            }
            if (txtDescription.Text == "")
            {
                UpdateInformationError.Add("Enter Description");
            }
            if (txtItemPrice.Text == "")
            {
                UpdateInformationError.Add("Enter Price");
            }

        }

        void ValidateMenu()
        {

            if (txtMenuTitle.Text == "")
            {
                UpdateInformationError.Add("Enter Title");

            }
            if (txtMenuDescription.Text == "")
            {
                UpdateInformationError.Add("Enter Description");

            }
            if (txtMenuImage.Text == "")
            {
                UpdateInformationError.Add("Enter Description");

            }

        }

        protected void lnkBtnChangePassword_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            ChangeSecurtiyQuestions.Visible = false;
        }


        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            //ValidateUpdateInformation();

            //if (UpdateInformationError.Count == 0)
            //{
            //    string FullAddress = txtStreet.Text + "," + txtCity.Text + "," + txtState.Text + "," + txtZip.Text;

            //    string RestaurantFirstName = txtFirstName.Text;
            //    string RestaurantLastName = txtLastName.Text;
            //    string RestaurantCuisine = txtCuisine.Text;
            //    string restaurantName = txtRestaurantName.Text;
            //    string RestaurantPhoneNumber = txtPhoneNumber.Text;
            //    string RestaurantLocation = FullAddress;
            //    string RestaurantImgUrl = txtImgUrl.Text;

            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "TPUpdateRestaurantInfo";

            //    objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            //    objCommand.Parameters.AddWithValue("@Password", Session["userPassword"].ToString());

            //    objCommand.Parameters.AddWithValue("@FirstName", RestaurantFirstName);
            //    objCommand.Parameters.AddWithValue("@LastName", RestaurantLastName);
            //    objCommand.Parameters.AddWithValue("@Cuisine", RestaurantCuisine);
            //    objCommand.Parameters.AddWithValue("@RestaurantName", restaurantName);
            //    objCommand.Parameters.AddWithValue("@Location", RestaurantLocation);
            //    objCommand.Parameters.AddWithValue("@PhoneNumber", RestaurantPhoneNumber);
            //    objCommand.Parameters.AddWithValue("@ImgURL", RestaurantImgUrl);

            //    var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
            //    if (ResponseReceived == 1)
            //    {

            //        lblConfirm.Text = "Thank you for updating your information!";
            //        lblConfirm.Visible = true;
            //    }

            //}
            //else
            //{
            //    for (int i = 0; i < UpdateInformationError.Count; i++)
            //    {
            //        lblConfirm.Text = "Failed";
            //        lblConfirm.Visible = true;
            //        Response.Write(UpdateInformationError[i] + "<br/>");
            //    }
        }

        protected void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            //ValidatePassword();

            ////string Password = txtPassword.Text;

            //string EnteredCurrentPassword = txtCurrentPassword.Text;
            //string CurrentPassword = "";
            //if (UpdateInformationError.Count == 0)
            //{
            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "TPValidatePasswordRestaurant";

            //    objCommand.Parameters.Clear();

            //    objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            //    objCommand.Parameters.AddWithValue("@Password", EnteredCurrentPassword);

            //    DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

            //    CurrentPassword = (string)objDB.GetField("Password", 0);

            //    if (EnteredCurrentPassword != CurrentPassword)
            //    {
            //        lblPwMsg.Text = "The entered password did not match the password on file.";
            //    }
            //    else
            //    {
            //        objCommand.CommandType = CommandType.StoredProcedure;
            //        objCommand.CommandText = "TPUpdatePasswordRestaurant";

            //        objCommand.Parameters.Clear();

            //        objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            //        objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);

            //        var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
            //        if (ResponseReceived == 1)
            //        {
            //            Session["userPassword"] = txtPassword.Text;
            //            lblConfirm.Text = "Thank you for updating your password!";
            //            lblConfirm.Visible = true;
            //            ChangePassword.Visible = false;
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < UpdateInformationError.Count; i++)
            //    {
            //        Response.Write(UpdateInformationError[i] + "<br/>");
            //    }
            //}
        }

        protected void btnSubmitQuestion_Click(object sender, EventArgs e)
        {
            //ValidateSecurityQuestion();



            //string EnteredCurrentPassword = txtCurrentPassword1.Text;
            //string CurrentPassword = "";
            //if (UpdateInformationError.Count == 0)
            //{
            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "TPValidatePasswordRestaurant";

            //    objCommand.Parameters.Clear();

            //    objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            //    objCommand.Parameters.AddWithValue("@Password", EnteredCurrentPassword);

            //    DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

            //    CurrentPassword = (string)objDB.GetField("Password", 0);

            //    if (EnteredCurrentPassword != CurrentPassword)
            //    {
            //        lblPwMsg.Text = "The entered password did not match the password on file.";
            //    }
            //    else
            //    {
            //        objCommand.CommandType = CommandType.StoredProcedure;
            //        objCommand.CommandText = "TPUpdateSecurityRestaurant";

            //        objCommand.Parameters.Clear();

            //        objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            //        objCommand.Parameters.AddWithValue("@SecurityQuestion", txtSecurityQuestion.Text);
            //        objCommand.Parameters.AddWithValue("@SecurityAnswer", txtAnswer.Text);

            //        var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
            //        if (ResponseReceived == 1)
            //        {
            //            lblConfirm.Text = "Thank you for updating your Security Questions";
            //            lblConfirm.Visible = true;
            //            ChangeSecurtiyQuestions.Visible = false;
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < UpdateInformationError.Count; i++)
            //    {
            //        Response.Write(UpdateInformationError[i] + "<br/>");
            //    }
            //}
        }

        protected void btnCreateItem_Click(object sender, EventArgs e)
        {
            ValidateItemInformation();

            if (UpdateInformationError.Count == 0)
            {

                string ItemTitle = txtItemTitle.Text;
                string ItemImgUrl = txtItemImgUrl.Text;
                string ItemDescription = txtDescription.Text;
                float  ItemPrice = float.Parse(txtItemPrice.Text);

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPInsertItem";

                objCommand.Parameters.AddWithValue("@Title", ItemTitle);
                objCommand.Parameters.AddWithValue("@Description", ItemDescription);
                objCommand.Parameters.AddWithValue("@Price", ItemPrice);
                objCommand.Parameters.AddWithValue("@Image", ItemImgUrl);

                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {

                    lblConfirm.Text = "Thank you for creating an Item!";
                    lblConfirm.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }
    

        protected void lnkBtnCreateItems_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateItems.Visible = true;
            ChangeSecurtiyQuestions.Visible = false;


        }

        protected void lnkBtnCreateMenu_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            CreateItems.Visible = false;
            CreateMenu.Visible = true;
        }

        protected void btnCreateMenu_Click(object sender, EventArgs e)
        {
            ValidateItemInformation();

            if (UpdateInformationError.Count == 0)
            {

                string ItemTitle = txtMenuTitle.Text;
                string ItemImgUrl = txtMenuImage.Text;
                string ItemDescription = txtMenuDescription.Text;
                float ItemPrice = float.Parse(txtItemPrice.Text);

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPInsertMenu";

                objCommand.Parameters.AddWithValue("@Title", ItemTitle);
                objCommand.Parameters.AddWithValue("@Description", ItemDescription);
                objCommand.Parameters.AddWithValue("@Price", ItemPrice);
                objCommand.Parameters.AddWithValue("@Image", ItemImgUrl);
                objCommand.Parameters.AddWithValue("@ItemID", Session["userID"].ToString());
                objCommand.Parameters.AddWithValue("@RestaurantID", Session["userID"].ToString());

                var ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if (ResponseReceived == 1)
                {

                    lblConfirm.Text = "Thank you for creating an Menu!";
                    lblConfirm.Visible = true;
                }

            }
            else
            {
                for (int i = 0; i < UpdateInformationError.Count; i++)
                {
                    lblConfirm.Text = "Failed";
                    lblConfirm.Visible = true;
                    Response.Write(UpdateInformationError[i] + "<br/>");
                }
            }
        }
    }
}