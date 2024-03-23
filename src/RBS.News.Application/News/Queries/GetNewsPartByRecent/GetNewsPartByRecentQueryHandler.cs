using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;

namespace RBS.News.Application.News.Queries.GetNewsPartByRecent;

internal sealed class GetNewsPartByRecentQueryHandler(INewsStore newsStore)
    : IQueryHandler<GetNewsPartByRecentQuery, NewsResponse>
{
    public async Task<Result<NewsResponse>> Handle(
        GetNewsPartByRecentQuery request,
        CancellationToken cancellationToken)
    {
        var news = await newsStore.GetNewsAsync((request.Page * request.Limit), request.Limit);

        if (!news.Any())
        {
            return Result.Failure<NewsResponse>(new Error(
                "News.NotFound",
                $"The news for page {request.Page} was not found."));
        }

        var response = new NewsResponse()
        {
            News = news.Select(x => new NewsItem(x.Id, x.Title, x.ShortDescription, x.CreatedAt, x.ImageSrc))
        };

        return response;
    }
}