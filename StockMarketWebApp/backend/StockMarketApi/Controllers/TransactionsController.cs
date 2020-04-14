using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models.ApiInputModels.StockTransactions;
using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;
using StockMarketApi.ScheduledJobs;

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IGameDAO gameDao;
        private readonly IUserDAO userDao;
        private readonly ITransactionDAO transactionDao;
        private readonly IStockDAO stockDao;
        private readonly IGameEnd gameEnd;

        public TransactionsController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactDao, IStockDAO stockDao, IGameEnd gameEnd)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactionDao = transactDao;
            this.stockDao = stockDao;
            this.gameEnd = gameEnd;
        }

        [HttpPost("GetByGameAndUser")]
        public IActionResult AllTransactionsForUserAndGame([FromBody]UserAndGameAPIModel apiModel)
        {

            IList<StockTransaction> transactions = transactionDao.GetTransactionsByGameAndUser(apiModel.GameId, userDao.GetUser(apiModel.Username).Id);

            return new JsonResult(transactions);
        }

        [HttpPost("newtransaction")]
        public IActionResult PostNewTransaction([FromBody]NewTransactionAPIModel apiModel)
        {
            if (ModelState.IsValid)
            {
                TransactionModel newTransaction = new TransactionModel();
                newTransaction.UserId = userDao.GetUser(apiModel.UserName).Id;
                newTransaction.GameId = apiModel.GameId;
                newTransaction.StockSymbol = apiModel.StockSymbol;
                newTransaction.NumberOfShares = apiModel.NumberOfShares;
                newTransaction.TransactionSharePrice = stockDao.GetStockBySymbol(apiModel.StockSymbol).CurrentPrice;
                newTransaction.IsPurchase = apiModel.IsPurchase;
                
                if (newTransaction.IsPurchase)
                {
                    newTransaction.NetTransactionChange = -(newTransaction.NumberOfShares * newTransaction.TransactionSharePrice);
                }
                else
                {
                    newTransaction.NetTransactionChange = newTransaction.NumberOfShares * newTransaction.TransactionSharePrice;
                }

                int newId = transactionDao.AddNewTransaction(newTransaction);
                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetGame", new { id = newId }, newTransaction);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        [HttpGet("TestEndGameProcedure")]
        public IActionResult CloseTransactions()
        {
            gameEnd.SellOffStocks();

            return new JsonResult(1);
        }
    }
}