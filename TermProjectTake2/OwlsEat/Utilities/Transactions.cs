using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
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


	}

}


