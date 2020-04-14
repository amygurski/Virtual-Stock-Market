using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApi.DAL;
using StockMarketApi.HelperMethods;
using StockMarketApi.Models.ApiReturnModels;

namespace StockMarketApi.ScheduledJobs
{
    public class GameEnd
    {
        private IUserDAO userDao;
        private IGameDAO gameDao;
        private ITransactionDAO transactionDao;
        private IOwnedStocksHelper ownedHelper;

        public GameEnd(IUserDAO userDao, IGameDAO gameDao, ITransactionDAO transactionDao, IOwnedStocksHelper ownedHelper)

        {
            this.userDao = userDao;
            this.gameDao = gameDao;
            this.transactionDao = transactionDao;
            this.ownedHelper = ownedHelper;

        }

    public void SellOffStocks()
        {
            //get all games that need to be processed
            IList<GameModel> expiredGames = gameDao.GetAllExpiredGames();
            foreach (GameModel game in expiredGames)
            {
                //find all the users within the game
                UserModel user = userDao.GetUser(game.Id);

                //get all the stocks these users own
                IList<OwnedStocksModel> expiredStocks = ownedHelper.GetOwnedStocksByUserAndGame(user.Id, game.Id);

                //use transactionDAO to sell all of these stocks
               foreach(OwnedStocksModel stock in expiredStocks)
                {
                    transactionDao.AddNewTransaction();
                }

                //sell all the stocks a user has
                

            }
        }
    }
}

