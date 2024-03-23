using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Domain.Events.News;

public class NewsCreatedEvent : IDomainEvent
{
    private Entities.News News { get; }

    private NewsCreatedEvent(Entities.News news)
    {
        News = news;
    }
    
    public static NewsCreatedEvent Create(Entities.News news)
    {
        return new NewsCreatedEvent(news);
    }
}