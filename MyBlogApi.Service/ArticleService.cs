using MyBlogApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBlogApi.Service
{
    

    public class ArticleService : IArticleService
    {       
        private ArticleRepository _articleRepository;

        public ArticleService()
        {
            _articleRepository = new ArticleRepository();
        }

        #region IArticleService Members

        public IEnumerable<Article> GetArticles(string title = null)
        {
            IEnumerable<Article> results = null;
            if (string.IsNullOrEmpty(title))
                results = _articleRepository.GetAll();
            else
                results = _articleRepository.GetAll().Where(c => c.Title.ToLower().Contains(title.ToLower()));
            return results;
        }

        public Article GetArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            return article;
        }

        public Article GetArticle(string title)
        {
            var article = _articleRepository.GetArticleByTitle(title);
            return article;
        }

        public void CreateArticle(Article article)
        {
            _articleRepository.Add(article);
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.Update(article);
        }

        public void DeleteArticle(Article article)
        {
            _articleRepository.Delete(article);
        }

        #endregion

    }
}
