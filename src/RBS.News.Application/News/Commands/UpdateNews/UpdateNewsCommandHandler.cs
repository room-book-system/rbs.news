using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Domain.Events.News;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;
using RBS.News.Infrastructure.Events;

namespace RBS.News.Application.News.Commands.UpdateNews;

internal class UpdateNewsCommandHandler(INewsStore newsStore, IEventDispatcher dispatcher)
    : ICommandHandler<UpdateNewsCommand>
{
    public async Task<Result> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await newsStore.GetNewsAsync(request.News.Id);
        
        news.Title = request.News.Title;
        news.ShortDescription = request.News.ShortDescription;
        news.Html = request.News.Html;
        news.ImageSrc = request.News.ImageSrc;
        news.EditedAt = DateTime.UtcNow;
        
        await newsStore.UpdateNewsAsync(news.Id, news);
        
        await dispatcher.DispatchAsync(NewsUpdatedEvent.Create(news));
        
        return Result.Success();
    }
}