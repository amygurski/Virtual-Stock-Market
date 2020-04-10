using StockMarketApi.Models.ApiReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public interface ITransactionDAO
    {
        IList<StockTransaction> GetTransactionsByGameAndUser(int gameId, int userId);

        int AddNewTransaction();
    }
}
