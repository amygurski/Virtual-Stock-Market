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

       

        // DELETE: api/posts/{postId}/Comments/{id}
        [Route("/api/[controller]/{id}")]
        [HttpDelete()]
        public void Delete(int id)
        {
            commentDAO.DeleteComment(id);
        }
    }
}
