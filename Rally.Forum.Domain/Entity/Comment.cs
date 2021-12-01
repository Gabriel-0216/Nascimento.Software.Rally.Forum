using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Domain.Entity
{
    public class Comment
    {
        public Comment(string text, string userId, string postId)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
            Register_At = DateTime.Now;
            Updated_At = DateTime.Now;
            UserId = userId;
            PostId = postId;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Register_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
    }
}
