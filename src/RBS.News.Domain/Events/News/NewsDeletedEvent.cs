using RBS.News.Domain.Events.Abstractions;

namespace RBS.News.Domain.Events.News;

public class NewsDeletedEvent : IDomainEvent
{
    private Entities.News News { get; }

    private NewsDeletedEvent(Entities.News news)
    {
        News = news;
    }
    
    public static NewsDeletedEvent Create(Entities.News news)
    {
        return new NewsDeletedEvent(news);
    }
   
}