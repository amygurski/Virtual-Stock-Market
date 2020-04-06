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
    public class FavoritesController : TEGramController
    {
        private IFavoriteDAO favoriteDAO;
        public FavoritesController(IFavoriteDAO favoriteDAO, IUserDAO userDao) : base(userDao)
        {
            this.favoriteDAO = favoriteDAO;
        }

        // GET: api/favorites
        [Route("/api/[controller]")]
        [HttpGet(Name = "GetFavorites")]
        [Authorize]
        public IEnumerable<Post> Get([FromRoute]int postId)
        {
            return favoriteDAO.GetFavoritesByUserId(CurrentUser.Id);
        }

        // POST: api/posts/{postId}/favorites
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromRoute]int postId)
        {
            favoriteDAO.FavorPostByUserId(postId, CurrentUser.Id);
            return new OkResult();
        }

        // DELETE: api/posts/{postId}/favorites
        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromRoute]int postId)
        {
            favoriteDAO.DisfavorPostByUserId(postId, CurrentUser.Id);
            return new OkResult();
        }
    }
}
