using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    public class Menu
    {
        public string MenuName { get; set; }
        public string ImgURL { get; set; }
        public string MenuDescription { get; set; }


        public Menu()
        {

        }

        public Boolean CheckIfMenuExists(String MenuName)
        {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPCheckIfMenuExists";
            SqlParameter inputParameter = new SqlParameter("@MenuName", MenuName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            objCommand.Parameters.Add(inputParameter);

            DataSet MenuNameDataSet = dbConnection.GetDataSetUsingCmdObj(objCommand);
            if (MenuNameDataSet.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
