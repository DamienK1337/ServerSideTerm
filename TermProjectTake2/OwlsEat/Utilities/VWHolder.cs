using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
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
	}
}
