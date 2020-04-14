using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    public class SixMonthHighLowModel
    {
        public string StockSymbol { get; set; }
        public double SixMonthHigh { get; set; }
        public double SixMonthLow { get; set; }

    }
}
