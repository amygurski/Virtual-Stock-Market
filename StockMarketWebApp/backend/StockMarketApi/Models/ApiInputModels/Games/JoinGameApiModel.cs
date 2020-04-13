using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.Games
{
    public class JoinGameApiModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public int GameId { get; set; }
    }
}
