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
        //To add stocks to our database

        /// <summary>
        /// Get current stock prices from public API
        /// </summary>
        /// <returns></returns>
        public List<StockModel> GetCurrentStockPrices()
        {
            //Stocks to return
            List<StockModel> allStocks = new List<StockModel>();

            //List of all the stocks we can play with
            List<string> stocksToGet = new List<string>
            {
                "AAPL,TSLA,MSFT,BA,BAC,AMD,LK,CCL,AAL,FB,GE,F,DIS,ZM,NVDA,AMZN,T,XOM,DAL,UBER,GILD,OXY,SQ,BABA,MU",
                "NFLX,TWTR,UCO,JPM,C,RCL,SNAP,INTC,MGM,UAL,WFC,AMRN,ROKU,TLRY,WMT,X,LYFT,FCX,SBUX,SPCE,M,TEVA,GM,PBR,CSCO",
                "IQ,WYNN,CVX,HAL,VZ,APA,SDC,PFE,V,JD,COST,NCLH,JNJ,BYND,KO,SLB,GOOGL,WORK,XLK,BP,BMY,GSX,CAT,MRO,TAL",
                "PTON,GOLD,QCOM,TGT,CMCSA,MAR,SHOP,BIDU,EWJ,HD,ACB,VALE,PYPL,MA,MS,INO,MCD,BBBY,PINS,VIAC,GME,IBM,CVS,DVN,DOCU",
                "KHC,MRNA,PENN,ABT,BRK/B,KSS,NKE,NLY,GS,FCAU,CRM,LB,PDD,NRZ,EXPE,LUV,W,GOOG,CHWY,HEXO,PCG,ADBE,AVGO,MRVL,COP",
                "GRUB,LYV,LVS,MMM,APT,MRK,UNH,SGMS,AMC,IMMU,AXP,CGC,ABBV,FDX,SE,WBA,MO,HSBC,NEM,HPQ,SAN,PG,ATVI,KOD,FIT"
            };

            //Need to make 6 separate calls for the 150 stocks because of API limitations
            foreach (string stockSet in stocksToGet)
            {
                //Get the stock details from the API and store in the StockAPIModel
                WebClient client = new WebClient();
                string response = client.DownloadString("https://marketdata.websol.barchart.com/getQuote.json?apikey=bd2cedbcd6fcd588512961c74fe8ed70&symbols=" + stockSet);
                StockAPIModel publicStockInfo = JsonConvert.DeserializeObject<StockAPIModel>(response);

                foreach (Result result in publicStockInfo.results)
                {
                    //Add the stock details required for stock to our stock model
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

                    //Add the stock to the list of stocks to be returned
                    allStocks.Add(stock);
                }
            }

            return allStocks;
        }

    }
}
