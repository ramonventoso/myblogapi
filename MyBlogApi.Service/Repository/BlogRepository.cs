using MyBlogApi.Model;
using System.Collections.Generic;
using System.Linq;


namespace MyBlogApi.Service
{
    public class BlogRepository 
    {
        IEnumerable<Blog> _blogs;
        public BlogRepository()
        {
            _blogs = BloggerInitializer.GetBlogs();
        }
        
        public virtual void Add(Blog entity)
        {
            _blogs.ToList().Add(entity);
        }

        public virtual void Update(Blog entity)
        {            
            Blog upd = _blogs.ToList().Where(b => b.ID == entity.ID).FirstOrDefault();
            upd.Name = entity.Name;
            upd.Owner = entity.Owner;
            upd.URL = entity.URL;
            upd.DateCreated = entity.DateCreated;
            upd.Articles = entity.Articles;
        }

        public virtual void Delete(Blog entity)
        {
            _blogs.ToList().Remove(entity);
        }
       
        public virtual Blog GetById(int id)
        {
            return _blogs.Where( b => b.ID == id).FirstOrDefault();
        }

        public virtual IEnumerable<Blog> GetAll()
        {
            return _blogs;
        }
        
        public Blog GetBlogByName(string blogName)
        {
            return _blogs.Where(b => b.Name == blogName).FirstOrDefault();

        }
    }

}
