using StockMarketApi.Models.ApiReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.HelperMethods
{
    public interface IOwnedStocksHelper
    {
        IList<OwnedStocksModel> GetOwnedStocksByUserAndGame(int userId, int gameId);
    }
}
