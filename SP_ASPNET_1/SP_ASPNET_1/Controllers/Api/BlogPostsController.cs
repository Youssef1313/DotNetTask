using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SP_ASPNET_1.DbFiles.Contexts;
using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.Controllers.Api
{
    public class BlogPostsController : ApiController
    {
        private readonly IceCreamBlogContext _dbContext = new IceCreamBlogContext();


        // PUT: api/BlogPosts/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> LikeBlogPost(int id)
        {
            BlogPost blogPost = await _dbContext.BlogPosts.FirstOrDefaultAsync(p => p.BlogPostID == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.Likes++;
            await _dbContext.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}