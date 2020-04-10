using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models.ApiInputModels.StockTransactions;
using StockMarketApi.Models.ApiReturnModels;

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly IGameDAO gameDao;
        private readonly IUserDAO userDao;
        private readonly ITransactionDAO transactDao;
        private readonly IStockAPIDAO stockAPIDao;
        private readonly IStockDAO stockDao;

        public StocksController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactDao, IStockAPIDAO stockAPIDao, IStockDAO stockDao)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactDao = transactDao;
            this.stockAPIDao = stockAPIDao;
            this.stockDao = stockDao;
        }

        [HttpGet("currentprices")]
        public IActionResult GetCurrentStockPrices()
        {
            IList<CurrentStocksModel> currentStocks = stockDao.GetCurrentStocks();

            return new JsonResult(currentStocks);
        }

        [HttpGet("detail/{symbol}")]
        public IActionResult GetStockDetail(string symbol)
        {
            return new JsonResult(stockDao.GetStockBySymbol(symbol));
        }


        [HttpPost("owned")]
        public IActionResult GetOwnedStocks([FromBody]UserAndGameAPIModel apiModel)
        {
            IList<StockTransaction> transactions = transactDao.GetTransactionsByGameAndUser(apiModel.GameId, userDao.GetUser(apiModel.Username).Id);

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

            foreach (KeyValuePair<string, List<StockTransaction>> kvp in transactionDict) {
                if (kvp.Value.Count > 0)
                {
                    OwnedStocksModel ownedStock = new OwnedStocksModel();
                    ownedStock.StockSymbol = kvp.Value[0].StockSymbol;
                    ownedStock.CompanyName = kvp.Value[0].CompanyName;
                    ownedStock.CurrentSharePrice = stockDao.GetStockBySymbol(kvp.Key).CurrentPrice;

                    int numShares = 0;
                    decimal totalPrice = 0.0M;
                    foreach (StockTransaction transaction in kvp.Value)
                    {
                        if (transaction.IsPurchase)
                        {
                            numShares += transaction.NumberOfShares;
                            totalPrice -= transaction.NetValue;
                        }
                        else
                        {
                            numShares -= transaction.NumberOfShares;
                            totalPrice += transaction.NetValue;
                        }
                    }
                    ownedStock.NumberOfShares = numShares;
                    ownedStock.AvgPurchasedPrice = totalPrice / kvp.Value.Count;

                    if (ownedStock.NumberOfShares > 0)
                    {
                        ownedStocks.Add(ownedStock);
                    }

                }
            }

            return new JsonResult(ownedStocks);
        }



        //[HttpGet("initialize")]
        //public IActionResult InitializeStockDb()
        //{
        //    List<Stock> stocks = stockAPIDAO.GetCurrentStockPrices();

        //    if (stocks.Count > 0)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
    }
}