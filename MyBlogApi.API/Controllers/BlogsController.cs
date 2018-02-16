﻿using MyBlogApi.Model;
using MyBlogApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace UnitTestingWebAPI.API.Core.Controllers
{
    public class BlogsController : ApiController
    {
        private IBlogService _blogService;

        public BlogsController()
        {
            _blogService = new BlogService();
        }

        // GET: api/Blogs
        public IEnumerable<Blog> GetBlogs()
        {
            return _blogService.GetBlogs();
        }

        // GET: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public IHttpActionResult GetBlog(int id)
        {
            Blog blog = _blogService.GetBlog(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT: api/Blogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlog(int id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog.ID)
            {
                return BadRequest();
            }

            _blogService.UpdateBlog(blog);            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Blogs
        [ResponseType(typeof(Blog))]
        public IHttpActionResult PostBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _blogService.CreateBlog(blog);

            return CreatedAtRoute("DefaultApi", new { id = blog.ID }, blog);
        }

        // DELETE: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public IHttpActionResult DeleteBlog(int id)
        {
            Blog blog = _blogService.GetBlog(id);
            if (blog == null)
            {
                return NotFound();
            }

            _blogService.DeleteBlog(blog);

            return Ok(blog);
        }

        private bool BlogExists(int id)
        {
            return _blogService.GetBlog(id) != null;
        }
    }
}
