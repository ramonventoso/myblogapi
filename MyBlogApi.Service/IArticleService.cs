using MyBlogApi.Model;
using System.Collections.Generic;

namespace MyBlogApi.Service
{    
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles(string name = null);
        Article GetArticle(int id);
        Article GetArticle(string name);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);

    }
}
