using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarketApi.DAL;
using StockMarketApi.HelperMethods;



namespace StockMarketApi.ScheduledJobs
{
    public class GameEnd
    {
        private IUserDAO userDao;
        private IGameDAO gameDao;

        public GameEnd(IUserDAO userDao, IGameDAO gameDao)
        {
            this.userDao = userDao;
            this.gameDao = gameDao;
        }
        public void SellOffStocks()
        {
   

            //get all games that need to be processed
            IList<GameModel> expiredgames = gameDao.GetAllExpiredGames();
            foreach (GameModel game in expiredgames)
            {
                //find all the users within the games
                UserModel user = userDao.GetUser(game.CreatorId);

                //get all the stocks these users own


                //use transactionDAO to sell all of these stocks
                //transactionDao.AddNewTransaction();

            }
        }
    }
}

