using RBS.News.Domain.Events.Abstractions;
using RBS.News.Domain.Events.News;

namespace RBS.News.Application.Abstractions.Events;

public interface INewsUpdatedEventHandler : IDomainEventHandler<NewsUpdatedEvent>;