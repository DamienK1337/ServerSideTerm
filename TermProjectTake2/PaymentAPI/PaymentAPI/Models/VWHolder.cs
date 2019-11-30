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
		public String Name { get; set; }
		public String Password { get; set; }
		public String Email { get; set; }
		public String CreditCard { get; set; }
		public String VWID { get; set; }

		public String APIKey { get; set; }

		public String MerchantID { get; set; }

		public int CurrentBalance { get; set; }

		public int FundsToAdd { get; set; }

		public VWHolder()
		{

		}


		public bool AddCustomer()
		{
			bool added = true;

			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.CommandText = "TPAddVWHolder";

			int _min = 0000;
			int _max = 9999;
			Random rdm = new Random();
			VWID = rdm.Next(_min, _max).ToString();

			DataSet ds = objDB.GetDataSet("SELECT * FROM TPMerchant WHERE CompanyName='76ers'");

			foreach (DataRow record in ds.Tables[0].Rows)
			{
				
				APIKey= record["APIKey"].ToString();
				MerchantID = record["MerchantID"].ToString();
			}



			objCommand.Parameters.AddWithValue("@Name", Name);
			objCommand.Parameters.AddWithValue("@Password", Password);
			objCommand.Parameters.AddWithValue("@Email", Email);
			objCommand.Parameters.AddWithValue("@CreditCard", CreditCard);
			objCommand.Parameters.AddWithValue("@VWID", VWID);
			objCommand.Parameters.AddWithValue("@APIKey", APIKey);
			objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);

			var result = objDB.DoUpdateUsingCmdObj(objCommand);

			if (result == -1)
				added = false;
			return added;
		}

	

		public int GetCurrentBalance()
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();


			//DataSet ds2 = objDB.GetDataSet("SELECT Balance FROM TPVWHolder WHERE VWID='5336'");

			DataSet MyCurrentBalance = new DataSet();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPGetCurrentBalance";
			objCommand.Parameters.Clear();

			VWID = "5336";

			objCommand.Parameters.AddWithValue("@VWID", VWID);
			MyCurrentBalance = objDB.GetDataSetUsingCmdObj(objCommand);

			foreach (DataRow record in MyCurrentBalance.Tables[0].Rows)
			{

				string gcb = record["Balance"].ToString();

				CurrentBalance = int.Parse(gcb);

			}

			return CurrentBalance;
		}

	}
}

	


