using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Application.News.Queries.Common;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;

namespace RBS.News.Application.News.Queries.GetNewsPartByRecent;

internal sealed class GetNewsPartByRecentQueryHandler(INewsStore newsStore)
    : IQueryHandler<GetNewsPartByRecentQuery, GetNewsPartByResentResponse>
{
    public async Task<Result<GetNewsPartByResentResponse>> Handle(
        GetNewsPartByRecentQuery request,
        CancellationToken cancellationToken)
    {
        var news = await newsStore.GetNewsAsync(((request.Page - 1) * request.Limit), request.Limit);

        if (!news.Any())
        {
            return Result.Failure<GetNewsPartByResentResponse>(new Error(
                "News.NotFound",
                $"The news for page {request.Page} was not found."));
        }

        var response = new GetNewsPartByResentResponse()
        {
            News = news.Select(x => new NewsItem(x.Id, x.Title, x.ShortDescription, x.CreatedAt, x.ImageSrc))
        };

        return response;
    }
}