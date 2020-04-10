using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.StockTransactions
{
    public class UserAndGameAPIModel
    {
        public int GameId { get; set; }
        public string Username { get; set; }
    }
}
