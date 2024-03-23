using Microsoft.Extensions.DependencyInjection;
using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Infrastructure.Events;

public class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        IEnumerable<IDomainEventHandler<TEvent>> handlers = _serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
            
        foreach (var handler in handlers)
        {
            await handler.HandleAsync(domainEvent);
        }
    }
}