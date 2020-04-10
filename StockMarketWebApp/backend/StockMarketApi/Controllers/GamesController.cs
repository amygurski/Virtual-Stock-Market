using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.Models.ApiInputModels.Games;
using StockMarketApi.Models.ApiReturnModels;
using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;

namespace StockMarketApi.Controllers
{
    /// <summary>
    /// Controller for Game Objects
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private IGameDAO gameDao;
        private IUserDAO userDao;
        private readonly ITransactionDAO transactionDao;

        public GamesController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactionDao)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactionDao = transactionDao;
        }

        /// <summary>
        /// Returns all Currently active games
        /// </summary>
        /// <returns></returns>
        [HttpGet("currentgames")]
        public IActionResult AllActiveGames()
        {
            // TODO: Refactor with SQL Join Statement
            IList<GameModel> unformattedCurrentGames = gameDao.GetAllActiveGames();
            IList<GameAPIModel> formattedGames = new List<GameAPIModel>();

            foreach (GameModel game in unformattedCurrentGames)
            {
                GameAPIModel gameFormatted = FormatGameToApiModel(game);
                formattedGames.Add(gameFormatted);
            }


            return new JsonResult(formattedGames);
        }

        [HttpGet("mygames/{username}")]
        public IActionResult MyGames(string userName)
        {
            // TODO: Refactor with SQL Join Statement
            int userId = userDao.GetUser(userName).Id;
            IList<GameModel> unformattedCurrentGames = gameDao.GetMyGames(userId);
            IList<GameAPIModel> formattedGames = new List<GameAPIModel>();

            foreach (GameModel game in unformattedCurrentGames)
            {
                GameAPIModel gameFormatted = FormatGameToApiModel(game);
                formattedGames.Add(gameFormatted);
            }

            return new JsonResult(formattedGames);
        }

        [HttpGet("{id}", Name = "GetGame")]
        [ProducesResponseType(404)]
        public IActionResult GetGame(int id)
        {
            GameModel gameUnformatted = gameDao.GetGameById(id);
            GameAPIModel gameFormatted = new GameAPIModel();

            if (gameUnformatted == null)
            {
                return NotFound();
            }
            else
            {
                gameFormatted = FormatGameToApiModel(gameUnformatted);
            }

            return new JsonResult(gameFormatted);
        }

        [HttpPost("newgame")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateNewGame([FromBody]CreateGameAPIModel apiModel)
        {
            if (ModelState.IsValid)
            {
                GameModel newGame = new GameModel();
                int userId = userDao.GetUser(apiModel.UserName).Id;

                newGame.CreatorId = userId;
                newGame.Name = apiModel.Name;
                newGame.Description = apiModel.Description;
                newGame.DateCreated = DateTime.Parse(apiModel.StartDate);
                newGame.EndDate = DateTime.Parse(apiModel.EndDate);
                
                int newId = gameDao.CreateGame(newGame);
                newGame = gameDao.GetGameById(newId);

                TransactionModel transactionModel = new TransactionModel()
                {
                    UserId = userId,
                    GameId = newId,
                    StockSymbol = "SYSTRN",
                    NumberOfShares = 1,
                    TransactionSharePrice = 100000,
                    IsPurchase = false,
                    NetTransactionChange = 100000           
                };

                transactionDao.AddNewTransaction(transactionModel);

                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetGame", new { id = newId }, newGame);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        private GameAPIModel FormatGameToApiModel(GameModel game)
        {
            GameAPIModel gameFormatted = new GameAPIModel();
            gameFormatted.GameId = game.Id;
            gameFormatted.DateCreated = game.DateCreated.ToString("d");
            gameFormatted.EndDate = game.EndDate.ToString("g");
            gameFormatted.Name = game.Name;
            gameFormatted.Description = game.Description;
            gameFormatted.CreatorUsername = userDao.GetUser(game.CreatorId).Username;
            gameFormatted.CreatorId = game.CreatorId;

            return gameFormatted;
        }
    }
}
