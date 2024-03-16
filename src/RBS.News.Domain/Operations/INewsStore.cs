namespace RBS.News.Domain.Operations;

public interface INewsStore
{
    Task<IEnumerable<Entities.News>> GetNews();
    Task<Entities.News> GetNews(string id);
    Task<IEnumerable<Entities.News>> AddNews(IEnumerable<Entities.News> news);
    Task UpdateNews(string id, Entities.News news);
    Task DeleteNews(string id);
}
