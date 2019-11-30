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

namespace TermProject
{
    public partial class SignUpMerchant : System.Web.UI.Page
    {
        ArrayList UserRegistrationError = new ArrayList();
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        public string APIKey;
        public string MerchantAccountID;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void ValidateUserRegistration()
        {
            if (txtFirstName.Text == "")
            {
                UserRegistrationError.Add("Enter First Name");

            }
            if (txtLastName.Text == "")
            {
                UserRegistrationError.Add("Enter Last Name");
            }
            if (txtCompanyName.Text == "")
            {
                UserRegistrationError.Add("Enter Company Name");
            }
            if (txtEmail.Text == "")
            {
                UserRegistrationError.Add("Enter Email");
            }
            if (txtPassword.Text == "" && txtCPassword.Text == "")
            {
                UserRegistrationError.Add("Enter Password");
            }
            if (txtPassword.Text != txtCPassword.Text)
            {
                UserRegistrationError.Add("Passwords Do not Match");
            }

        }


        public string CreateRandom1()
        {

            int _min = 0000;
            int _max = 9999;
            Random rdm = new Random();
            string Random = rdm.Next(_min, _max).ToString();

            return Random;

        }
        public string CreateRandom2()
        {

            int _min = 9999;
            int _max = 99999;
            Random rdm = new Random();
            string Random = rdm.Next(_min, _max).ToString();

            return Random;

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //Validate
            ValidateUserRegistration();

            string APIKey = CreateRandom1();
            string MerchantAccountID = CreateRandom2();

            string MerchantFirstName = txtFirstName.Text;
            string MerchantLastName = txtLastName.Text;
            string MerchantCompanyName = txtCompanyName.Text;
            string MerchantEmail = txtEmail.Text;
            string MerchantPassword = txtPassword.Text;



            lblLabel.Text = "Your key is : " + APIKey;


            //int userTypeId = Convert.ToInt32(ddlUserTypeID.SelectedValue);


            if (UserRegistrationError.Count == 0)
            {
                //Check if email already exist
                String UserEmail = txtEmail.Text;
                Boolean flag = CheckIfEmailExist(UserEmail);
                if (flag == true)
                {
                    Response.Write("Email already exists");
                }
                else
                {
                    //Register 

                    Merchant newMerchant = new Merchant
                    {

                        FirstName = MerchantFirstName,
                        LastName = MerchantLastName,
                        CompanyName = MerchantCompanyName,
                        Email = MerchantEmail,
                        Password = MerchantPassword,
                        APIKey = APIKey,
                        MerchantAccountID = MerchantAccountID
                    };

                    //var Result = newMerchant.AddNewMerchant();
                    var ResponseReceived = newMerchant.AddNewMerchant();
                    if (ResponseReceived == true)
                    {
                        //User Registered 
                        //Save UserEmail in Session Called UserEmail
                        Session.Add("userEmail",txtEmail.Text.ToString());

                        RegisterMerchantDetails.Visible = false;
                        BankAccount.Visible = true;
                    }
                    else
                    {
                        Response.Write("Error Occured on the DATABASE");
                    }

                }
            }
            else
            {
                for (int i = 0; i < UserRegistrationError.Count; i++)
                {
                    Response.Write(UserRegistrationError[i] + "<br/>");
                }
            }

            String plainTextEmail = txtEmail.Text;
            String plainTextPassword = txtPassword.Text;
            String plainTextAPIKey = APIKey;
            String plainTextMerchantID = MerchantAccountID;

            String encryptedEmail;
            String encryptedPassword;
            String encryptedAPIKey;
            String encryptedMerchantAccountID;

            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            Byte[] EmailBytes;
            Byte[] PasswordBytes;
            Byte[] APIKeyBytes;
            Byte[] MerchantAccountIDBytes;

            EmailBytes = encoder.GetBytes(plainTextEmail);
            PasswordBytes = encoder.GetBytes(plainTextPassword);
            APIKeyBytes = encoder.GetBytes(plainTextAPIKey);
            MerchantAccountIDBytes = encoder.GetBytes(plainTextMerchantID);

            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream memStream = new MemoryStream();
            CryptoStream encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            //Email
            encryptionStream.Write(EmailBytes, 0, EmailBytes.Length);
            encryptionStream.FlushFinalBlock();

            memStream.Position = 0;
            Byte[] encryptedEmailBytes = new byte[memStream.Length];
            memStream.Read(encryptedEmailBytes, 0, encryptedEmailBytes.Length);

            encryptionStream.Close();
            memStream.Close();

            //password
            memStream = new MemoryStream();
            encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            encryptionStream.Write(PasswordBytes, 0, PasswordBytes.Length);
            encryptionStream.FlushFinalBlock();

            memStream.Position = 0;
            Byte[] encryptedPasswordBytes = new byte[memStream.Length];
            memStream.Read(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);

            encryptionStream.Close();
            memStream.Close();

            //APIKey
            memStream = new MemoryStream();
            encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            encryptionStream.Write(APIKeyBytes, 0, APIKeyBytes.Length);
            encryptionStream.FlushFinalBlock();

            memStream.Position = 0;
            Byte[] encryptedAPIKeyBytes = new byte[memStream.Length];
            memStream.Read(encryptedAPIKeyBytes, 0, encryptedAPIKeyBytes.Length);

            encryptionStream.Close();
            memStream.Close();

            //MerchantAccountID
            memStream = new MemoryStream();
            encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            encryptionStream.Write(MerchantAccountIDBytes, 0, MerchantAccountIDBytes.Length);
            encryptionStream.FlushFinalBlock();

            memStream.Position = 0;
            Byte[] encryptedMerchantAccountIDBytes = new byte[memStream.Length];
            memStream.Read(encryptedMerchantAccountIDBytes, 0, encryptedMerchantAccountIDBytes.Length);

            encryptionStream.Close();
            memStream.Close();

            encryptedEmail = Convert.ToBase64String(encryptedEmailBytes);
            encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
            encryptedAPIKey = Convert.ToBase64String(encryptedAPIKeyBytes);
            encryptedMerchantAccountID = Convert.ToBase64String(encryptedMerchantAccountIDBytes);

            HttpCookie myCookie = new HttpCookie("LoginCookie");
            myCookie.Values["Email"] = encryptedEmail;
            myCookie.Expires = new DateTime(2020, 2, 1);
            myCookie.Values["Password"] = encryptedPassword;
            myCookie.Expires = new DateTime(2020, 2, 1);
            myCookie.Values["APIKey"] = encryptedAPIKey;
            myCookie.Expires = new DateTime(2020, 2, 1);
            myCookie.Values["MerchantAccountID"] = encryptedMerchantAccountID;
            myCookie.Expires = new DateTime(2020, 2, 1);
            Response.Cookies.Add(myCookie);


        }

        public Boolean CheckIfEmailExist(String Email)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPCheckIfMerchantExists";
            SqlParameter inputParameter = new SqlParameter("@Email", Email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            objCommand.Parameters.Add(inputParameter);

            DataSet EmailDataSet = dbConnection.GetDataSetUsingCmdObj(objCommand);
            if (EmailDataSet.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        protected void btnSubmitBankInformation_Click(object sender, EventArgs e)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPAddMerchantBankInformation";
            objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
            objCommand.Parameters.AddWithValue("@BankCompany", txtBankCompany.Text);
            objCommand.Parameters.AddWithValue("@AccountType", ddlAccountType.SelectedValue);
            objCommand.Parameters.AddWithValue("@AccountNumber", txtAccountNumber.Text);

            int ResponseRecevied = dbConnection.DoUpdateUsingCmdObj(objCommand);

            RegisterMerchantDetails.Visible = false;
            BankAccount.Visible = false;
            SubmitConfirmation.Visible = true;
        }
    }
}