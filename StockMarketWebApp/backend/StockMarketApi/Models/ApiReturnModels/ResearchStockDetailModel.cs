using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiReturnModels
{
    public class ResearchStockDetailModel
    {
        public string StockSymbol { get; set; }
        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal DailyChange { get; set; }
        public double NetChangeSixMonths { get; set; }
        public double SixMonthLow { get; set; }
        public double SixMonthHigh { get; set; }
        public double PreviousDayVolume { get; set; }
        public double AverageDailyVolume { get; set; }
        public double PreviousDayOpen { get; set; }
        public double PreviousDayClose { get; set; }
        

    }
}
