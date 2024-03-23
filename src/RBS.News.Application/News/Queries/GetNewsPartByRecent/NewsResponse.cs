namespace RBS.News.Application.News.Queries.GetNewsPartByRecent;

public sealed class NewsResponse
{
    public IEnumerable<NewsItem> News { get; set; }
}

public sealed class NewsItem(string Guid, string Title, string ShortDescription, DateTime Date, string ImageUrl);