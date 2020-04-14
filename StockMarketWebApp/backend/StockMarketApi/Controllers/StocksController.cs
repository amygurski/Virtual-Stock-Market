using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.HelperMethods;
using StockMarketApi.Models.ApiInputModels.StockTransactions;
using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        
        private readonly IUserDAO userDao;
        private readonly IStockDAO stockDao;
        private readonly IOwnedStocksHelper ownedHelper;

        // TODO: Not Currently used by this controller refactor depending on future usage
        private readonly IGameDAO gameDao;
        private readonly ITransactionDAO transactDao;
        private readonly IStockAPIDAO stockAPIDao;

        public StocksController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactDao, IStockAPIDAO stockAPIDao, IStockDAO stockDao, IOwnedStocksHelper ownedHelper)
        {
            
            this.userDao = userDao;
            this.stockDao = stockDao;
            this.ownedHelper = ownedHelper;

            // TODO: Determine if these properties are needed with later refactoring
            this.gameDao = gameDao;
            this.transactDao = transactDao;
            this.stockAPIDao = stockAPIDao;
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
            IList<OwnedStocksModel> ownedStocks = ownedHelper.GetOwnedStocksByUserAndGame(userDao.GetUser(apiModel.Username).Id, apiModel.GameId);

            return new JsonResult(ownedStocks);
        }

            // Original code for ownedStocks has been moved to a helper method preserving this in case of issues


            //IList<StockTransaction> transactions = transactDao.GetTransactionsByGameAndUser(apiModel.GameId, userDao.GetUser(apiModel.Username).Id);

            //Dictionary<string, List<StockTransaction>> transactionDict = new Dictionary<string, List<StockTransaction>>();

            //foreach (StockTransaction transaction in transactions)
            //{
            //    if (!transactionDict.ContainsKey(transaction.StockSymbol))
            //    {
            //        transactionDict.Add(transaction.StockSymbol, new List<StockTransaction>());
            //        transactionDict[transaction.StockSymbol].Add(transaction);
            //    }
            //    else
            //    {
            //        transactionDict[transaction.StockSymbol].Add(transaction);
            //    }
            //}

            //IList<OwnedStocksModel> ownedStocks = new List<OwnedStocksModel>();

            //foreach (KeyValuePair<string, List<StockTransaction>> kvp in transactionDict) {
            //    if (kvp.Value.Count > 0)
            //    {
            //        OwnedStocksModel ownedStock = new OwnedStocksModel();
            //        ownedStock.StockSymbol = kvp.Value[0].StockSymbol;
            //        ownedStock.CompanyName = kvp.Value[0].CompanyName;
            //        ownedStock.CurrentSharePrice = stockDao.GetStockBySymbol(kvp.Key).CurrentPrice;

            //        int numShares = 0;
            //        decimal netTotalPriceBought = 0.0M;
            //        int netNumSharesBought = 0;

            //        foreach (StockTransaction transaction in kvp.Value)
            //        {
            //            if (transaction.IsPurchase)
            //            {
            //                numShares += transaction.NumberOfShares;
            //                netNumSharesBought += transaction.NumberOfShares;
            //                netTotalPriceBought -= transaction.NetValue;
            //            }
            //            else
            //            {
            //                numShares -= transaction.NumberOfShares;
            //            }
            //        }
            //        ownedStock.NumberOfShares = numShares;

            //        if (netNumSharesBought != 0)
            //        {
            //            ownedStock.AvgPurchasedPrice = netTotalPriceBought / netNumSharesBought;
            //        }


            //        if (ownedStock.NumberOfShares > 0)
            //        {
            //            ownedStocks.Add(ownedStock);
            //        }

            //    }
            //}


        



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