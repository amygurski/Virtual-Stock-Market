using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public interface IStockHistoryAPIDAO
    {
        IList<StockHistoryModel> GetLastCloseStockHistory();
    }
}
