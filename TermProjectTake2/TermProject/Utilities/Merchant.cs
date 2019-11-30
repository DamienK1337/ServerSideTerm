using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Utilities
{
	public class Merchant
	{

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string APIKey { get; set; }
        public string MerchantAccountID { get; set; }


        public Merchant()
		{

		}

		public bool AddNewMerchant()
		{

			bool added = true;

			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.CommandText = "TPAddMerchants";


			objCommand.Parameters.AddWithValue("@FirstName", FirstName);
			objCommand.Parameters.AddWithValue("@LastName", LastName);
			objCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
			objCommand.Parameters.AddWithValue("@Email", Email);
			objCommand.Parameters.AddWithValue("@Password", Password);
			objCommand.Parameters.AddWithValue("@APIKey", APIKey);
            objCommand.Parameters.AddWithValue("@MerchantAccountID", MerchantAccountID);


            var result = objDB.DoUpdateUsingCmdObj(objCommand);

			if (result == -1)
				added = false;
			return added;
		}

	}
}
