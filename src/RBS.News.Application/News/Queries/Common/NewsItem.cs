using System.Runtime.InteropServices.JavaScript;

namespace RBS.News.Application.News.Queries.Common;

public sealed class NewsItem(string guid, string title, string shortDescription, DateTime date, string imageUrl)
{
    public string ImageUrl { get; set; } = imageUrl;

    public DateTime Date { get; set; } = date;

    public string ShortDescription { get; set; } = shortDescription;

    public string Title { get; set; } = title;

    public string Guid { get; set; } = guid;
}