﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
namespace OwlsEat
{
	public partial class CustomerManageVirtualWallet : System.Web.UI.Page
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
		}

		void ValidateItemInformation()
		{
			if (txtAmountToFund.Text == "")
			{
				UpdateInformationError.Add("Enter Amount");

			}
		}

		void ValidatePaymentInformation()
		{
			if (txtPaymentMethodName.Text == "")
			{
				UpdateInformationError.Add("Enter Amount");

			}
			if (txtAccountNumber.Text == "")
			{
				UpdateInformationError.Add("Please Upload Image");
			}
			if (txtInitialBalance.Text == "")
			{
				UpdateInformationError.Add("Enter Description");
			}
			if (ddlAccountType.SelectedValue == "Select")
			{
				UpdateInformationError.Add("Select Account Type");
			}

		}


		protected void lnkBtnGetBalance_Click(object sender, EventArgs e)
		{

            FundAccount.Visible = false;
            GetBalance.Visible = true;
            UpdateVirtualWallet.Visible = false;
            divViewTrans.Visible = false;
            //string VWID = 

            objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetCurrentBalance";
			objCommand.Parameters.Clear();

			objCommand.Parameters.AddWithValue("@VWID", Session["userVWID"].ToString());

			DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

			double balance = (double)objDB.GetField("Balance", 0);

			double formatToMoney;
			string num = balance.ToString();
			if (double.TryParse(num, out formatToMoney))
			{
				string newNum = String.Format("{0:c}", formatToMoney);
				txtVirtualWalletBalance.Text = newNum;
			}

		}

		protected void lnkBtnFundAccount_Click(object sender, EventArgs e)
		{
			FundAccount.Visible = true;
			GetBalance.Visible = false;
			UpdateVirtualWallet.Visible = false;
            divViewTrans.Visible = false;
		}


		protected void lnkBtnUpdatePaymentAccount_Click(object sender, EventArgs e)
		{
			FundAccount.Visible = false;
			GetBalance.Visible = false;
			UpdateVirtualWallet.Visible = true;
            divViewTrans.Visible = false;
		}

		protected void btnFund_Click(object sender, EventArgs e)
		{
			ValidateItemInformation();

			if (!(UpdateInformationError.Count > 0))
			{
				Merchant CurrMerchant = new Merchant();
				APIKey CurrAPIKey = new APIKey();

				CurrMerchant.MerchantID = "78735";
				CurrAPIKey.Key = "7636";


				VWHolder newVW = new VWHolder();
				newVW.FundsToAdd = int.Parse(txtAmountToFund.Text.ToString());
				newVW.VWID = Session["userVWID"].ToString();
				JavaScriptSerializer js = new JavaScriptSerializer();  //Converts Object into JSON String
				String jsonCreditCard = js.Serialize(newVW);

				try
				{
					String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tuf05666/WebAPI/api/service/PaymentGateway/FundAccount";

					url = url + "/" + CurrMerchant.MerchantID + "/" + CurrAPIKey.Key;

					WebRequest request = WebRequest.Create(url);
					request.Method = "PUT";

					request.ContentLength = jsonCreditCard.Length;
					request.ContentType = "application/json";


					StreamWriter writer = new StreamWriter(request.GetRequestStream());
					writer.Write(jsonCreditCard);
					writer.Flush();
					writer.Close();

					WebResponse response = request.GetResponse();
					Stream theDataStream = response.GetResponseStream();
					StreamReader reader = new StreamReader(theDataStream);
					String data = reader.ReadToEnd();
					reader.Close();
					response.Close();
					if (data == "true")
					{
						Response.Write("Funds added");
					}
					else
					{
						Response.Write("Error Occured on the database.");
					}
				}
				catch (Exception errorException)
				{
					Response.Write(errorException.Message);
				}
			}
			else
			{
				for (int i = 0; i < UpdateInformationError.Count; i++)
				{
					Response.Write(UpdateInformationError[i] + " <br/>");
				}
			}
		}

		protected void btnUpdateInfo_Click(object sender, EventArgs e)
		{
			ValidatePaymentInformation();

			if (!(UpdateInformationError.Count > 0))
			{
				Merchant CurrMerchant = new Merchant();
				APIKey CurrAPIKey = new APIKey();

				CurrMerchant.MerchantID = "78735";
				CurrAPIKey.Key = "7636";


				VWHolder newVW = new VWHolder();
				newVW.PaymentMethodName = txtPaymentMethodName.Text.ToString();
				newVW.AccountNumber = txtAccountNumber.Text.ToString();
				newVW.AccountType = ddlAccountType.SelectedValue.ToString();
				newVW.CurrentBalance = int.Parse(txtInitialBalance.Text.ToString());
				newVW.VWID = Session["userVWID"].ToString();
				JavaScriptSerializer js = new JavaScriptSerializer();  //Converts Object into JSON String
				String jsonCreditCard = js.Serialize(newVW);

				try
				{
					String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tuf05666/WebAPI/api/service/PaymentGateway/UpdatePaymentAccount";

					url = url + "/" + CurrMerchant.MerchantID + "/" + CurrAPIKey.Key;

					WebRequest request = WebRequest.Create(url);
					request.Method = "PUT";

					request.ContentLength = jsonCreditCard.Length;
					request.ContentType = "application/json";


					StreamWriter writer = new StreamWriter(request.GetRequestStream());
					writer.Write(jsonCreditCard);
					writer.Flush();
					writer.Close();

					WebResponse response = request.GetResponse();
					Stream theDataStream = response.GetResponseStream();
					StreamReader reader = new StreamReader(theDataStream);
					String data = reader.ReadToEnd();
					reader.Close();
					response.Close();
					if (data == "true")
					{
						Response.Write("Funds added");
					}
					else
					{
						Response.Write("Error Occured on the database.");
					}
				}
				catch (Exception errorException)
				{
					Response.Write(errorException.Message);
				}
			}
			else
			{
				for (int i = 0; i < UpdateInformationError.Count; i++)
				{
					Response.Write(UpdateInformationError[i] + " <br/>");
				}
			}
		}

		protected void lnkBtnViewTransactions_Click(object sender, EventArgs e)
		{
            FundAccount.Visible = false;
            GetBalance.Visible = false;
            UpdateVirtualWallet.Visible = false;
            divViewTrans.Visible = true;

			if (!(UpdateInformationError.Count > 0))
			{
				Merchant CurrMerchant = new Merchant();
				APIKey CurrAPIKey = new APIKey();

				CurrMerchant.MerchantID = "78735";
				CurrAPIKey.Key = "7636";


				VWHolder newVW = new VWHolder();

				newVW.VWID = Session["userVWID"].ToString();

				try
				{

					String url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tuf05666/WebAPI/api/service/PaymentGateway/GetTransactions";

					url = url + "/" + newVW.VWID + "/" + CurrMerchant.MerchantID + "/" + CurrAPIKey.Key;

					WebRequest request = WebRequest.Create(url);

					WebResponse response = request.GetResponse();


					Stream theDataStream = response.GetResponseStream();
					StreamReader reader = new StreamReader(theDataStream);
					String data = reader.ReadToEnd();
					reader.Close();
					response.Close();

					JavaScriptSerializer js = new JavaScriptSerializer();

					Transactions[] TransactionData = js.Deserialize<Transactions[]>(data);

					gvTransactions.DataSource = TransactionData;
					gvTransactions.DataBind();



				}
				catch (Exception errorException)
				{
					Response.Write(errorException.Message);
				}
			}
			else
			{
				for (int i = 0; i < UpdateInformationError.Count; i++)
				{
					Response.Write(UpdateInformationError[i] + " <br/>");
				}
			}
		}

	}
}