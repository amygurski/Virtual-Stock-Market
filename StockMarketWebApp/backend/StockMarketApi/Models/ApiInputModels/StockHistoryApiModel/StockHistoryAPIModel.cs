using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.StockHistoryApiModel
{
    public class StockHistoryApiModel
    {
        public Status status { get; set; }
        public Result[] results { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Result
    {
        public string symbol { get; set; }
        public DateTime timestamp { get; set; }
        public string tradingDay { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
        public object openInterest { get; set; }
    }
}
