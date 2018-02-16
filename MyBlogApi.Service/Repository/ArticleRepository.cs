using MyBlogApi.Model;
using System.Collections.Generic;
using System.Linq;


namespace MyBlogApi.Service
{
    public class ArticleRepository 
    {
        IEnumerable<Article> _articles;

        public ArticleRepository()            {
            _articles = BloggerInitializer.GetAllArticles();
        }

        public virtual void Add(Article entity)
        {
            _articles.ToList().Add(entity);
        }

        public virtual void Update(Article entity)
        {
            Article upd = _articles.ToList().Where(b => b.ID == entity.ID).FirstOrDefault();
            upd.Author = entity.Author;
            upd.Blog = entity.Blog;
            upd.URL = entity.URL;
            upd.DateCreated = entity.DateCreated;
            upd.BlogID = entity.BlogID;
            upd.Title = entity.Title;
            upd.DateEdited = entity.DateEdited;
            upd.Contents = entity.Contents;

        }

        public virtual void Delete(Article entity)
        {
            _articles.ToList().Remove(entity);
        }

        public virtual Article GetById(int id)
        {
            return _articles.Where(b => b.ID == id).FirstOrDefault();
        }

        public virtual IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        public Article GetArticleByTitle(string articleTitle)
        {            
            return _articles.Where(b => b.Title == articleTitle).FirstOrDefault();
        }
    }

    
}
