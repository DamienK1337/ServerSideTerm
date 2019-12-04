using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
	public class Customer
	{

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string DeliveryAddress { get; set; }
		public string BillingAddress { get; set; }

		public string SecurityQuestion { get; set; }

		public string SecurityAnswer  { get; set; }

		public string VWID { get; set; }

        public Customer()
        {

        }



        public bool AddCustomer()
        {
            bool added = true;

            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TPAddCustomer";


            objCommand.Parameters.AddWithValue("@Email", Email);
            objCommand.Parameters.AddWithValue("@Password", Password);
            objCommand.Parameters.AddWithValue("@FirstName", FirstName);
            objCommand.Parameters.AddWithValue("@LastName", LastName);
            objCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            objCommand.Parameters.AddWithValue("@DeliveryAddress", DeliveryAddress);
			objCommand.Parameters.AddWithValue("@BillingAddress", BillingAddress);
			objCommand.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
			objCommand.Parameters.AddWithValue("@SecurityAnswer", SecurityAnswer);
			objCommand.Parameters.AddWithValue("@VWID", VWID);

			var result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result == -1)
                added = false;
            return added;
        }

		public Customer CheckIfUserExist()
		{
			Customer customer = new Customer();
			DBConnect dBConnect = new DBConnect();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCommand.CommandText = "TPValidateCustomer";

			SqlParameter UsernameParam = new SqlParameter("@Email", Email);
			UsernameParam.Direction = System.Data.ParameterDirection.Input;
			UsernameParam.SqlDbType = System.Data.SqlDbType.VarChar;
			UsernameParam.Size = 50;
			sqlCommand.Parameters.Add(UsernameParam);

			SqlParameter PasswordParam = new SqlParameter("@Password", Password);
			PasswordParam.Direction = System.Data.ParameterDirection.Input;
			PasswordParam.SqlDbType = System.Data.SqlDbType.VarChar;
			PasswordParam.Size = 50;
			sqlCommand.Parameters.Add(PasswordParam);

			DataSet dataSet = dBConnect.GetDataSetUsingCmdObj(sqlCommand);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				customer = dataSet.Tables[0].AsEnumerable().Select(dataRow => new Customer
				{
					Email = dataRow.Field<string>("Email"),
					Password = dataRow.Field<string>("Password"),
					FirstName = dataRow.Field<string>("FirstName"),
					LastName = dataRow.Field<string>("LastName"),
					PhoneNumber = dataRow.Field<string>("PhoneNumber"),
					DeliveryAddress = dataRow.Field<string>("DeliveryAddress"),
					BillingAddress = dataRow.Field<string>("BillingAddress"),
					SecurityQuestion = dataRow.Field<string>("SecurityQuestion"),
					SecurityAnswer = dataRow.Field<string>("SecurityAnswer")
				}).ToList().First();
			}

			return customer;
		}

	}
}
