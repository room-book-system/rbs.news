using Microsoft.Extensions.DependencyInjection;
using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Infrastructure.Events;

public class EventDispatcher(IServiceProvider serviceProvider) : IEventDispatcher
{
    public async Task DispatchAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        IEnumerable<IDomainEventHandler<TEvent>> handlers = serviceProvider.GetServices<IDomainEventHandler<TEvent>>();

        foreach (var handler in handlers)
        {
            await handler.HandleAsync(domainEvent);
        }
    }
}