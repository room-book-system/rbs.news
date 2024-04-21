using RBS.News.Application.Abstractions.Events;
using RBS.News.Domain.Events.News;

namespace RBS.News.Application.News.Events;

public class NewsDeletedEventHandler : INewsDeletedEventHandler
{
    public Task HandleAsync(NewsDeletedEvent domainEvent)
    {
        // TODO: Implement the domain event handler
        
        return Task.CompletedTask;
    }
}