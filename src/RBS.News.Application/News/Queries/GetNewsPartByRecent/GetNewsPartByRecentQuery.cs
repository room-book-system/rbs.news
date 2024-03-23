using RBS.News.Application.Abstractions.Messaging;

namespace RBS.News.Application.News.Queries.GetNewsPartByRecent;

public sealed record GetNewsPartByRecentQuery(int Page, int Limit) : IQuery<NewsResponse>;