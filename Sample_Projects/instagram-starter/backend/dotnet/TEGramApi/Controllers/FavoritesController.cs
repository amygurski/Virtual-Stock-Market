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

        

       
    }
}
