using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models
{
    public class CurrentStock
    {
        public string StockSymbol { get; set; }

        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PercentChange { get; set; }
    }
}
