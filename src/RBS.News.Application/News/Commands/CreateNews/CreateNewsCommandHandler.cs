using RBS.News.Application.Abstractions.Events;
using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Domain.Events.News;
using RBS.News.Domain.Shared;
using RBS.News.Domain.Stores;
using RBS.News.Infrastructure.Events;

namespace RBS.News.Application.News.Commands.CreateNews;

internal sealed class CreateNewsCommandHandler(INewsStore newsStore, IEventDispatcher dispatcher)
    : ICommandHandler<CreateNewsCommand>
{
    public async Task<Result> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = new Domain.Entities.News()
        {
            Title = request.News.Title,
            ShortDescription = request.News.ShortDescription,
            CreatedAt = DateTime.UtcNow,
            EditedAt = DateTime.UtcNow,
            Html = request.News.Html,
            ImageSrc = request.News.ImageSrc
        };
        
        await newsStore.AddNewsSingleAsync(news);

        await dispatcher.DispatchAsync(NewsCreatedEvent.Create(news));
        
        return Result.Success();
    }
}