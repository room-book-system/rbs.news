using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Domain.Events.News;

public class NewsUpdatedEvent : IDomainEvent
{
    private Entities.News News { get; }

    private NewsUpdatedEvent(Entities.News news)
    {
        News = news;
    }
    
    public static NewsUpdatedEvent Create(Entities.News news)
    {
        return new NewsUpdatedEvent(news);
    }
}