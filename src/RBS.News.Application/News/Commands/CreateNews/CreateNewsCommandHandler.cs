using RBS.News.Application.Abstractions.Events;
using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Domain.Events.News;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;
using RBS.News.Infrastructure.Events;

namespace RBS.News.Application.News.Commands.CreateNews;

internal sealed class CreateNewsCommandHandler : ICommandHandler<CreateNewsCommand>
{
    private readonly INewsStore _newsStore;
    private readonly IEventDispatcher _dispatcher;

    public CreateNewsCommandHandler(INewsStore newsStore, IEventDispatcher dispatcher)
    {
        _newsStore = newsStore;
        _dispatcher = dispatcher;
    }
    
    public async Task<Result> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = new Domain.Entities.News();
        
        await _newsStore.AddNewsSingleAsync(news);

        await _dispatcher.DispatchAsync(NewsCreatedEvent.Create(news));
        
        return Result.Success();
    }
}