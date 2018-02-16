using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApi.Model
{
    public class Blog : IComparable<Blog>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Blog()
        {
            Articles = new HashSet<Article>();
        }

        public int CompareTo(Blog other)
        {
            if (SameBlog(this, other)) return 0; else return -1;            
        }

        private bool SameBlog(Blog b1, Blog b2)
        {
            //if (b1.ID != b2.ID) return false;
            //f (b1.Name != b2.Name) return false;
            //if (b1.Owner != b2.Owner) return false;
            // if (b1.URL != b2.URL) return false;
            // if (b1.DateCreated != b2.DateCreated) return false;
            return true;
        }
    }
}
