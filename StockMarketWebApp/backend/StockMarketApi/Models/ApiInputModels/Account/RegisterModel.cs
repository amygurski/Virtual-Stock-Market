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
        [StringLength(16, ErrorMessage = "The password must be at between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "The password must include at least 1 uppercase letter, 1 lowercase letter, and one number.")] //Ensure at least one upper case letter, one lower case letter, and one numeric digit. 
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
