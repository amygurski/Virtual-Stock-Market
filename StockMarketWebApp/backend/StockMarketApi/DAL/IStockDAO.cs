using StockMarketApi.Models.ApiReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public interface IStockDAO
    {
        IList<CurrentStocksModel> GetCurrentStocks();

        CurrentStocksModel GetStockBySymbol(string symbol);
    }
}
