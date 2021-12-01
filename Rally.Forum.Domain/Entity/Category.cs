using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Domain.Entity
{
    public class Category
    {
        public Category(string category_Name)
        {
            Id = Guid.NewGuid().ToString();
            Category_Name = category_Name;
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }

        public string Id { get; set; }
        public string Category_Name { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}
