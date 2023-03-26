namespace SimpleReflectionMapper.Dtos;

public class BlogPostDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public DateOnly PublishedDate { get; set; }
}