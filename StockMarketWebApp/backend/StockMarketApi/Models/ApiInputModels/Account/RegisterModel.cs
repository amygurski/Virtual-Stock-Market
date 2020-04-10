using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.ApiInputModels.Account
{
    /// <summary>
    /// Represents a registration request
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Users Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User First NAme
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
