// See https://aka.ms/new-console-template for more information

/*
 * dotnet tool install --global dotnet-ef
 * dotnet add package Microsoft.EntityFrameworkCore.Design
 * dotnet ef migrations add InitialCreate
 * dotnet ef database update
 */

using GettingStartedWithEntityFrameworkCore.Contexts;
using GettingStartedWithEntityFrameworkCore.Models;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

void Create(string url)
{
    Console.WriteLine("Inserting a new blog...");

    db.Add(new Blog
    {
        Url = url
    });

    db.SaveChanges();
}

Create("https://www.jeremycantu.com/");

Blog Read()
{
    Console.WriteLine("Querying for a blog...");

    return db.Blogs
        .OrderBy(b => b.BlogId)
        .First();
}

var readBlog = Read();

void Update(Blog blog)
{
    Console.WriteLine("Updating the blog and adding a post");

    blog.Posts
        .Add(new Post
        {
            Title = "SkillSet",
            Content = "More information as to the development of SkillSet.",
            Slug = "skillset"
        });

    db.SaveChanges();
}

Update(readBlog);

void Delete(Blog blog)
{
    Console.WriteLine("Deleting the blog...");

    db.Remove(blog);

    db.SaveChanges();
}

Delete(readBlog);