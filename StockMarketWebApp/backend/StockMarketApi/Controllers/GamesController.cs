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
            IList<GameAPIModel> formattedGames = new List<GameAPIModel>();

            foreach (Game game in unformattedCurrentGames)
            {
                GameAPIModel gameFormatted = new GameAPIModel();
                gameFormatted.GameId = game.Id;
                gameFormatted.DateCreated = game.DateCreated.ToString("d");
                gameFormatted.EndDate = game.EndDate.ToString("g");
                gameFormatted.Name = game.Name;
                gameFormatted.Description = game.Description;
                gameFormatted.CreatorUsername = userDao.GetUser(game.CreatorId).Username;

                formattedGames.Add(gameFormatted);
            }

            return new JsonResult(formattedGames);
        }

        [HttpGet("mygames/{username}")]
        public IActionResult MyGames(string userName)
        {
            // TODO: Refactor with SQL Join Statement
            int userId = userDao.GetUser(userName).Id;
            IList<Game> unformattedCurrentGames = gameDao.GetMyGames(userId);
            IList<GameAPIModel> formattedGames = new List<GameAPIModel>();

            foreach (Game game in unformattedCurrentGames)
            {
                GameAPIModel gameFormatted = new GameAPIModel();
                gameFormatted.GameId = game.Id;
                gameFormatted.DateCreated = game.DateCreated.ToString("d");
                gameFormatted.EndDate = game.EndDate.ToString("g");
                gameFormatted.Name = game.Name;
                gameFormatted.Description = game.Description;
                gameFormatted.CreatorUsername = userDao.GetUser(game.CreatorId).Username;

                formattedGames.Add(gameFormatted);
            }

            return new JsonResult(formattedGames);
        }

        [HttpGet("{id}", Name = "GetGame")]
        [ProducesResponseType(404)]
        public IActionResult GetGame(int id)
        {
            Game game = gameDao.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            return new JsonResult(game);
        }

        [HttpPost("newgame")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateNewGame([FromBody]Game game)
        {
            if (ModelState.IsValid)
            {
                int newId = gameDao.CreateGame(game);
                game = gameDao.GetGameById(newId);
                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetGame", new { id = newId }, game);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}
