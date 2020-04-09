using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models
{
    public class StockTransaction
    {
		public int UserId { get; set; }
		public int GameId { get; set; }
		public string StockSymbol { get; set; }
		public int NumberOfShares { get; set; }
		public decimal TransactionPrice { get; set; }
		public DateTime TransactionDate { get; set; }
		public bool IsPurchase { get; set; }

	}
}
