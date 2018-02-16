using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogApi.Model;
using MyBlogApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.API.Core.Controllers;

namespace MyBlogApi.API.Tests
{
    [TestClass]
    public class BlogsControllerTests
    {
        
        private IBlogService _blogService;
         
        

        public BlogsControllerTests()
        {
            _blogService = new BlogService();
        }
        [TestMethod]
        public void GetShouldReturn2Blogs()
        {
            // arrange
            var _blogsController = new BlogsController();
            var expectedResults = _blogService.GetBlogs();
            
            // act
            var results = _blogsController.GetBlogs();
            
            
            // assert
            Assert.AreEqual(expectedResults.Count(), results.Count());

        }

        [TestMethod]
        public void GetShouldReturnAllBlogs()
        {
            // arrange
            var _blogsController = new BlogsController();
            IEnumerable<Blog> expectedResults = _blogService.GetBlogs();
           
            // act            
            IEnumerable<Blog> results = _blogsController.GetBlogs();
            
            // assert
            var er = expectedResults.ToList();
            var r = results.ToList();
            for (int i = 0; i < r.Count; i++)
            {
                
                Blog rid = r.Where(x => x.ID == er[i].ID).FirstOrDefault(); 
                Assert.AreEqual<Blog>(er[i], rid);
            }

                // CollectionAssert.AreEqual(results.ToList(), results.ToList());

        }

        
    }
}
