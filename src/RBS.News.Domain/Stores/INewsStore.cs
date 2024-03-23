namespace RBS.News.Domain.Stores;

public interface INewsStore
{
    Task<IEnumerable<Entities.News>> GetNewsAsync();
    Task<Entities.News> GetNewsAsync(string id);
    Task<IEnumerable<Domain.Entities.News>> GetNewsAsync(int skip, int take);
    Task<IEnumerable<Entities.News>> AddNewsAsync(IEnumerable<Entities.News> news);
    Task<Entities.News> AddNewsSingleAsync(Entities.News news);
    Task UpdateNewsAsync(string id, Entities.News news);
    Task DeleteNewsAsync(string id);
}
