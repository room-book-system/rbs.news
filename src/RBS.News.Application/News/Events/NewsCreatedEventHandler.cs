using RBS.News.Application.Abstractions.Events;
using RBS.News.Domain.Events.News;

namespace RBS.News.Application.News.Events;

public class NewsCreatedEventHandler : INewsCreatedEventHandler
{
    public Task HandleAsync(NewsCreatedEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}