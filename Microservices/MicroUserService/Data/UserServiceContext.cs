using Microsoft.EntityFrameworkCore;
using MicroUserService.Entities;

namespace MicroUserService.Data
{
    public class UserServiceContext : DbContext
    {
        public UserServiceContext(DbContextOptions<UserServiceContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}