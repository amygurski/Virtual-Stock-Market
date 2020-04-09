using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models;

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IGameDAO gameDao;
        private readonly IUserDAO userDao;
        private readonly ITransactionDAO transactDao;
        private readonly IStockAPIDAO stockAPIDAO;

        public StocksController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactDao, IStockAPIDAO stockAPIDAO)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactDao = transactDao;
            this.stockAPIDAO = stockAPIDAO;
        }


        [HttpGet("initialize")]
        public IActionResult InitializeStockDb()
        {
            List<Stock> stocks = stockAPIDAO.GetCurrentStockPrices();

            if (stocks.Count > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}