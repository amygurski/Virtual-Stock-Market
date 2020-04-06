using System;
using System.Collections.Generic;
using System.Text;

namespace TEGram.Models
{
    public class UserPostsViewModel
    {

        /// <summary>
        /// The user's username.
        /// </summary>        
        public string Username { get; set; }

        /// <summary>
        /// A URL to the user's image
        /// </summary>
        public string Image { get; set; } = "";

        public IList<Post> UserPosts { get; set; }
    }
}
