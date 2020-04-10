using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.StockTransactions
{
    public class NewTransactionAPIModel
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string StockSymbol { get; set; }
        public int NumberOfShares { get; set; }
        public int SharePrice { get; set; }
        public bool IsPurchase { get; set; }
    }
}
