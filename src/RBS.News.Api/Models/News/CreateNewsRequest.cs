using RBS.News.Application.News.Models;

namespace RBS.News.Api.Models.News;

public class CreateNewsRequest
{
    public string Title { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Html { get; set; }
    
    public string ImageSrc { get; set; }
    
    public static Func<CreateNewsRequest, CreateNewsDto> Projection =>
        x => new CreateNewsDto
        {
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Html = x.Html,
            ImageSrc = x.ImageSrc
        };
    
    public static CreateNewsDto Map(CreateNewsRequest newsRequest)
    {
        return new CreateNewsDto
        {
            Title = newsRequest.Title,
            ShortDescription = newsRequest.ShortDescription,
            Html = newsRequest.Html,
            ImageSrc = newsRequest.ImageSrc
        };
    }
}