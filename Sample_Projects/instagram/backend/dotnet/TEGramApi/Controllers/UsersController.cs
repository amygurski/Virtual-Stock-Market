using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEGram.DAL;
using TEGram.Models;

namespace TEGramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : TEGramController
    {
        private IPostDAO postDAO;
        public UsersController(IPostDAO postDAO, IUserDAO userDao) : base(userDao)
        {
            this.postDAO = postDAO;
        }

        // GET: api/Users/{username}
        [HttpGet("{username}", Name = "Get")]
        public UserPostsViewModel Get(string username)
        {
            User user = userDao.GetUser(username);

            UserPostsViewModel vm = new UserPostsViewModel()
            {
                Username = user.Username,
                Image = user.Image,
                UserPosts = postDAO.GetAllPostsByUserId(user.Id)
            };
            return vm;
        }
    }
}
