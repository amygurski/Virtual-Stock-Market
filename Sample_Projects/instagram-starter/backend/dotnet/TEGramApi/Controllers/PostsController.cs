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
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : TEGramController
    {
        private IPostDAO postDAO;
        public PostsController(IPostDAO postDAO, IUserDAO userDao) : base(userDao)
        {
            this.postDAO = postDAO;
        }

        // GET: api/Posts
        [HttpGet]
        [Authorize]
        public IEnumerable<Post> Get()
        {
            return postDAO.GetAllPosts(CurrentUser.Id);
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        [Authorize]
        public Post Get(int id)
        {
            return postDAO.GetPostById(id, CurrentUser.Id);
        }


    }
}
