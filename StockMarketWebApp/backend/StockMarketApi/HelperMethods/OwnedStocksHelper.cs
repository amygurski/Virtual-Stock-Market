using StockMarketApi.DAL;
using StockMarketApi.Models.ApiReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.HelperMethods
{
    public class OwnedStocksHelper : IOwnedStocksHelper
    {
        private readonly ITransactionDAO transactDao;
        private readonly IStockDAO stockDao;

        public OwnedStocksHelper(ITransactionDAO transactDao, IStockDAO stockDao)
        {
            this.transactDao = transactDao;
            this.stockDao = stockDao;
        }

        public IList<OwnedStocksModel> GetOwnedStocksByUserAndGame(int userId, int gameId)
        {
            IList<StockTransaction> transactions = transactDao.GetTransactionsByGameAndUser(gameId, userId);

            Dictionary<string, List<StockTransaction>> transactionDict = new Dictionary<string, List<StockTransaction>>();

            foreach (StockTransaction transaction in transactions)
            {
                if (!transactionDict.ContainsKey(transaction.StockSymbol))
                {
                    transactionDict.Add(transaction.StockSymbol, new List<StockTransaction>());
                    transactionDict[transaction.StockSymbol].Add(transaction);
                }
                else
                {
                    transactionDict[transaction.StockSymbol].Add(transaction);
                }
            }

            IList<OwnedStocksModel> ownedStocks = new List<OwnedStocksModel>();

            foreach (KeyValuePair<string, List<StockTransaction>> kvp in transactionDict)
            {
                if (kvp.Value.Count > 0)
                {
                    OwnedStocksModel ownedStock = new OwnedStocksModel();
                    ownedStock.StockSymbol = kvp.Value[0].StockSymbol;
                    ownedStock.CompanyName = kvp.Value[0].CompanyName;
                    ownedStock.CurrentSharePrice = stockDao.GetStockBySymbol(kvp.Key).CurrentPrice;
                    ownedStock.PercentChange = stockDao.GetStockBySymbol(kvp.Key).PercentChange;

                    int numShares = 0;
                    decimal netTotalPriceBought = 0.0M;
                    int netNumSharesBought = 0;

                    foreach (StockTransaction transaction in kvp.Value)
                    {
                        if (transaction.IsPurchase)
                        {
                            numShares += transaction.NumberOfShares;
                            netNumSharesBought += transaction.NumberOfShares;
                            netTotalPriceBought -= transaction.NetValue;
                        }
                        else
                        {
                            numShares -= transaction.NumberOfShares;
                        }
                    }
                    ownedStock.NumberOfShares = numShares;

                    if (netNumSharesBought != 0)
                    {
                        ownedStock.AvgPurchasedPrice = netTotalPriceBought / netNumSharesBought;
                    }


                    if (ownedStock.NumberOfShares > 0)
                    {
                        ownedStocks.Add(ownedStock);
                    }

                }
            }

            return ownedStocks;
        }
    }
}
