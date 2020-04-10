namespace StockMarketApi.Models.ApiReturnModels
{
    public class CurrentStocksModel
    {
        public string StockSymbol { get; set; }

        public string CompanyName { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PercentChange { get; set; }
    }
}
