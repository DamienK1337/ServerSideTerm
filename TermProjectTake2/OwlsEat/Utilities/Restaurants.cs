using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Restaurants
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cuisine { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
		public string SecurityQuestion { get; set; }
		public string SecurityAnswer { get; set; }
		public string ImgURL { get; set; }



		public Restaurants()
        {

        }



        public bool AddAddRestaurant()
        {
            bool added = true;

            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "TPAddRestaurant";


            objCommand.Parameters.AddWithValue("@Email", Email);
            objCommand.Parameters.AddWithValue("@Password", Password);
            objCommand.Parameters.AddWithValue("@FirstName", FirstName);
            objCommand.Parameters.AddWithValue("@LastName", LastName);
            objCommand.Parameters.AddWithValue("@Cuisine", Cuisine);
            objCommand.Parameters.AddWithValue("@RestaurantName", RestaurantName);
            objCommand.Parameters.AddWithValue("@Location", Location);
            objCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
			objCommand.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
			objCommand.Parameters.AddWithValue("@SecurityAnswer", SecurityAnswer);
			objCommand.Parameters.AddWithValue("@ImgURL", ImgURL);

			var result = objDB.DoUpdateUsingCmdObj(objCommand);

            if (result == -1)
                added = false;
            return added;
        }
    }
}
