using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}
