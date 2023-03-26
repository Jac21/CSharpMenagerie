namespace SimpleReflectionMapper.Models;

public class BlogPost
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public DateOnly PublishedDate { get; set; }
}