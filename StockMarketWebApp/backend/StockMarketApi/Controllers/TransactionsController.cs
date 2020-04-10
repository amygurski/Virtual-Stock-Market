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

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private IGameDAO gameDao;
        private IUserDAO userDao;
        private ITransactionDAO transactDao;

        public TransactionsController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactDao)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactDao = transactDao;
        }

        [HttpPost("GetByGameAndUser")]
        public IActionResult AllTransactionsForUserAndGame([FromBody]UserAndGameAPIModel apiModel)
        {

            IList<StockTransaction> transactions = transactDao.GetTransactionsByGameAndUser(apiModel.GameId, userDao.GetUser(apiModel.Username).Id);

            return new JsonResult(transactions);
        }
    }
}