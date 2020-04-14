using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    public class StockHistoryModel
    {
        public int Id { get; set; }
        public string StockSymbol { get; set; }
        public DateTime TradingDay { get; set; }
        public double OpenPrice { get; set; }
        public double DailyHigh { get; set; }
        public double DailyLow { get; set; }
        public double ClosePrice { get; set; }
        public int Volume { get; set; }
    }
}
