﻿using MyBlogApi.Model;
using MyBlogApi.Service;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace UnitTestingWebAPI.API.Core.Controllers
{
    public class ArticlesController : ApiController
    {
        private IArticleService _articleService;

        public ArticlesController()
        {
            _articleService = new ArticleService(); ;
        }

        // GET: api/Articles
        public IEnumerable<Article> GetArticles()
        {
            return _articleService.GetArticles();
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(int id)
        {
            Article article = _articleService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.ID)
            {
                return BadRequest();
            }

            _articleService.UpdateArticle(article);

            // persist            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Articles
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _articleService.CreateArticle(article);

            return CreatedAtRoute("DefaultApi", new { id = article.ID }, article);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult DeleteArticle(int id)
        {
            Article article = _articleService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }

            _articleService.DeleteArticle(article);

            return Ok(article);
        }

        private bool ArticleExists(int id)
        {
            return _articleService.GetArticle(id) != null;
        }
    }
}
