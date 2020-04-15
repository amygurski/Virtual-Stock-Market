using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;
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

        IList<StockHistoryModel> GetAllStocksHistory();

        IList<ResearchStocksAPIModel> GetStocksResearch();

        void SaveStock(StockModel stock);

        void UpdateStock(StockModel stock);

        void AddHistoryEntry(StockHistoryModel historyModel);

        bool CheckForDuplicateHistoryEntry(DateTime date, string symbol);
    }
}
