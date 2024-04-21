using RBS.News.Application.News.Queries.Common;

namespace RBS.News.Application.News.Queries.GetNewsPartByRecent;

public sealed class GetNewsPartByResentResponse
{
    public IEnumerable<NewsItem> News { get; set; }
}

