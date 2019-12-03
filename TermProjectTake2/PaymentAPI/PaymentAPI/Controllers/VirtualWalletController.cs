using System;
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

		//Create Virtual Wallet for any user
		//Store Procedures Complete
		[HttpPost("CreateVW")]
		public string Post([FromBody] VWHolder newVW, MerchantID newMID, WebAPI newWebKey) {
			string Result ="";
			if ((newMID.MerchantIDKey == "78735") && (newWebKey.WebAPIKey == "7636"))
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

			return Result;

		}
		//GEt Transactions based on VWID REveiver ID
		//Sotre Procedures Complete
		[HttpGet("GetTransactions/{newVW}/{MerchantIDKey}/{newWebKey}")]
		public List<Transactions> Get(string newVW, string MerchantIDKey, string WebAPIKey)
		{
			//Get(Object VWHolder, Object MerchantID, Object WebAPI)

			MerchantID newMD = new MerchantID();
			WebAPI newWB = new WebAPI();

			newMD.MerchantIDKey = MerchantIDKey;
			newWB.WebAPIKey = WebAPIKey;


			List<Transactions> TransactionsList = new List<Transactions>();
			if ((newMD.MerchantIDKey == "78735") && (newWB.WebAPIKey == "7636"))
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
		public Boolean Post([FromBody] Transactions newTransaction, MerchantID newMID, WebAPI newWebKey)
		{
			if ((newMID.MerchantIDKey == "78735") && (newWebKey.WebAPIKey == "7636"))
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
		public void UpdatePaymentAccount([FromBody] VWHolder curVW, MerchantID newMID, WebAPI newWebKey)
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
		[HttpPut("FundAccount/{VWHolder}")]
		public void FundAccount([FromBody] VWHolder curVW, MerchantID newMID, WebAPI newWebKey)
		{
			DBConnect objDB = new DBConnect();
			SqlCommand objCommand = new SqlCommand();

			int currentBal = curVW.GetCurrentBalance();

			int AmountToAdd = curVW.FundsToAdd;

			int NewBalance = currentBal + AmountToAdd;

			//DataSet MyCurrentBalance = new DataSet();
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.CommandText = "TPAddToBalance";
			objCommand.Parameters.Clear();

			string VWID = "5336";

			objCommand.Parameters.AddWithValue("@VWID", VWID);
			objCommand.Parameters.AddWithValue("@NewBalance", NewBalance);
			
			int responsereceived;
			responsereceived = objDB.DoUpdateUsingCmdObj(objCommand);




			
		}



	}



}