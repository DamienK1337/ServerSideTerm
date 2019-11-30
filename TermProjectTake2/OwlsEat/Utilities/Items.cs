using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
   public  class Items
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public float Price { get; set; }
      

        public Items()
        {

        }



        //public bool AddAddRestaurant()
        //{
        //    bool added = true;

        //    DBConnect objDB = new DBConnect();

        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;

        //    objCommand.CommandText = "TPAddRestaurant";


        //    objCommand.Parameters.AddWithValue("@Email", Email);
        //    objCommand.Parameters.AddWithValue("@Password", Password);
        //    objCommand.Parameters.AddWithValue("@FirstName", FirstName);
        //    objCommand.Parameters.AddWithValue("@LastName", LastName);
        //    objCommand.Parameters.AddWithValue("@Cuisine", Cuisine);
        //    objCommand.Parameters.AddWithValue("@RestaurantName", RestaurantName);
        //    objCommand.Parameters.AddWithValue("@Location", Location);
        //    objCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
        //    objCommand.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
        //    objCommand.Parameters.AddWithValue("@SecurityAnswer", SecurityAnswer);
        //    objCommand.Parameters.AddWithValue("@ImgURL", ImgURL);

        //    var result = objDB.DoUpdateUsingCmdObj(objCommand);

        //    if (result == -1)
        //        added = false;
        //    return added;
        //}
    }
}
