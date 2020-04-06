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
    public class CommentsController : TEGramController
    {
        private ICommentDAO commentDAO;
        public CommentsController(ICommentDAO commentDAO, IUserDAO userDao) : base(userDao)
        {
            this.commentDAO = commentDAO;
        }

        // POST: api/posts/{postId}/comments
        [HttpPost]
        [Authorize]
        public ActionResult<Comment> Post([FromRoute]int postId, [FromBody] Comment comment)
        {
            // Set the UserId field to the current user.
            comment.UserId = CurrentUser.Id;
            comment.PostId = postId;
            comment = commentDAO.CreateComment(comment);

            return Created($"api/posts/{postId}/comments", comment);
        }

        // DELETE: api/posts/{postId}/Comments/{id}
        [Route("/api/[controller]/{id}")]
        [HttpDelete()]
        public void Delete(int id)
        {
            commentDAO.DeleteComment(id);
        }
    }
}
