using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApi.DAL;
using StockMarketApi.HelperMethods;
using StockMarketApi.Models.ApiReturnModels;
using Hangfire;

namespace StockMarketApi.BackgroundJobs
{
    public class ScheduledJobs : IScheduledJobs
    {
        private IUserDAO userDao;
        private IGameDAO gameDao;
        private ITransactionDAO transactionDao;
        private IOwnedStocksHelper ownedHelper;

        public ScheduledJobs(IUserDAO userDao, IGameDAO gameDao, ITransactionDAO transactionDao, IOwnedStocksHelper ownedHelper)

        {
            this.userDao = userDao;
            this.gameDao = gameDao;
            this.transactionDao = transactionDao;
            this.ownedHelper = ownedHelper;
        }

        public void ProcessGameEnd()
        {
            BackgroundJob.Enqueue(() => SellOffStocks());
        }

        public void SellOffStocks()
        {
            //get all games that need to be processed
            IList<GameModel> expiredGames = gameDao.GetAllExpiredGames();
            foreach (GameModel game in expiredGames)
            {

                //find all the users within the game
                IList<UserModel> users = userDao.GetUsersByGame(game.Id);

                foreach (UserModel user in users)
                {
                    //get all the stocks the user owns in a particular game
                    IList<OwnedStocksModel> expiredStocks = ownedHelper.GetOwnedStocksByUserAndGame(user.Id, game.Id);

                    foreach (OwnedStocksModel stock in expiredStocks)
                    {
                        TransactionModel finalTransaction = new TransactionModel()
                        {
                            UserId = user.Id,
                            GameId = game.Id,
                            StockSymbol = stock.StockSymbol,
                            NumberOfShares = stock.NumberOfShares,
                            TransactionSharePrice = stock.CurrentSharePrice,
                            IsPurchase = false,
                            NetTransactionChange = stock.NumberOfShares * stock.CurrentSharePrice

                        };
                        //use transactionDAO to sell all of these stocks

                        transactionDao.AddNewTransaction(finalTransaction);

                        //sell all the stocks a user has

                    }
                }
                gameDao.UpdateTransactionsEndGame(game.Id);
            }
        }
    }
}

