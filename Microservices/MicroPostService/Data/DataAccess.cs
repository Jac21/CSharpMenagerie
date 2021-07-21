using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroPostService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroPostService.Data
{
    public class DataAccess
    {
        private readonly ILogger<DataAccess> _logger;

        private readonly List<string> _connectionStrings = new List<string>();

        public DataAccess(IConfiguration configuration, ILogger<DataAccess> logger)
        {
            _logger = logger;

            ConnectionUtilities.CreateConnectionStringsListFromConfiguration(configuration, _connectionStrings);
        }

        public async Task<ActionResult<IEnumerable<Post>>> ReadLatestPosts(string category, int count)
        {
            await using var dbContext =
                new PostServiceContext(ConnectionUtilities.GetConnectionString(_connectionStrings, category));

            return await dbContext.Post.OrderByDescending(p => p.PostId).Take(count).Include(x => x.User)
                .Where(p => p.CategoryId == category).ToListAsync();
        }

        public async Task<int> CreatePost(Post post)
        {
            await using var dbContext =
                new PostServiceContext(ConnectionUtilities.GetConnectionString(_connectionStrings, post.CategoryId));

            dbContext.Post.Add(post);

            return await dbContext.SaveChangesAsync();
        }

        public void InitDatabase(int countUsers, int countCategories)
        {
            foreach (var connectionString in _connectionStrings)
            {
                _logger.LogInformation($"{nameof(InitDatabase)} called for {connectionString}");

                using var dbContext = new PostServiceContext(connectionString);

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();


                for (var i = 1; i <= countUsers; i++)
                {
                    dbContext.User.Add(new User {Name = "User" + i, Version = 1});
                    dbContext.SaveChanges();
                }

                for (var i = 1; i <= countCategories; i++)
                {
                    dbContext.Categories.Add(new Category {CategoryId = "Category" + i});
                    dbContext.SaveChanges();
                }
            }
        }
    }
}