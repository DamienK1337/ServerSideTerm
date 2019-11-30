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
            txtPassword.Attributes["type"] = "password";
            rdoNormalLogin.Checked = true;
            // Read encrypted password from cookie
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie myCookie = Request.Cookies["LoginCookie"];
                //txtEmail.Text = myCookie.Values["Email"];
                //txtPassword.Text = myCookie.Values["Password"];
                String encryptedEmail = myCookie.Values["Email"];
                String encryptedPassword = myCookie.Values["Password"];

                Byte[] encryptedEmailBytes = Convert.FromBase64String(encryptedEmail);
                Byte[] emailBytes;
                String plainTextEmail;

                UTF8Encoding encoder = new UTF8Encoding();

                RijndaelManaged rmEncryption = new RijndaelManaged();
                MemoryStream memStream = new MemoryStream();
                CryptoStream decryptionStream = new CryptoStream(memStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

                //Email
                decryptionStream.Write(encryptedEmailBytes, 0, encryptedEmailBytes.Length);
                decryptionStream.FlushFinalBlock();

                memStream.Position = 0;
                emailBytes = new Byte[memStream.Length];
                memStream.Read(emailBytes, 0, emailBytes.Length);

                decryptionStream.Close();
                memStream.Close();

                plainTextEmail = encoder.GetString(emailBytes);
                txtEmail.Text = plainTextEmail;

                //Password
                if (encryptedPassword != null)
                {
                    Byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                    Byte[] passwordBytes;
                    String plainTextPassword;

                    memStream = new MemoryStream();
                    decryptionStream = new CryptoStream(memStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

                    decryptionStream.Write(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                    decryptionStream.FlushFinalBlock();

                    memStream.Position = 0;
                    passwordBytes = new Byte[memStream.Length];
                    memStream.Read(passwordBytes, 0, passwordBytes.Length);

                    decryptionStream.Close();
                    memStream.Close();

                    plainTextPassword = encoder.GetString(passwordBytes);
                    txtPassword.Text = plainTextPassword;
                    //lblMessage.Text = "Password: " + plainTextPassword;
                }

                if (txtPassword.Text != "")
                {
                    rdoAutoLogin.Checked = true;
                }
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
                    Session.Add("userPassword", txtPassword.Text);
                    Session.Add("userID", objDB.GetField("CustomerID", 0));
                    Session.Add("userType", UserType);


					//if (objDB.GetField("LoginPreference", 0) != System.DBNull.Value)
					//{
					//    Byte[] byteSettings = (Byte[])objDB.GetField("LoginPreference", 0);
					//    BinaryFormatter deserializer = new BinaryFormatter();
					//    MemoryStream memoryStream = new MemoryStream(byteSettings);

					//    Settings userSettings = (Settings)deserializer.Deserialize(memoryStream);
					//    Session.Add("userSettings", userSettings);
					//}


					if (objDB.GetField("userSettings", 0) != System.DBNull.Value)
					{
						Byte[] byteSettings = (Byte[])objDB.GetField("userSettings", 0);
						BinaryFormatter deserializer = new BinaryFormatter();
						MemoryStream memoryStream = new MemoryStream(byteSettings);

						Settings userSettings = (Settings)deserializer.Deserialize(memoryStream);
						Session.Add("userSettings", userSettings);
					}

					String plainTextEmail = txtEmail.Text;
                    String plainTextPassword = txtPassword.Text;
                    String encryptedEmail;
                    String encryptedPassword;

                    UTF8Encoding encoder = new UTF8Encoding();
                    Byte[] emailBytes;
                    Byte[] passwordBytes;

                    emailBytes = encoder.GetBytes(plainTextEmail);
                    passwordBytes = encoder.GetBytes(plainTextPassword);

                    RijndaelManaged rmEncryption = new RijndaelManaged();
                    MemoryStream memStream = new MemoryStream();
                    CryptoStream encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                    bool hadSettings = false;
                    Settings loginSettings = new Settings();
                    if (Session["userSettings"] != null)
                    {
                        loginSettings = (Settings)Session["userSettings"];
                        hadSettings = true;
					

					}

                    if (rdoAutoLogin.Checked)
                    {
                        if (hadSettings)
                        {
                            loginSettings.LoginPreference = "Auto-Login";
                            Session.Add("userSettings", loginSettings);
                        }
                        //Email
                        encryptionStream.Write(emailBytes, 0, emailBytes.Length);
                        encryptionStream.FlushFinalBlock();

                        memStream.Position = 0;
                        Byte[] encryptedEmailBytes = new byte[memStream.Length];
                        memStream.Read(encryptedEmailBytes, 0, encryptedEmailBytes.Length);

                        encryptionStream.Close();
                        memStream.Close();

                        //password
                        memStream = new MemoryStream();
                        encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                        encryptionStream.Write(passwordBytes, 0, passwordBytes.Length);
                        encryptionStream.FlushFinalBlock();

                        memStream.Position = 0;
                        Byte[] encryptedPasswordBytes = new byte[memStream.Length];
                        memStream.Read(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);

                        encryptionStream.Close();
                        memStream.Close();

                        encryptedEmail = Convert.ToBase64String(encryptedEmailBytes);
                        encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);

                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["Email"] = encryptedEmail;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        myCookie.Values["Password"] = encryptedPassword;
                        myCookie.Expires = new DateTime(2020, 2, 1);
                        Response.Cookies.Add(myCookie);
                    }
                    else
                    {
                        if (hadSettings)
                        {
                            loginSettings.LoginPreference = "None";
                            Session.Add("userSettings", loginSettings);
                        }
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
					//might need to switch this to a UserAccount Object, not sure tho
					Session.Add("userEmail", txtEmail.Text);
					Session.Add("userPassword", txtPassword.Text);
                    Session.Add("userID", objDB.GetField("RestaurantID", 0));
                    Session.Add("userType", UserType);

					if (objDB.GetField("LoginPreference", 0) != System.DBNull.Value)
					{
						Byte[] byteSettings = (Byte[])objDB.GetField("LoginPreference", 0);
						BinaryFormatter deserializer = new BinaryFormatter();
						MemoryStream memoryStream = new MemoryStream(byteSettings);

						Settings userSettings = (Settings)deserializer.Deserialize(memoryStream);
						Session.Add("userSettings", userSettings);
					}

					String plainTextEmail = txtEmail.Text;
					String plainTextPassword = txtPassword.Text;
					String encryptedEmail;
					String encryptedPassword;

					UTF8Encoding encoder = new UTF8Encoding();
					Byte[] emailBytes;
					Byte[] passwordBytes;

					emailBytes = encoder.GetBytes(plainTextEmail);
					passwordBytes = encoder.GetBytes(plainTextPassword);

					RijndaelManaged rmEncryption = new RijndaelManaged();
					MemoryStream memStream = new MemoryStream();
					CryptoStream encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

					bool hadSettings = false;
					Settings loginSettings = new Settings();
					if (Session["userSettings"] != null)
					{
						loginSettings = (Settings)Session["userSettings"];
						hadSettings = true;
					}

					if (rdoAutoLogin.Checked)
					{
						if (hadSettings)
						{
							loginSettings.LoginPreference = "Auto-Login";
							Session.Add("userSettings", loginSettings);
						}
						//Email
						encryptionStream.Write(emailBytes, 0, emailBytes.Length);
						encryptionStream.FlushFinalBlock();

						memStream.Position = 0;
						Byte[] encryptedEmailBytes = new byte[memStream.Length];
						memStream.Read(encryptedEmailBytes, 0, encryptedEmailBytes.Length);

						encryptionStream.Close();
						memStream.Close();

						//password
						memStream = new MemoryStream();
						encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

						encryptionStream.Write(passwordBytes, 0, passwordBytes.Length);
						encryptionStream.FlushFinalBlock();

						memStream.Position = 0;
						Byte[] encryptedPasswordBytes = new byte[memStream.Length];
						memStream.Read(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);

						encryptionStream.Close();
						memStream.Close();

						encryptedEmail = Convert.ToBase64String(encryptedEmailBytes);
						encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);

						HttpCookie myCookie = new HttpCookie("LoginCookie");
						myCookie.Values["Email"] = encryptedEmail;
						myCookie.Expires = new DateTime(2020, 2, 1);
						myCookie.Values["Password"] = encryptedPassword;
						myCookie.Expires = new DateTime(2020, 2, 1);
						Response.Cookies.Add(myCookie);
					}
					else
					{
						if (hadSettings)
						{
							loginSettings.LoginPreference = "None";
							Session.Add("userSettings", loginSettings);
						}
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