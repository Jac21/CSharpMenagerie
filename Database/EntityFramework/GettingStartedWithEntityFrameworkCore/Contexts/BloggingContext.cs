using GettingStartedWithEntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace GettingStartedWithEntityFrameworkCore.Contexts;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        DbPath = Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}