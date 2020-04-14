using System;
using System.IO;
using System.Net;

namespace StockHistoryCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stocks = new string[] { "AAPL","TSLA","MSFT","BA","BAC","AMD","LK","CCL","AAL","FB","GE","F","DIS","ZM","NVDA","AMZN","T","XOM","DAL","UBER","GILD","OXY","SQ","BABA","MU","NFLX","TWTR","UCO","JPM","C","RCL","SNAP","INTC","MGM","UAL","WFC","AMRN","ROKU","TLRY","WMT","X","LYFT","FCX","SBUX","SPCE","M","TEVA","GM","PBR","CSCO","IQ","WYNN","CVX","HAL","VZ","APA","SDC","PFE","V","JD","COST","NCLH","JNJ","BYND","KO","SLB","GOOGL","WORK","XLK","BP","BMY","GSX","CAT","MRO","TAL","PTON","GOLD","QCOM","TGT","CMCSA","MAR","SHOP","BIDU","EWJ","HD","ACB","VALE","PYPL","MA","MS","INO","MCD","BBBY","PINS","VIAC","GME","IBM","CVS","DVN","DOCU","KHC","MRNA","PENN","ABT","BRK / B","KSS","NKE","NLY","GS","FCAU","CRM","LB","PDD","NRZ","EXPE","LUV","W","GOOG","CHWY","HEXO","PCG","ADBE","AVGO","MRVL","COP","GRUB","LYV","LVS","MMM","APT","MRK","UNH","SGMS","AMC","IMMU","AXP","CGC","ABBV","FDX","SE","WBA","MO","HSBC","NEM","HPQ","SAN","PG","ATVI","KOD","FIT"};

            //Subtract 6 months
            DateTime sixMonthsAgo = DateTime.Today.AddMonths(-6);

            //Get in correct format for API
            //string startDate = sixMonthsAgo.ToString("yyyyMMdd");

            string startDate = "20200409";
            //This request will get the past 6 months of data from today
            string apiRequest = $"https://marketdata.websol.barchart.com/getHistory.csv?apikey=f32669fc5614fbd62719ba6543de5576&type=dailyContinue&startDate={startDate}&symbol=";
            //to just get closed day:
            //string apiRequest = $"https://marketdata.websol.barchart.com/getHistory.csv?apikey=f32669fc5614fbd62719ba6543de5576&type=daily&symbol=";

            WebClient client2 = new WebClient();
            string result = client2.DownloadString("https://marketdata.websol.barchart.com/getHistory.csv?apikey=31a2d95da1cf2b19dbabb725d7ff9136&type=dailyContinue&startDate=20200409&symbol=AAL");

            foreach (string stock in stocks)
            {
                WebClient client = new WebClient();

                //Make API request for stock market history for each of the stocks
                string response = client.DownloadString(apiRequest + stock);

                //note set to append
                using (StreamWriter sw = new StreamWriter("newhistoricstockdata.csv", true))
                {
                    sw.WriteLine(response);
                }
            }

        }
    }
}
