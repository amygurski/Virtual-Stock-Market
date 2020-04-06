using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    /// <summary>
    /// Interface for data access methods for the Like class
    /// </summary>
    public interface ILikeDAO
    {
        /// <summary>
        /// Get all of the users who have like a post id
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <returns>List of users who like this post</returns>
        IList<User> GetAllLikesByPostId(int postId);

        /// <summary>
        /// Mark a post as liked by a user
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>The new number of likes currently on this post</returns>
        int LikePostByUserId(int postId, int userId);

        /// <summary>
        /// Removes a like for this user from the post
        /// </summary>
        /// <param name="postId">Id of the post</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>The new number of likes currently on this post</returns>
        int UnlikePostByUserId(int postId, int userId);
    }
}
