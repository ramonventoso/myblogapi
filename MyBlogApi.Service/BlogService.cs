using MyBlogApi.Model;
using System.Collections.Generic;
using System.Linq;


namespace MyBlogApi.Service{
    
    public class BlogService : IBlogService
    {
        private BlogRepository _blogRepository;
        
        public BlogService()
        {
            _blogRepository = new BlogRepository();
        }

        #region IBlogService Members

        public IEnumerable<Blog> GetBlogs(string name = null)
        {
            var res = _blogRepository.GetAll(); 
            if (string.IsNullOrEmpty(name))
                return res;  
            else
                return res.Where(c => c.Name == name);   
        }

        public Blog GetBlog(int id)
        {
            var blog = _blogRepository.GetById(id);   
            return blog;
        }

        public Blog GetBlog(string name)
        {
            var blog = _blogRepository.GetBlogByName(name); 
            return blog;
        }

        public void CreateBlog(Blog blog)
        {
            _blogRepository.Add(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            _blogRepository.Update(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            _blogRepository.Delete(blog);
        }

        #endregion
    }
}
