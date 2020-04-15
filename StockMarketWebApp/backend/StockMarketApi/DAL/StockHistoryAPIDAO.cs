using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System;
using Newtonsoft.Json;
using StockMarketApi.Models.ApiInputModels.StockHistoryApiModel;
using StockMarketApi.Models.DatabaseModels;

namespace StockMarketApi.DAL
{
    public class StockHistoryAPIDAO : IStockHistoryAPIDAO
    {
        private string[] stocks = new string[] { "AAPL", "TSLA", "MSFT", "BA", "BAC", "AMD", "LK", "CCL", "AAL", "FB", "GE", "F", "DIS", "ZM", "NVDA", "AMZN", "T", "XOM", "DAL", "UBER", "GILD", "OXY", "SQ", "BABA", "MU", "NFLX", "TWTR", "UCO", "JPM", "C", "RCL", "SNAP", "INTC", "MGM", "UAL", "WFC", "AMRN", "ROKU", "TLRY", "WMT", "X", "LYFT", "FCX", "SBUX", "SPCE", "M", "TEVA", "GM", "PBR", "CSCO", "IQ", "WYNN", "CVX", "HAL", "VZ", "APA", "SDC", "PFE", "V", "JD", "COST", "NCLH", "JNJ", "BYND", "KO", "SLB", "GOOGL", "WORK", "XLK", "BP", "BMY", "GSX", "CAT", "MRO", "TAL", "PTON", "GOLD", "QCOM", "TGT", "CMCSA", "MAR", "SHOP", "BIDU", "EWJ", "HD", "ACB", "VALE", "PYPL", "MA", "MS", "INO", "MCD", "BBBY", "PINS", "VIAC", "GME", "IBM", "CVS", "DVN", "DOCU", "KHC", "MRNA", "PENN", "ABT", "BRK / B", "KSS", "NKE", "NLY", "GS", "FCAU", "CRM", "LB", "PDD", "NRZ", "EXPE", "LUV", "W", "GOOG", "CHWY", "HEXO", "PCG", "ADBE", "AVGO", "MRVL", "COP", "GRUB", "LYV", "LVS", "MMM", "APT", "MRK", "UNH", "SGMS", "AMC", "IMMU", "AXP", "CGC", "ABBV", "FDX", "SE", "WBA", "MO", "HSBC", "NEM", "HPQ", "SAN", "PG", "ATVI", "KOD", "FIT" };

        private string[] apiKeys = new string[] { "f32669fc5614fbd62719ba6543de5576", "af26319a23a6675378f3c947e95706a7", "0f680953606fb7867fff9fcd89b6644d", "31a2d95da1cf2b19dbabb725d7ff9136", "6280cd9f954a04678ce3ccf8118d98c8", "afa5726a99abf879bc0ebe9072a6de7b", "f39f79b131e230ba3eed0a7a41df0373", "5bf90426743f6f87f273d308fa0dd13e", "4b3dba4d17d2f3796ba20a53383f1859" };

        /// <summary>
        /// Gets just the past days stock history
        /// </summary>
        public IList<StockHistoryModel> GetLastCloseStockHistory()
        {
            List<StockHistoryApiModel> historyResults = new List<StockHistoryApiModel>();

            int currentStockIndex = 0;
            int currentApiKeyIndex = 0;
            WebClient client = new WebClient();

            for (; currentApiKeyIndex < apiKeys.Length; currentApiKeyIndex++)
            {
                string apiRequest = $"https://marketdata.websol.barchart.com/getHistory.json?apikey={apiKeys[currentApiKeyIndex]}&type=daily&symbol=";

                try
                {
                    for (; currentStockIndex < stocks.Length; currentStockIndex++)
                    {
                        string response = client.DownloadString(apiRequest + stocks[currentStockIndex]);
                        historyResults.Add(JsonConvert.DeserializeObject<StockHistoryApiModel>(response));
                    }
                    break;
                }
                catch
                {
                    continue;
                }
            }

            List<StockHistoryModel> models = new List<StockHistoryModel>();

            foreach (StockHistoryApiModel historyResult in historyResults)
            {
                Result[] results = null;

                if (historyResult.results != null && historyResult.results.Length != 0)
                {
                    results = historyResult.results;
                }
                else
                {
                    results = new Result[1];
                    results[0] = null;
                }
 
                //Add the stock details required for stock to our stock model
                foreach (Result result in results)
                {
                    if (result != null)
                    {
                        StockHistoryModel newStock = new StockHistoryModel();
                        newStock.StockSymbol = result.symbol;
                        newStock.TradingDay = Convert.ToDateTime(result.tradingDay);
                        newStock.OpenPrice = result.open;
                        newStock.DailyHigh = result.high;
                        newStock.DailyLow = result.low;
                        newStock.ClosePrice = result.close;
                        newStock.Volume = result.volume;

                        models.Add(newStock);
                    }
                }
            }

            return models;
        }
    }
}



        //public void GetSixMonthStockHistory()
        //{

        //    //Subtract 6 months
        //    DateTime sixMonthsAgo = DateTime.Today.AddMonths(-6);

        //    //Get in correct format for API
        //    string startDate = sixMonthsAgo.ToString("yyyyMMdd");

        //    //This request will get the past 6 months of data from today
        //    string apiRequest = $"https://marketdata.websol.barchart.com/getHistory.csv?apikey=f32669fc5614fbd62719ba6543de5576&type=dailyContinue&startDate={startDate}&symbol=";
        //    //to just get closed day:
        //    //string apiRequest = $"https://marketdata.websol.barchart.com/getHistory.csv?apikey=f32669fc5614fbd62719ba6543de5576&type=daily&symbol=";

        //    foreach (string stock in stocks)
        //    {
        //        WebClient client = new WebClient();

        //        //Make API request for stock market history for each of the stocks
        //        string response = client.DownloadString(apiRequest + stock);

        //        //Appends each stock history to file
        //        using (StreamWriter sw = new StreamWriter("historicstockdata.csv", true))
        //        {
        //            sw.WriteLine(response);
        //        }
        //    }
        //}