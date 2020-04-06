using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEGram.Models;

namespace TEGram.DAL
{
    /// <summary>
    /// Interface for data access methods for the Post class
    /// </summary>
    public interface IPostDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        IList<Post> GetAllPosts(int currentUserId);
        IList<Post> GetAllPostsByUserId(int userId);
        Post GetPostById(int id, int currentUserId);
        IList<Post> GetFavoritesByUserId(int userId);
        Post CreatePost(Post post);
    }
}
