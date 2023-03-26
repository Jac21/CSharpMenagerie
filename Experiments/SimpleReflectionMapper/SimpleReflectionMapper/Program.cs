// See https://aka.ms/new-console-template for more information

using SimpleReflectionMapper.Core;
using SimpleReflectionMapper.Dtos;
using SimpleReflectionMapper.Models;
using static System.Console;

WriteLine("Hello, Mapper!");

var blogPost = new BlogPost
{
    Id = 0,
    Title = "My Post",
    PublishedDate = new DateOnly(2023, 03, 26)
};

var dto = Mapper.Map<BlogPost, BlogPostDto>(blogPost);

WriteLine(dto.Id);
WriteLine(dto.Title);
WriteLine(dto.PublishedDate);

ReadLine();