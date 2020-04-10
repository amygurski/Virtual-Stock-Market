using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models;

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
            IList<CurrentStock> currentStocks = stockDao.GetCurrentStocks();

            return new JsonResult(currentStocks);
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