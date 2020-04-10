using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiReturnModels
{
	public class StockTransaction
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int GameId { get; set; }
		public string StockSymbol { get; set; }
		public string CompanyName { get; set; }
		public int NumberOfShares { get; set; }
		public decimal TransactionPrice { get; set; }
		public DateTime TransactionDate { get; set; }
		public bool IsPurchase { get; set; }
		public decimal NetValue { get; set; }

	}
}
