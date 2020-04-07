using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models
{
    /// <summary>
    /// Represents an instance of a game played by users
    /// </summary>
    public class Game
    {

        /// <summary>
        /// The ID assigned to each game instance
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// The ID of the user that created the game instance
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// The name that the game creator assigned to their instance of the game
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// The date that the game was started
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that the game is set to end on
        /// </summary>
        public DateTime EndDate { get; set; }

    }
}
