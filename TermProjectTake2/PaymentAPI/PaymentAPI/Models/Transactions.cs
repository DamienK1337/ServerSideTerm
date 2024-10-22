﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace PaymentAPI.Models
{
	public class Transactions
	{

		public string VWIDReceiver { get; set; }
		public string VWIDSender { get; set; }

		public string Amount { get; set; }

		public string Type { get; set; }
		public string Date { get; set; }


		public double SenderBalance { get; set; }

		public double ReceiverBalance { get; set; }

		

		public Transactions()
		{

		}

		public double FindReceiverBalance()
		{
			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();




			//DataSet ds = objDB.GetDataSet("SELECT Balance FROM TPVWHolder WHERE VWID='4895'");
			DataSet ds = objDB.GetDataSet("SELECT Balance FROM TPVWHolder WHERE VWID='" + this.VWIDReceiver +"'");
			foreach (DataRow record in ds.Tables[0].Rows)
			{

				string rb =record["Balance"].ToString();

				ReceiverBalance = double.Parse(rb);

			}

			

			return ReceiverBalance;
		}

		public double FindSenderBalance()
		{
			DBConnect objDB = new DBConnect();

			SqlCommand objCommand = new SqlCommand();


			//DataSet ds2 = objDB.GetDataSet("SELECT Balance FROM TPVWHolder WHERE VWID='5336'");
			DataSet ds2 = objDB.GetDataSet("SELECT Balance FROM TPVWHolder WHERE VWID='" + this.VWIDSender +"'");
			foreach (DataRow record in ds2.Tables[0].Rows)
			{

				string sb = record["Balance"].ToString();

				SenderBalance = double.Parse(sb);

			}

			return SenderBalance;
		}


		







	}
}
