using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiReturnModels
{
    public class LeaderboardBalance
    {
        public string UserName { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
