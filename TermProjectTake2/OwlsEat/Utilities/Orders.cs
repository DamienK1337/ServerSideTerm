using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
	public class Orders
	{

		public string RestaurantId { get; set; }

		public string CustomerName { get; set; }

		public string CustomerId { get; set; }

		public string VWIDSender { get; set; }
		public string VWIDReceiver { get; set; }
		
		public string PurchasedItems { get; set; }
		
		public float Total { get; set; }

		public string Date { get; set; }

		public Orders()
		{

		}
	}
}
