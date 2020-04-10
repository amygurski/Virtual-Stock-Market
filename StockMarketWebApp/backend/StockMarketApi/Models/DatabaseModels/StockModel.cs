using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    public class StockModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime ServerTimestamp { get; set; }
        public float PercentChange { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public object Close { get; set; }
        public int Volume { get; set; }
        public float LastPrice { get; set; }
    }
}
