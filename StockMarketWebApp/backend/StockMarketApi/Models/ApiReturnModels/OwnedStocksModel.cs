using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiReturnModels
{
    public class OwnedStocksModel
    {
        public string StockSymbol { get; set; }
        public string CompanyName { get; set; }
        public int NumberOfShares { get; set; }
        public decimal PercentChange { get; set; }
        public decimal CurrentSharePrice { get; set; }
        public decimal AvgPurchasedPrice { get; set; }
    }
}
