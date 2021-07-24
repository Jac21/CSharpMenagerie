using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroPostService.Data;
using MicroPostService.Data.Implementations;
using MicroPostService.Entities;

namespace MicroPostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataAccess _dataAccess;

        public PostController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetLatestPosts(string category, int count)
        {
            return await _dataAccess.ReadLatestPosts(category, count);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            await _dataAccess.CreatePost(post);

            return CreatedAtAction($"{nameof(PostPost)}", new {id = post.PostId}, post);
        }

        [HttpGet("InitDatabase")]
        public void InitDatabase([FromQuery] int countUsers, [FromQuery] int countCategories)
        {
            _dataAccess.InitDatabase(countUsers, countCategories);
        }
    }
}