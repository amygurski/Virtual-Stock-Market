using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TEGram.DAL;

namespace TEGramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : TEGramController
    {
        public ValuesController(IUserDAO userDao) : base(userDao) { }
        /// <summary>
        /// Gets a collection of values. The requestor must be authenticated.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            string result = $@"
                Current User: {User.Identity.Name}
                Id: {CurrentUser.Id}
            ";
            //var result = $"Welcome back {User.Identity.Name}";
            return Ok(result);
        }

        /// <summary>
        /// Gets a special message. The requestor must be a user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("special")]
        [Authorize(Roles = "User")]
        public IActionResult RequestToken()
        {
            var result = "If you see this then you are a user.";
            return Ok(result);
        }

    }
}