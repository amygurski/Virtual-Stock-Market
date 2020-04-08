using StockMarketApi.Models;
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
        IList<Game> GetAllActiveGames();

        /// <summary>
        /// Adds a new game to the database
        /// </summary>
        /// <returns>an integer id representing the game primary key id</returns>
        int CreateGame(Game game);

        Game GetGameById(int id);

        IList<Game> GetMyGames(int userId);
    }
}
