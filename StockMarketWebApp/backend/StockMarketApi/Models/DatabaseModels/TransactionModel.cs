using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string StockSymbol { get; set; }
        public int NumberOfShares { get; set; }
        public decimal TransactionSharePrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPurchase { get; set; }
        public decimal NetTransactionChange { get; set; }
    }
}
