using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Domain.Entity
{
    public class Post
    {
        public Post(string text, string userId, string categoryId)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
            Register_At = DateTime.Now;
            Updated_At = DateTime.Now;
            UserId = userId;
            CategoryId = categoryId;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Register_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string UserId { get; set; }
        public string CategoryId { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
