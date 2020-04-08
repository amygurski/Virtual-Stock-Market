using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models;
using StockMarketApi.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Controllers
{
    /// <summary>
    /// Controller for Game Objects
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameDAO gameDao;
        private IUserDAO userDao;

        public GamesController(IGameDAO gameDao, IUserDAO userDao)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
        }

        /// <summary>
        /// Returns all Currently active games
        /// </summary>
        /// <returns></returns>
        [HttpGet("currentgames")]
        public IActionResult AllActiveGames()
        {
            // TODO: Refactor with SQL Join Statement
            IList<Game> unformattedCurrentGames = gameDao.GetAllActiveGames();
            IList<CurrentGamesModel> formattedGames = new List<CurrentGamesModel>();

            foreach (Game game in unformattedCurrentGames)
            {
                CurrentGamesModel gameFormatted = new CurrentGamesModel();
                gameFormatted.GameId = game.GameId;
                gameFormatted.DateCreated = game.DateCreated;
                gameFormatted.EndDate = game.EndDate;
                gameFormatted.GameName = game.GameName;
                gameFormatted.CreatorUsername = userDao.GetUser(game.CreatorId).Username;

                formattedGames.Add(gameFormatted);
            }

            return new JsonResult(formattedGames);

        }
    }
}
