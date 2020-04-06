using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEGram.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string UserName { get; internal set; }
        public string UserImage { get; internal set; }
    }
}
