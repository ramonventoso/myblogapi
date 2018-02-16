using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogApi.Model;
using MyBlogApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UnitTestingWebAPI.API.Core.Controllers;

namespace MyBlogApi.API.Tests.Controllers
{
    [TestClass]
    public class ArticlesControllerTests
    {
        private IArticleService _articleService;
        private List<Article> _expectedArticles;
        
        public ArticlesControllerTests()
        {
            _articleService = new ArticleService();
            _expectedArticles = _articleService.GetArticles().ToList();
        }

        [TestMethod]
        public void GetShouldReturn3Articles()
        {
            // arrange
            var articlesController = new ArticlesController();           

            // act
            var articles = articlesController.GetArticles();

            // assert
            Assert.AreEqual(_expectedArticles.Count(), articles.Count());
        }

        [TestMethod]
        public void ControlerShouldReturnLastArticle()
        {
            // arrange 
            var articleController = new ArticlesController();            

            // act 
            var result = articleController.GetArticle(3) as OkNegotiatedContentResult<Article>;

            //assert
            Assert.AreEqual(_expectedArticles.Last().Title, result.Content.Title);
        }
        
    }
}
