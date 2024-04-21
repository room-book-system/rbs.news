using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Domain.Events.News;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;
using RBS.News.Infrastructure.Events;

namespace RBS.News.Application.News.Commands.DeleteNews;

internal class DeleteNewsCommandHandler(INewsStore newsStore, IEventDispatcher dispatcher)
    : ICommandHandler<DeleteNewsCommand>
{
    public async Task<Result> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await newsStore.GetNewsAsync(request.Id);
        
        await newsStore.DeleteNewsAsync(news.Id);
        
        await dispatcher.DispatchAsync(NewsDeletedEvent.Create(news));
        
        return Result.Success();
    }
}