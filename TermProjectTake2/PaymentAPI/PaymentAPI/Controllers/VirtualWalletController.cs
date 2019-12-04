﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using PaymentAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace PaymentAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/service/PaymentGateway")]
	

	public class VirtualWalletController : Controller
	{
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        //Create Virtual Wallet for any user
        //Store Procedures Complete
        [HttpPost("CreateVW/{MerchantID}/{APIKey}")]
		public string Post([FromBody] VWHolder newVW, string MerchantID, string Key)
		{
			string Result = "test";
			if ((MerchantID == "78735") && (Key == "7636"))
			{
				Result = newVW.AddCustomer();



				//if(Result == true)
				//{
				//	return true;
				//}
				//else
				//{
				//	return false;
				//}
				return Result;
			}
			else { 

			return Result;
		}

		}
		//Get Transactions based on VWID Receiver ID
		//Store Procedures Complete
		[HttpGet("GetTransactions/{newVW}/{MerchantIDKey}/{newWebKey}")]
		public List<Transactions> Get(string newVW, string MerchantID, string Key)
		{
			//Get(Object VWHolder, Object MerchantID, Object APIKey)

			Merchant newMD = new Merchant();
			APIKey newWB = new APIKey();

			newMD.MerchantID = MerchantID;
			newWB.Key = Key;


			List<Transactions> TransactionsList = new List<Transactions>();
			if ((newMD.MerchantID == "78735") && (newWB.Key == "7636"))
			{
				DBConnect objDB = new DBConnect();
				SqlCommand objCommand = new SqlCommand();

				objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.CommandText = "TPGetTransaction";
				objCommand.Parameters.Clear();

				string VWIDReceiver = newVW;
				
				//string VWIDReceiver = newVW.VWID;
				objCommand.Parameters.AddWithValue("@VWIDReceiver", VWIDReceiver);
				DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);




				foreach (DataRow record in ds.Tables[0].Rows)
				{
					Transactions newTrans = new Transactions();
					newTrans.VWIDReceiver = record["VWIDReceiver"].ToString();
					newTrans.VWIDSender = record["VWIDSender"].ToString();
					newTrans.Amount = record["Amount"].ToString();
					newTrans.Date = record["Date"].ToString();


					TransactionsList.Add(newTrans);
				}
			}
			return TransactionsList;
			

		}
		//Post Method that process Transactions
		//Store Procedures Complete
		[HttpPost("ProcessPayment")]
		public Boolean Post([FromBody] Transactions newTransaction, Merchant newMID, APIKey newWebKey)
		{
			if ((newMID.MerchantID == "78735") && (newWebKey.Key == "7636"))
			{

			
			string VWIDReceiver = newTransaction.VWIDReceiver;
			string VWIDSender = newTransaction.VWIDSender;
			DateTime dt = DateTime.Now;
			int amount = int.Parse(newTransaction.Amount);

			int NewSenderBalance = newTransaction.FindSenderBalance() - amount;

			int NewReceiverBalance = newTransaction.FindReceiverBalance() + amount;
			int responsereceived;



			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPUpdateSenderBalance";
			objCommand.Parameters.Clear();

			objCommand.Parameters.AddWithValue("@VWIDSender", VWIDSender);
			objCommand.Parameters.AddWithValue("@NewSenderBalance", NewSenderBalance);

			
			responsereceived = objDB.DoUpdateUsingCmdObj(objCommand);


			
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPUpdateReceiverBalance";
			objCommand.Parameters.Clear();

			objCommand.Parameters.AddWithValue("@VWIDReceiver", VWIDReceiver);
			objCommand.Parameters.AddWithValue("@NewReceiverBalance", NewReceiverBalance);


			responsereceived = objDB.DoUpdateUsingCmdObj(objCommand);


			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPAddTransaction";
			objCommand.Parameters.Clear();

			
			objCommand.Parameters.AddWithValue("@VWIDReceiver", VWIDReceiver);
			objCommand.Parameters.AddWithValue("@VWIDSender", VWIDSender);
			objCommand.Parameters.AddWithValue("@Amount", amount);
			objCommand.Parameters.AddWithValue("@Type", newTransaction.Type);
			objCommand.Parameters.AddWithValue("@Date", dt);
			
			responsereceived = objDB.DoUpdateUsingCmdObj(objCommand);




			if (responsereceived > 0)
				{
					return true;
				}

				else { return false; }	
			



			}
			return false;
		}
		//Put Method For Updating Customer PaymentAccount
		//Store Procedure Complete
		[HttpPut("UpdatePaymentAccount/{VWHolder}")]
		public void UpdatePaymentAccount([FromBody] VWHolder curVW, Merchant newMID, APIKey newWebKey)
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();
			string VWID = "5336";
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPUpdatePaymentAccount";

			objCommand.Parameters.AddWithValue("@VWID", VWID);
			objCommand.Parameters.AddWithValue("@CreditCard", curVW.CreditCard);

			int responsereceived;
			responsereceived = objDB.DoUpdateUsingCmdObj(objCommand);

		
		}

		//Funding Account
		//Store Procedure Complete
		[HttpPut("FundAccount/{MerchantID}/{APIKey}")]
		public Boolean FundAccount([FromBody] VWHolder curVW, string MerchantID, string Key)
		{

            if ((MerchantID == "78735") && (Key == "7636"))
            {

                string VWID = curVW.VWID;

                int currentBal = curVW.GetCurrentBalance();

                int AmountToAdd = curVW.FundsToAdd;

                int NewBalance = currentBal + AmountToAdd;

                

                //DataSet MyCurrentBalance = new DataSet();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TPAddToBalance";
                objCommand.Parameters.Clear();

               

                objCommand.Parameters.AddWithValue("@VWID", VWID);
                objCommand.Parameters.AddWithValue("@NewBalance", NewBalance);

                int ResponseReceived;
                ResponseReceived = objDB.DoUpdateUsingCmdObj(objCommand);
                if(ResponseReceived == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        
		}

	}

}