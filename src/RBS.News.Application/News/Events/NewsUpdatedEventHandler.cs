using RBS.News.Application.Abstractions.Events;
using RBS.News.Domain.Events.News;

namespace RBS.News.Application.News.Events;

public class NewsUpdatedEventHandler : INewsUpdatedEventHandler
{
    public Task HandleAsync(NewsUpdatedEvent domainEvent)
    {
        // TODO: Implement the domain event handler

        return Task.CompletedTask;
    }
}