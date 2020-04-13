using StockMarketApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.DAL
{
    /// <summary>
    /// An interface for game objects
    /// </summary>
    public interface IGameDAO
    {
        /// <summary>
        /// Returns all games
        /// </summary>
        /// <returns></returns>
        IList<GameModel> GetAllActiveGames();

        /// <summary>
        /// Adds a new game to the database
        /// </summary>
        /// <returns>an integer id representing the game primary key id</returns>
        int CreateGame(GameModel game);

        GameModel GetGameById(int id);

        IList<GameModel> GetMyGames(int userId);

        bool JoinGame(int userId, int gameId);
    }
}
