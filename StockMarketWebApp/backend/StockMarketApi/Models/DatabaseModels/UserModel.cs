using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketApi.Models.DatabaseModels
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>        
        public string Firstname { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>        
        public string Email { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>        
        public string Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }
    }
}
