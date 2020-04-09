using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace StockMarketApi.DAL
{
    public class APIStockHistoryCreator
    {
        public void OutputStockHistory()
        {
            string[] stocks = new string[] { "AAPL", "TSLA", "MSFT", "BA", "BAC", "AMD", "LK", "CCL", "AAL", "FB", "GE", "F", "DIS", "ZM", "NVDA", "AMZN", "T", "XOM", "DAL", "UBER", "GILD", "OXY", "SQ", "BABA", "MU", "NFLX", "TWTR", "UCO", "JPM", "C", "RCL", "SNAP", "INTC", "MGM", "UAL", "WFC", "AMRN", "ROKU", "TLRY", "WMT", "X", "LYFT", "FCX", "SBUX", "SPCE", "M", "TEVA", "GM", "PBR", "CSCO", "IQ", "WYNN", "CVX", "HAL", "VZ", "APA", "SDC", "PFE", "V", "JD", "COST", "NCLH", "JNJ", "BYND", "KO", "SLB", "GOOGL", "WORK", "XLK", "BP", "BMY", "GSX", "CAT", "MRO", "TAL", "PTON", "GOLD", "QCOM", "TGT", "CMCSA", "MAR", "SHOP", "BIDU", "EWJ", "HD", "ACB", "VALE", "PYPL", "MA", "MS", "INO", "MCD", "BBBY", "PINS", "VIAC", "GME", "IBM", "CVS", "DVN", "DOCU", "KHC", "MRNA", "PENN", "ABT", "BRK / B", "KSS", "NKE", "NLY", "GS", "FCAU", "CRM", "LB", "PDD", "NRZ", "EXPE", "LUV", "W", "GOOG", "CHWY", "HEXO", "PCG", "ADBE", "AVGO", "MRVL", "COP", "GRUB", "LYV", "LVS", "MMM", "APT", "MRK", "UNH", "SGMS", "AMC", "IMMU", "AXP", "CGC", "ABBV", "FDX", "SE", "WBA", "MO", "HSBC", "NEM", "HPQ", "SAN", "PG", "ATVI", "KOD", "FIT" };

            foreach (string stock in stocks)
            {
                WebClient client = new WebClient();

                string response = client.DownloadString("https://marketdata.websol.barchart.com/getHistory.csv?apikey=af26319a23a6675378f3c947e95706a7&type=dailyContinue&startDate=20191009&symbol=" + stock);

                using (StreamWriter sw = new StreamWriter("historicstockdata.csv", true))
                {
                    sw.WriteLine(response);
                }
            }
        }
    }
}