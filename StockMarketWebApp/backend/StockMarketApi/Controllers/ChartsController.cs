using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models.ApiInputModels.Games;

namespace StockMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChartsController : ControllerBase
    {
        private readonly IUserDAO userDao;

        public ChartsController(IUserDAO userDao)
        {
            this.userDao = userDao;
        }

        //[HttpPost("register")]
        //public IActionResult GetGameCharts([FromBody]GameChartsApiInputModel inputModel)
        //{
        //    int userId = userDao.GetUser(inputModel.UserName).Id;


        //    return new JsonResult()
        //}
    }
}