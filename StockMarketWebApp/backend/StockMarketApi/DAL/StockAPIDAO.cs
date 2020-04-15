using Newtonsoft.Json;
using StockMarketApi.Models.ApiInputModels.StockTransactions;
using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// Access real-time stock data from barchart API.
    /// Using getQuote. Limited to 25 symbols per query, 400 queries per day 
    /// Plan to call this in 15 minute intervals from 6am to 6pm
    /// </summary>
    public class StockAPIDAO : IStockAPIDAO
    {
        private string[] apiKeys = new string[] { "f32669fc5614fbd62719ba6543de5576", "af26319a23a6675378f3c947e95706a7", "0f680953606fb7867fff9fcd89b6644d", "31a2d95da1cf2b19dbabb725d7ff9136", "6280cd9f954a04678ce3ccf8118d98c8", "afa5726a99abf879bc0ebe9072a6de7b", "f39f79b131e230ba3eed0a7a41df0373", "5bf90426743f6f87f273d308fa0dd13e", "4b3dba4d17d2f3796ba20a53383f1859", "1b6cd6556360cd64a05afb934074e013", "bd2cedbcd6fcd588512961c74fe8ed70" };

        private string[] stocks = new string[]
        {
            "AAPL,TSLA,MSFT,BA,BAC,AMD,LK,CCL,AAL,FB,GE,F,DIS,ZM,NVDA,AMZN,T,XOM,DAL,UBER,GILD,OXY,SQ,BABA,MU",
            "NFLX,TWTR,UCO,JPM,C,RCL,SNAP,INTC,MGM,UAL,WFC,AMRN,ROKU,TLRY,WMT,X,LYFT,FCX,SBUX,SPCE,M,TEVA,GM,PBR,CSCO",
            "IQ,WYNN,CVX,HAL,VZ,APA,SDC,PFE,V,JD,COST,NCLH,JNJ,BYND,KO,SLB,GOOGL,WORK,XLK,BP,BMY,GSX,CAT,MRO,TAL",
            "PTON,GOLD,QCOM,TGT,CMCSA,MAR,SHOP,BIDU,EWJ,HD,ACB,VALE,PYPL,MA,MS,INO,MCD,BBBY,PINS,VIAC,GME,IBM,CVS,DVN,DOCU",
            "KHC,MRNA,PENN,ABT,BRK/B,KSS,NKE,NLY,GS,FCAU,CRM,LB,PDD,NRZ,EXPE,LUV,W,GOOG,CHWY,HEXO,PCG,ADBE,AVGO,MRVL,COP",
            "GRUB,LYV,LVS,MMM,APT,MRK,UNH,SGMS,AMC,IMMU,AXP,CGC,ABBV,FDX,SE,WBA,MO,HSBC,NEM,HPQ,SAN,PG,ATVI,KOD,FIT"
        };


        //To add stocks to our database

        /// <summary>
        /// Get current stock prices from public API
        /// </summary>
        /// <returns></returns>
        public List<StockModel> GetCurrentStockPrices()
        {
            // Create a new array to store randomized apiKeys and copy the apiKeys array into the new array
            string[] randomApiKeys = new string[apiKeys.Length];

            Array.ConstrainedCopy(apiKeys, 0, randomApiKeys, 0, apiKeys.Length);

            // Randomize the order of the api keys so we hopefully never max any of them out
            Random rng = new Random();
            int n = randomApiKeys.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string temp = randomApiKeys[n];
                randomApiKeys[n] = randomApiKeys[k];
                randomApiKeys[k] = temp;
            }

            // List to hold API Models
            List<StockAPIModel> externalResults = new List<StockAPIModel>();

            int currentStockIndex = 0;
            int currentApiKeyIndex = 0;
            WebClient client = new WebClient();

            for (; currentApiKeyIndex < randomApiKeys.Length; currentApiKeyIndex++)
            {
                string apiRequest = $"https://marketdata.websol.barchart.com/getQuote.json?apikey={randomApiKeys[currentApiKeyIndex]}&symbols=";

                try
                {
                    for (; currentStockIndex < stocks.Length; currentStockIndex++)
                    {
                        //Get the stock details from the API and store in the StockAPIModel
                        string response = client.DownloadString(apiRequest + stocks[currentStockIndex]);
                        externalResults.Add(JsonConvert.DeserializeObject<StockAPIModel>(response));
                    }
                    break;
                }
                catch
                {
                    continue;
                }
            }

            List<StockModel> models = new List<StockModel>();

            foreach (StockAPIModel externalResult in externalResults)
            {
                Result[] results = null;

                if (externalResult.results != null && externalResult.results.Length != 0)
                {
                    results = externalResult.results;
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
                        StockModel stock = new StockModel()
                        {
                            Symbol = result.symbol,
                            High = result.high,
                            Low = result.low,
                            Name = result.name,
                            Open = result.open,
                            Close = result.close,
                            PercentChange = result.percentChange,
                            ServerTimestamp = result.serverTimestamp,
                            Volume = result.volume,
                            LastPrice = result.lastPrice
                        };

                        models.Add(stock);
                    }
                }
            }
            return models;
        }

    }
}
