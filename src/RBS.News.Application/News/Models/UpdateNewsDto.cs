namespace RBS.News.Application.News.Models;

public class UpdateNewsDto
{
    public string Id { get; set; }
    
    public string Title { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Html { get; set; }
    
    public string ImageSrc { get; set; }
}