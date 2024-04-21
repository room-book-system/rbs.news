using RBS.News.Application.News.Models;

namespace RBS.News.Api.Models.News;

public class UpdateNewsRequest
{
    public string Title { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Html { get; set; }
    
    public string ImageSrc { get; set; }
    
    public static Func<UpdateNewsRequest, UpdateNewsDto> Projection =>
        x => new UpdateNewsDto
        {
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Html = x.Html,
            ImageSrc = x.ImageSrc
        };
    
    public static UpdateNewsDto Map(string id, UpdateNewsRequest newsRequest)
    {
        return new UpdateNewsDto
        {
            Id = id,
            Title = newsRequest.Title,
            ShortDescription = newsRequest.ShortDescription,
            Html = newsRequest.Html,
            ImageSrc = newsRequest.ImageSrc
        };
    }
}