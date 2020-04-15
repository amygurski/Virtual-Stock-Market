using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.StockTransactions
{
    /// <summary>
    /// Model for barchart public API
    /// </summary>
    public class StockAPIModel
    {
        /// <summary>
        /// Status for API request
        /// </summary>
        public Status status { get; set; }
        /// <summary>
        /// results is the array of results
        /// </summary>
        public Result[] results { get; set; }
    }

    /// <summary>
    /// Status for the API request has the HTTP code and message
    /// </summary>
    public class Status
    {
        /// <summary>
        /// HTTP Code from response
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// message from response
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// Data for each stock result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// A symbol or code that identifies a financial instrument.
        /// </summary>
        public string symbol { get; set; }

        /// <summary>
        /// stock exchange
        /// </summary>
        public string exchange { get; set; }

        /// <summary>
        /// The type of symbol used.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The day code for the session. Day codes are "1-9" for days 1 through 9, "0" (zero) for the 10th of the month, and "A - U" for days 11 through 31.
        /// </summary>
        public string dayCode { get; set; }

        /// <summary>
        /// The time the message was generated on the server.
        /// </summary>
        public DateTime serverTimestamp { get; set; }

        /// <summary>
        /// An indicator representing if the quote is real-time ("R"), delayed ("I") or end-of-day ("D") if available.
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// The last price the instrument traded.
        /// </summary>
        public float lastPrice { get; set; }

        /// <summary>
        /// The exchange timestamp for the last traded price.
        /// </summary>
        public DateTime tradeTimestamp { get; set; }

        /// <summary>
        /// The difference between the last traded price and the previous close.
        /// </summary>
        public float netChange { get; set; }
        public float percentChange { get; set; }
        public string unitCode { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public object close { get; set; }
        public string flag { get; set; }
        public int volume { get; set; }
    }

}
