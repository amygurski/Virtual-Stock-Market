using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeSnippets.Models
{
    /// <summary>
    /// Represents a Snippet in our snippet manager.
    /// </summary>
    public class Snippet
    {
        /// <summary>
        /// The snippet's id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The description of the snippet.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The filename of the snippet.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The snippet's source code.
        /// </summary>
        public string SourceCode { get; set; }

        /// <summary>
        /// The snippets tags.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// The id of the user this snippet belongs to.
        /// </summary>
        public int UserId { get; set; }
    }
}
