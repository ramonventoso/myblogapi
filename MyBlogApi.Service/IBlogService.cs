using MyBlogApi.Model;
using System.Collections.Generic;

namespace MyBlogApi.Service
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetBlogs(string name = null);
        Blog GetBlog(int id);
        Blog GetBlog(string name);
        void CreateBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog(Blog blog);
    }

}
