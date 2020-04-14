using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiReturnModels
{
    public class ResearchStocksAPIModel
    {
        public string StockSymbol { get; set; }

        //From stocks table
        public string CompanyName { get; set; } 
        public double CurrentPrice { get; set; } 
        public double PercentChange { get; set; }

        //From 6 month stock history table
        public double SixMonthHigh { get; set; }
        public double SixMonthLow { get; set; }
    }
}
