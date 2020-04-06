using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    /// <summary>
    /// Interface for data access methods for the Post Comment class
    /// </summary>
    public interface ICommentDAO
    {
        /// <summary>
        /// Add a new comment on a post
        /// </summary>
        /// <param name="comment">A Comment object to be added</param>
        /// <returns>The new COmment object (complete with Id and timestamp)</returns>
        Comment CreateComment(Comment comment);

        /// <summary>
        /// Delete a comment from a post
        /// </summary>
        /// <param name="commentId">The id of the comment to be deleted</param>
        void DeleteComment(int commentId);
    }
}
