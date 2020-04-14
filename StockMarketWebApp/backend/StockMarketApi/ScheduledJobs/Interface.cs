using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.ScheduledJobs
{
    public interface IGameEnd
    {
        void SellOffStocks();
    }
}
