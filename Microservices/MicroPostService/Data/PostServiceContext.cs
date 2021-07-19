using MicroPostService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroPostService.Data
{
    /// <summary>
    /// C:\dev>docker run -p 3310:3306 --name=mysql1 -e MYSQL_ROOT_PASSWORD=pw -d mysql:5.6
    /// C:\dev>docker run -p 3311:3306 --name=mysql2 -e MYSQL_ROOT_PASSWORD = pw - d mysql:5.6
    /// </summary>
    public class PostServiceContext : DbContext
    {
        private readonly string _connectionString;

        public PostServiceContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}