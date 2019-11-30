using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Utilities;

namespace OwlsEat
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{

		}

		protected void Session_Start(object sender, EventArgs e)
		{
			//Session.Add("sessionStart", System.DateTime.Now.ToShortDateString());

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{
			//DBConnect objDB = new DBConnect();
			//SqlCommand objCommand = new SqlCommand();
			//BinaryFormatter serializer = new BinaryFormatter();
			//MemoryStream memoryStream = new MemoryStream();
			//Settings userSettings = (Settings)Session["userSettings"];
			//if (userSettings != null)
			//{


			//	serializer.Serialize(memoryStream, userSettings);
			//	Byte[] byteSettings = memoryStream.ToArray();

			//	objCommand.CommandType = CommandType.StoredProcedure;
			//	objCommand.CommandText = "TPUpdateUserSettings";

			//	objCommand.Parameters.AddWithValue("@theUserEmail", Session["userEmail"].ToString());
			//	objCommand.Parameters.AddWithValue("@theSettings", byteSettings);

			//	int ResponseRecevied = objDB.DoUpdateUsingCmdObj(objCommand);
			//}
		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}