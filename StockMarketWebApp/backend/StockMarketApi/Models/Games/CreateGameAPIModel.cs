using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.Games
{
    public class CreateGameAPIModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
