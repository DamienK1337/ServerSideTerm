using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace PaymentAPI.Models
{
	public class VWHolder
	{

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();


        public String VWID { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String AccountNumber { get; set; }
        public String PaymentMethodName { get; set; }
        public String AccountType { get; set; }

        public int CurrentBalance { get; set; }

        public int FundsToAdd { get; set; }

        public String APIKey { get; set; }

        public String MerchantID { get; set; }

        string checkemail;
		public VWHolder()
		{

		}


		public string  AddCustomer()
		{
			

			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.CommandText = "TPAddVWHolder";

			int _min = 0000;
			int _max = 9999;
			Random rdm = new Random();
			VWID = rdm.Next(_min, _max).ToString();

			// This is just used to assign the merchant information to the new VWID to see which merchant issued the Virtual Wallet

			DataSet ds = objDB.GetDataSet("SELECT * FROM TPMerchant WHERE CompanyName='76ers'");

			foreach (DataRow record in ds.Tables[0].Rows)
			{
				
				APIKey= record["APIKey"].ToString();
				MerchantID = record["MerchantID"].ToString();
			}



			objCommand.Parameters.AddWithValue("@Name", Name);
			objCommand.Parameters.AddWithValue("@Password", Password);
			objCommand.Parameters.AddWithValue("@Email", Email);
			objCommand.Parameters.AddWithValue("@AccountNumber", AccountNumber);
			objCommand.Parameters.AddWithValue("@VWID", VWID);
			objCommand.Parameters.AddWithValue("@APIKey", APIKey);
			objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);

			var result = objDB.DoUpdateUsingCmdObj(objCommand);

			if (result != -1)
			{
				return VWID;
			}
				
			return VWID;
		}

	

		public int GetCurrentBalance()
		{
			
			DataSet MyCurrentBalance = new DataSet();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetCurrentBalance";
			objCommand.Parameters.Clear();


			objCommand.Parameters.AddWithValue("@VWID", VWID);
			MyCurrentBalance = objDB.GetDataSetUsingCmdObj(objCommand);

			foreach (DataRow record in MyCurrentBalance.Tables[0].Rows)
			{

				string gcb = record["Balance"].ToString();

				CurrentBalance = int.Parse(gcb);

			}

			return CurrentBalance;
		}

		public bool CheckIfInCustomer(string useremail)
		{
			//bool added = true;
			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;

			DataSet ds = objDB.GetDataSet("SELECT * FROM TPCustomers WHERE Email='" + useremail + "'");

			

			foreach (DataRow record in ds.Tables[0].Rows)
			{

				checkemail = record["Email"].ToString();
				

			}
			if (checkemail != "")
			{
				return true;
			}



			else
			{
				return false;
			}


		

			
		}

		public bool UpdateCustomerDB(int VWID)
		{
			bool added = true;
			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPAddVWHolder";

			objCommand.Parameters.AddWithValue("@Name", VWID);
			objCommand.Parameters.AddWithValue("@Password", Password);
			objCommand.Parameters.AddWithValue("@Email", Email);
			objCommand.Parameters.AddWithValue("@AccountNumber", AccountNumber);
			objCommand.Parameters.AddWithValue("@VWID", VWID);
			objCommand.Parameters.AddWithValue("@APIKey", APIKey);
			objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);

			var result = objDB.DoUpdateUsingCmdObj(objCommand);

			if (result == -1)
				added = false;
			return added;
		}

	}
}

	


