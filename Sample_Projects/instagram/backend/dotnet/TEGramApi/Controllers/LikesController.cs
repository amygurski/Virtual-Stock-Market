using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEGram.DAL;
using TEGram.Models;

namespace TEGramApi.Controllers
{
    [Route("api/posts/{postId:int}/[controller]")]
    [ApiController]
    public class LikesController : TEGramController
    {
        private ILikeDAO likeDAO;
        public LikesController(ILikeDAO likeDAO, IUserDAO userDao) : base(userDao)
        {
            this.likeDAO = likeDAO;
        }

        // GET: api/posts/{postId}/Likes
        [HttpGet(Name ="GetLikes")]
        [Authorize]
        public IEnumerable<User> Get([FromRoute]int postId)
        {
            return likeDAO.GetAllLikesByPostId(postId);
        }

        // POST: api/posts/{postId}/Likes
        [HttpPost]
        [Authorize]
        public ActionResult<int> Post([FromRoute]int postId)
        {
            int numLikes = likeDAO.LikePostByUserId(postId, CurrentUser.Id);
            return Created($"/api/posts/{postId}/Likes", numLikes);
        }

        // DELETE: api/posts/{postId}/Likes
        [HttpDelete]
        [Authorize]
        public ActionResult<int> Delete([FromRoute]int postId)
        {
            return Ok(likeDAO.UnlikePostByUserId(postId, CurrentUser.Id));
        }
    }
}
