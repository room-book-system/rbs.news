using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Application.News.Queries.Common;
using RBS.News.Application.News.Queries.GetNewsPartByRecent;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;

namespace RBS.News.Application.News.Queries.GetNewsById;

internal sealed class GetNewsByIdQueryHandler(INewsStore newsStore)
    : IQueryHandler<GetNewsByIdQuery, GetNewsByIdResponse>
{
    public async Task<Result<GetNewsByIdResponse>> Handle(
        GetNewsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var news = await newsStore.GetNewsAsync(request.Id);

        if (news.Id == default)
        {
            return Result.Failure<GetNewsByIdResponse>(new Error(
                "News.NotFound",
                $"The news with id {request.Id} was not found."));
        }
        
        return new GetNewsByIdResponse()
        {
            News = new NewsItem(news.Id, news.Title, news.ShortDescription, news.CreatedAt, news.ImageSrc)
        };
    }
}