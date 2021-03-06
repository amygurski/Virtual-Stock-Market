﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.DAL;
using StockMarketApi.HelperMethods;
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
        private readonly IGameDAO gameDao;
        private readonly IUserDAO userDao;
        private readonly ITransactionDAO transactionDao;
        private readonly IOwnedStocksHelper ownedHelper;
        private readonly IStockHistoryAPIDAO stockHistoryAPIDao;

        public GamesController(IGameDAO gameDao, IUserDAO userDao, ITransactionDAO transactionDao, IOwnedStocksHelper ownedHelper, IStockHistoryAPIDAO stockHistoryAPIDao)
        {
            this.gameDao = gameDao;
            this.userDao = userDao;
            this.transactionDao = transactionDao;
            this.ownedHelper = ownedHelper;
            this.stockHistoryAPIDao = stockHistoryAPIDao;
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

        // TODO: THROWAWAY
        [HttpGet("expiredgames")]
        public IActionResult AllExpiredGames()
        {
            // TODO: Refactor with SQL Join Statement
            IList<GameModel> unformattedCurrentGames = gameDao.GetAllExpiredGames();
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

                gameDao.JoinGame(userId, newId);

                AddInitialTransaction(userId, newId);

                //TransactionModel transactionModel = new TransactionModel()
                //{
                //    UserId = userId,
                //    GameId = newId,
                //    StockSymbol = "SYSTRN",
                //    NumberOfShares = 1,
                //    TransactionSharePrice = 100000,
                //    IsPurchase = false,
                //    NetTransactionChange = 100000           
                //};

                //transactionDao.AddNewTransaction(transactionModel);

                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetGame", new { id = newId }, newGame);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        [HttpPost("joingame")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult JoinExistingGame([FromBody]JoinGameApiModel apiModel)
        {
            if (ModelState.IsValid)
            {
                int userId = userDao.GetUser(apiModel.UserName).Id;

                IList<UserModel> currentPlayers = userDao.GetUsersByGame(apiModel.GameId);

                bool found = false;
                foreach (UserModel players in currentPlayers)
                {
                    if (userId == players.Id)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    gameDao.JoinGame(userId, apiModel.GameId);
                }
                else
                {
                    return new BadRequestObjectResult(ModelState);
                }



                GameModel newGame = gameDao.GetGameById(apiModel.GameId);

                TransactionModel transactionModel = new TransactionModel()
                {
                    UserId = userId,
                    GameId = apiModel.GameId,
                    StockSymbol = "SYSTRN",
                    NumberOfShares = 1,
                    TransactionSharePrice = 100000,
                    IsPurchase = false,
                    NetTransactionChange = 100000
                };

                transactionDao.AddNewTransaction(transactionModel);

                // TODO 09a (Controller): Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetGame", new { id = newGame.Id }, newGame);
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
            gameFormatted.NextDataUpdate = DateTime.Now.AddMinutes(15);
            gameFormatted.LeaderboardData = BuildLeaderBoardData(game.Id);
            gameFormatted.IsCompleted = game.IsCompleted;

            return gameFormatted;
        }

        private void AddInitialTransaction(int userId, int gameId)
        {
            TransactionModel transactionModel = new TransactionModel()
            {
                UserId = userId,
                GameId = gameId,
                StockSymbol = "SYSTRN",
                NumberOfShares = 1,
                TransactionSharePrice = 100000,
                IsPurchase = false,
                NetTransactionChange = 100000
            };

            transactionDao.AddNewTransaction(transactionModel);
        }

        private IList<LeaderboardBalance> BuildLeaderBoardData(int gameId)
        {
            //IList<StockTransaction> allTransactions = transactionDao.GetAllTransactionsByGame(gameId);

            //IDictionary<int, decimal> summedTransactions = new Dictionary<int, decimal>();

            //IList<LeaderboardBalance> result = new List<LeaderboardBalance>();

            //foreach (StockTransaction transaction in allTransactions)
            //{
            //    if (!summedTransactions.ContainsKey(transaction.UserId))
            //    {
            //        summedTransactions.Add(transaction.UserId, 0M);
            //        summedTransactions[transaction.UserId] += transaction.NetValue;
            //    }
            //    else
            //    {
            //        summedTransactions[transaction.UserId] += transaction.NetValue;
            //    }
            //}

            //foreach (KeyValuePair<int, decimal> kvp in summedTransactions)
            //{
            //    LeaderboardBalance newBalance = new LeaderboardBalance()
            //    {
            //        UserName = userDao.GetUser(kvp.Key).Username,
            //        CurrentBalance = kvp.Value
            //    };
            //    result.Add(newBalance);
            //}


            IList<UserModel> users = userDao.GetUsersByGame(gameId);

            IDictionary<UserModel, IList<StockTransaction>> userTransactions = new Dictionary<UserModel, IList<StockTransaction>>();

            foreach (UserModel user in users)
            {
                userTransactions.Add(user, transactionDao.GetTransactionsByGameAndUser(gameId, user.Id));
            }

            //IDictionary<string, decimal> cachedStockPrices = new Dictionary<string, decimal>();

            List<LeaderboardBalance> result = new List<LeaderboardBalance>();


            foreach (KeyValuePair<UserModel, IList<StockTransaction>> kvp in userTransactions)
            {
                LeaderboardBalance balance = new LeaderboardBalance();
                balance.UserId = kvp.Key.Id;
                balance.UserName = kvp.Key.Username;

                decimal runningBalance = 0.0M;

                foreach (StockTransaction transaction in kvp.Value)
                {
                    runningBalance += transaction.NetValue;
                }

                balance.CurrentBalance = runningBalance;

                IList<OwnedStocksModel> ownedStocks = ownedHelper.GetOwnedStocksByUserAndGame(kvp.Key.Id, gameId);

                decimal runningStockValue = 0.0M;

                foreach (OwnedStocksModel ownedstock in ownedStocks)
                {
                    runningStockValue += ownedstock.CurrentSharePrice * ownedstock.NumberOfShares;
                }

                balance.CurrentStockValue = runningStockValue;
                balance.CurrentTotalPortfolioValue = balance.CurrentStockValue + balance.CurrentBalance;

                result.Add(balance);
            }

            result.Sort((a, b) => b.CurrentTotalPortfolioValue.CompareTo(a.CurrentTotalPortfolioValue));

            return result;
        }
    }
}
