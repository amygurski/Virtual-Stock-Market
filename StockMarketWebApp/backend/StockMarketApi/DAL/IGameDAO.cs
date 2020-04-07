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
        IList<Game> GetAllGames();
    }
}
