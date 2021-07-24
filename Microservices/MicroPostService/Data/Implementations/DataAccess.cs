using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroPostService.Data.Interfaces;
using MicroPostService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace MicroPostService.Data.Implementations
{
    public class DataAccess : IDataAccess
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

        public async Task<int> AddUser(User user)
        {
            await using var dbContext =
                new PostServiceContext(ConnectionUtilities.GetConnectionString(_connectionStrings, user.Name));

            if (dbContext.User.Any(u => u.Id == user.Id))
            {
                _logger.LogInformation("Ignoring old/duplicate entry");
            }

            dbContext.User.Add(user);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(User newUser)
        {
            await using var dbContext =
                new PostServiceContext(ConnectionUtilities.GetConnectionString(_connectionStrings, newUser.Name));

            var newVersion = newUser.Version;

            var user = dbContext.User.First(a => a.Id == newUser.Id);

            if (user.Version >= newVersion)
            {
                WriteLine("Ignoring old/duplicate entity");
            }
            else
            {
                user.Name = newUser.Name;
                user.Version = newVersion;
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(User user)
        {
            await using var dbContext =
                new PostServiceContext(ConnectionUtilities.GetConnectionString(_connectionStrings, user.Name));

            var userToDelete = dbContext.User.First(a => a.Id == user.Id);

            dbContext.User.Remove(userToDelete);

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