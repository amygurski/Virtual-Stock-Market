using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeSnippets.Models;

namespace TeSnippets.DAL
{
    /// <summary>
    /// An interface for snippet dao objects.
    /// </summary>
    public interface ISnippetDAO
    {
        /// <summary>
        /// I will find a snippet by id.
        /// </summary>
        /// <param name="id">The snippet id.</param>
        /// <param name="userid">The user's id.</param>
        /// <returns></returns>
        Snippet FindById(int id, int userid);

        /// <summary>
        /// I will return a list of snippets for a given user
        /// </summary>
        /// <param name="userId">The user's id.</param>
        /// <returns></returns>
        List<Snippet> GetSnippets(int userId);

        /// <summary>
        /// I will save a new snippet.
        /// </summary>
        /// <param name="snippet">The snippet.</param>
        /// <returns></returns>
        Snippet CreateSnippet(Snippet snippet);

        /// <summary>
        /// I will update an exsiting snippet
        /// </summary>
        /// <param name="snippet"></param>
        Snippet UpdateSnippet(Snippet snippet);

        /// <summary>
        /// I will delete a snippet by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        void DeleteSnippet(int id, int userid);


    }
}
