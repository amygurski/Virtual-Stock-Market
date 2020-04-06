using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TeSnippets.DAL;
using TeSnippets.Models;
using TeSnippets.Models.Account;
using TeSnippets.Providers.Security;
using Microsoft.AspNetCore.Authorization;

namespace TeSnippets.Controllers
{
    /// <summary>
    /// Snippet Controller
    /// </summary>
    [Route("api/snippets")]
    [ApiController]
    public class SnippetController : Controller
    {
        private IUserDAO userDao;
        private ISnippetDAO snippetDao;
        private IPasswordHasher passwordHasher;

        /// <summary>
        /// Creates a new snippet controller.
        /// </summary>
        /// <param name="userDao">A data access object to store user data.</param>
        /// <param name="snippetDAO">A data access object to access snippet data.</param>
        /// <param name="passwordHasher">A password hasher used when hashing passwords.</param>
        public SnippetController(IUserDAO userDao, ISnippetDAO snippetDAO, IPasswordHasher passwordHasher)
        {
            this.userDao = userDao;
            this.snippetDao = snippetDAO;
            this.passwordHasher = passwordHasher;
        }

        /// <summary>
        /// I will return a list of snippets based on the user that is logged in.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<Snippet> List()
        {
            return snippetDao.GetSnippets(GetCurrentUserId());
        }

        /// <summary>
        /// I will get a snippet by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSnippet")]
        [Authorize]
        public ActionResult<Snippet> GetSnippet(int id)
        {
            var snippet = snippetDao.FindById(id, GetCurrentUserId());
            if (snippet == null)
            {
                return NotFound("The snippet you are looking for was not found.");
            }

            return snippet;
        }

        /// <summary>
        /// I will create a new snippet
        /// </summary>
        /// <param name="snippet"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<Snippet> CreateSnippet(Snippet snippet)
        {
            snippet.UserId = GetCurrentUserId();
            snippet = snippetDao.CreateSnippet(snippet);
            return snippet;
        }

        /// <summary>
        /// I will update a snippet
        /// </summary>
        /// <param name="snippet"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "UpdateSnippet")]
        [Authorize]
        public Snippet Update(Snippet snippet, [FromRoute]int id)
        {
            snippet.Id = id;
            snippet.UserId = GetCurrentUserId();
            return snippetDao.UpdateSnippet(snippet);
        }

        /// <summary>
        /// I will update a snippet by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteSnippet")]
        [Authorize]
        public ActionResult<int> Delete([FromRoute]int id)
        {
            snippetDao.DeleteSnippet(id, GetCurrentUserId());
            return new OkResult();
        }

        private int GetCurrentUserId()
        {
            return userDao.GetUser(base.User.Identity.Name).Id;
        }

    }
}