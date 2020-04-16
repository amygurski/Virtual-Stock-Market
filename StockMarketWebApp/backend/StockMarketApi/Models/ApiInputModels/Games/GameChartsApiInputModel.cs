using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.Games
{
    public class GameChartsApiInputModel
    {
        public int GameId { get; set; }
        public string UserName { get; set; }
    }
}
