using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Infrastructure.Events;

public interface IEventDispatcher
{
    Task DispatchAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
}