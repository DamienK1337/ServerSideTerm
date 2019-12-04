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
using System.Web.Script.Serialization;  // needed for JSON serializers



using System.Net;                       // needed for the Web Request



namespace OwlsEat
{
    public partial class Registration : System.Web.UI.Page
    {
        ArrayList UserRegistrationError = new ArrayList();
       
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

		string FullAddress;
		string FullBillingAddress;

		
		

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerDetails.Visible = false;
            RestaurantDetails.Visible = false;
            SimilarDetails.Visible = false;
			RegisterButtonDiv.Visible = false;
			ChkBoxSameAddressDiv.Visible = false;

			
			
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
            if (ddlUserTypeID.SelectedValue == "Restaurant" && txtRestuarantName.Text == "")
            {
                UserRegistrationError.Add("Enter Restaurant Name");

            }
            if (ddlUserTypeID.SelectedValue == "Restaurant" && txtCuisine.Text == "")
            {
                UserRegistrationError.Add("Enter Cuisine");

            }
            if (txtStreet.Text == "")
            {
                UserRegistrationError.Add("Enter City");
            }
            if (txtCity.Text == "")
            {
                UserRegistrationError.Add("Enter City");
            }
            if (txtState.Text == "")
            {
                UserRegistrationError.Add("Enter State");
            }
            if (txtState.Text.Length != 2)
            {
                UserRegistrationError.Add("State is 2 Characters like VA, WY or CA");
            }
            if (txtZip.Text == "" || txtZip.Text.Length < 5 || txtZip.Text.Length > 5)
            {
                UserRegistrationError.Add("Valid Zip-Code Length is 5");
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
                UserRegistrationError.Add("Password Don't Match");
            }

			if (txtSecurityQuestion.Text == "")
			{
				UserRegistrationError.Add("Enter Question 1");

			}
			if (txtAnswer.Text == "")
			{
				UserRegistrationError.Add("Enter Answer 1");

			}

		}

        protected void ddlUserTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserTypeID.SelectedValue == "Customer")
            {
                CustomerDetails.Visible = true;
                SimilarDetails.Visible = true;
                RestaurantDetails.Visible = false;
				RegisterButtonDiv.Visible = true;
				ChkBoxSameAddressDiv.Visible = true;
			}
            else if (ddlUserTypeID.SelectedValue == "Restaurant")
            {
                CustomerDetails.Visible = false;
                RestaurantDetails.Visible = true;
                SimilarDetails.Visible = true;
				RegisterButtonDiv.Visible = true;
				ChkBoxSameAddressDiv.Visible = false;
			}

        }

		protected void chkSameAddress_CheckedChanged(object sender, EventArgs e)
		{
			txtBillingStreet.Text = txtStreet.Text;
			txtBillingCity.Text = txtCity.Text;
			txtBillingState.Text = txtState.Text;
			txtBillingZip.Text = txtZip.Text; 
		}

		protected void RegisterUserButton_Click(object sender, EventArgs e)
        {
			FullAddress = txtStreet.Text + "," + txtCity.Text + "," + txtState.Text + "," + txtZip.Text;
			FullBillingAddress = txtBillingStreet.Text + "," + txtBillingCity.Text + "," + txtBillingState.Text + "," + txtBillingZip.Text;
			string CustomerFirstName = txtFirstName.Text;
            string CustomerLastName = txtLastName.Text;
            string CustomerPhoneNumber = txtPhoneNumber.Text;
            string CustomerEmail = txtEmail.Text;
            string CustomerPassword = txtPassword.Text;
            string CustomerDeliveryAddress = FullAddress;
			string CustomerBillingAddress = FullBillingAddress;



			string RestaurantEmail = txtEmail.Text;
            string RestaurantPassword = txtPassword.Text;
            string RestaurantFirstName = txtFirstName.Text;
            string RestaurantLastName = txtLastName.Text;
            string RestaurantCuisine = txtCuisine.Text;
            string RestaurantImgUrl = txtImgUrl.Text;
            string RestaurantLocation = FullAddress;
            string restaurantName = txtRestuarantName.Text;
            string RestaurantPhoneNumber = txtPhoneNumber.Text;

			string SecurityQuestion = txtSecurityQuestion.Text;
			string SecurityAnswer = txtAnswer.Text;
			


			

            //Validate
            ValidateUserRegistration();

            if ((UserRegistrationError.Count == 0) && (ddlUserTypeID.SelectedValue == "Customer"))
            {
                //Check if email already exist
                String UserEmail = txtEmail.Text;
                Boolean flag = CheckIfCustomerExists(UserEmail);
                if (flag == true)
                {
                    Response.Write("Email already exist");
                }
                else
                {




					Merchant m12 = new Merchant();
					APIKey w12 = new APIKey();
					VWHolder VW12 = new VWHolder();

					VW12.Name = txtFirstName.ToString() + "" + txtLastName.ToString();
					VW12.Password = txtPassword.ToString();
					VW12.Email = txtEmail.ToString();
					VW12.CreditCard = "12345679023";

					string test = ExecuteCallToWebAPI(VW12,m12,w12);


					//Register 
					Customer newCustomer = new Customer
					{

						FirstName = CustomerFirstName,
						LastName = CustomerLastName,
						PhoneNumber = CustomerPhoneNumber,
						Email = CustomerEmail,
						Password = CustomerPassword,
						DeliveryAddress = CustomerDeliveryAddress,
						BillingAddress = CustomerBillingAddress,
						SecurityAnswer = SecurityAnswer,
						SecurityQuestion = SecurityQuestion,
						VWID = test
						
					};


                    var ResponseReceived = newCustomer.AddCustomer();
                    if (ResponseReceived == true)
                    {
                        //User Registered 
                        //Save UserEmail in Session Called UserEmail
                        Session.Add("userEmail", txtEmail.Text.ToString());
                        Session.Add("userPassword", txtPassword.Text.ToString());
                        Session.Add("userVWID", test);
                        RegisterUserDetails.Visible = false;
                        PreferencesDiv.Visible = true;

                    }
                    else
                    {
                        Response.Write("Error Occured on the DATABASE");
                    }

                }
            }
            if ((UserRegistrationError.Count == 0) && (ddlUserTypeID.SelectedValue == "Restaurant"))
            {
                //Check if email already exist
                String UserEmail = txtEmail.Text;
                Boolean flag = CheckIfRestaurantExists(UserEmail);
                if (flag == true)
                {
                    Response.Write("Email already exist");
                }
                else
                {
                    Merchant m12 = new Merchant();
                    APIKey w12 = new APIKey();
                    VWHolder VW12 = new VWHolder();

                    VW12.Name = txtFirstName.ToString() + "" + txtLastName.ToString();
                    VW12.Password = txtPassword.ToString();
                    VW12.Email = txtEmail.ToString();
                    VW12.CreditCard = "12345679023";

                    string test = ExecuteCallToWebAPI(VW12, m12, w12);

                    //Register 
                    Restaurants newRestaurants = new Restaurants
					{

						Email = RestaurantEmail,
						Password = RestaurantPassword,
						FirstName = RestaurantFirstName,
						LastName = RestaurantLastName,
						Cuisine = RestaurantCuisine,
						ImgURL = RestaurantImgUrl,
						PhoneNumber = RestaurantPhoneNumber,
						RestaurantName = restaurantName,
						Location = RestaurantLocation,
						SecurityAnswer = SecurityAnswer,
						SecurityQuestion = SecurityQuestion,
                        VWID = test
                    };

                    var ResponseReceived = newRestaurants.AddAddRestaurant();
                    if (ResponseReceived == true)
                    {
                        //User Registered 
                        //Save UserEmail in Session Called UserEmail
                        Session.Add("userEmail", txtEmail.Text.ToString());
                        Session.Add("userPassword", txtPassword.Text.ToString());
                        Session.Add("userVWID", test);
                        RegisterUserDetails.Visible = false;
                        PreferencesDiv.Visible = true;

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


        }

        public Boolean CheckIfCustomerExists(String Email)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPCheckIfCustomerExists";
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

        public Boolean CheckIfRestaurantExists(String Email)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPCheckIFRestaurantExists";
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

        protected void SubmitPreferencesButton_Click(object sender, EventArgs e)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            Settings userSettings = new Settings();

            if (ddlUserTypeID.SelectedValue == "Restaurant")
            {


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPInsertRestaurantPreference";
                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@LoginPreference", LoginPreferenceDropDown.SelectedValue);

                int ResponseRecieved = dbConnection.DoUpdateUsingCmdObj(objCommand);

                userSettings.LoginPreference = LoginPreferenceDropDown.SelectedValue;

                Session.Add("userSettings", userSettings);
            }


            if (ddlUserTypeID.SelectedValue == "Customer")
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPInsertCustomerPreference";
                objCommand.Parameters.AddWithValue("@Email", Session["userEmail"].ToString());
                objCommand.Parameters.AddWithValue("@LoginPreference", LoginPreferenceDropDown.SelectedValue);

                int ResponseRecieved = dbConnection.DoUpdateUsingCmdObj(objCommand);

               
                userSettings.LoginPreference = LoginPreferenceDropDown.SelectedValue;

                Session.Add("userSettings", userSettings);
            }

            String plainTextEmail = txtEmail.Text;
            String plainTextPassword = txtPassword.Text;
            String encryptedEmail;
            String encryptedPassword;

            System.Text.UTF8Encoding encoder = new UTF8Encoding();
            Byte[] emailBytes;
            Byte[] passwordBytes;

            emailBytes = encoder.GetBytes(plainTextEmail);
            passwordBytes = encoder.GetBytes(plainTextPassword);

            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream memStream = new MemoryStream();
            CryptoStream encryptionStream = new CryptoStream(memStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            if (userSettings.LoginPreference == "Auto-Login")
            {
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
                myCookie.Expires = new DateTime(2021, 2, 1);
                myCookie.Values["Password"] = encryptedPassword;
                myCookie.Expires = new DateTime(2021, 2, 1);
                Response.Cookies.Add(myCookie);
            }
            //else if (userSettings.LoginPreference == "Fast-Login")
            //{
            //    encryptionStream.Write(emailBytes, 0, emailBytes.Length);
            //    encryptionStream.FlushFinalBlock();

            //    memStream.Position = 0;
            //    Byte[] encryptedEmailBytes = new byte[memStream.Length];
            //    memStream.Read(encryptedEmailBytes, 0, encryptedEmailBytes.Length);

            //    encryptionStream.Close();
            //    memStream.Close();

            //    encryptedEmail = Convert.ToBase64String(encryptedEmailBytes);

            //    HttpCookie myCookie = new HttpCookie("LoginCookie");
            //    myCookie.Values["Email"] = encryptedEmail;
            //    myCookie.Expires = new DateTime(2020, 2, 1);
            //    Response.Cookies.Add(myCookie);
            //}
            if (ddlUserTypeID.SelectedValue == "Restaurant")
            {
                Response.Redirect("Login.aspx");
            }

            if (ddlUserTypeID.SelectedValue == "Customer")
            {
                Response.Redirect("Login.aspx");
            }
           
         

        }


		public string ExecuteCallToWebAPI( VWHolder newVW, Merchant CurrMerchant , APIKey CurrAPIKey)

		{
			string Fname = txtFirstName.Text;
			string Lname = txtLastName.Text;
			string pword = txtPassword.Text;
			string emailadd = txtEmail.Text;
			 



			newVW.Name = Fname + " " + Lname;
			newVW.Password = pword;
			newVW.Email = emailadd;

			JavaScriptSerializer js = new JavaScriptSerializer();  //Coverts Object into JSON String
			String jsonVWHolder = js.Serialize(newVW);

			try

			{
				CurrMerchant.MerchantID = "78735";
				CurrAPIKey.Key = "7636";

				String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tuf05666/WebAPITest/api/service/PaymentGateway/CreateVW";

				url = url + "/" + CurrMerchant.MerchantID + "/" + CurrAPIKey.Key;
				WebRequest request = WebRequest.Create(url);
				request.Method = "POST";
				request.ContentLength = jsonVWHolder.Length;
				request.ContentType = "application/json";

				// Write the JSON data to the Web Request

				StreamWriter writer = new StreamWriter(request.GetRequestStream());

				writer.Write(jsonVWHolder);

				writer.Flush();

				writer.Close();

				// Create an HTTP Web Request and get the HTTP Web Response from the server.


				WebResponse response = request.GetResponse();
				Stream theDataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(theDataStream);
                string data1 = reader.ReadToEnd();

				reader.Close();
				response.Close();

                string data = data1.Trim('"');


                lblText.Text = data;


				return data;
			}
			catch (Exception ex)

			{
				string hi= "hello";
				lblText.Text = "Error: " + ex.Message;
				return hi;

			}

		}

	}
}