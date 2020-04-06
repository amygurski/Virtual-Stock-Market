using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEGram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string Caption { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public int NumberOfLikes { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFavored { get; set; }
        public string UserName { get; internal set; }
        public string UserImage { get; internal set; }


        private IList<Comment> comments = new List<Comment>();
        public IList<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

    }
}
