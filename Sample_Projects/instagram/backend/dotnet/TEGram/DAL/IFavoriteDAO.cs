using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    /// <summary>
    /// Interface for data access methods for the Favorite class
    /// </summary>
    public interface IFavoriteDAO
    {
        /// <summary>
        /// Add a post to the user's favorites
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="userId">Id of the user</param>
        void FavorPostByUserId(int postId, int userId);

        /// <summary>
        /// Remove a post from the user's favorites
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="userId">Id of the user</param>
        void DisfavorPostByUserId(int postId, int userId);

        /// <summary>
        /// Get the list of posts that the user has added to favorites
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns></returns>
        IList<Post> GetFavoritesByUserId(int userId);
    }
}
