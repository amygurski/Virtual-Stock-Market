using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    public interface ITransactionDAO
    {
        IList<StockTransaction> GetTransactionsByGameAndUser(int gameId, int userId);

        int AddNewTransaction(TransactionModel model);
    }
}
