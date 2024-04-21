using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RBS.News.Domain.Stores;
using RBS.News.Infrastructure.Persistence.Configuration;

namespace RBS.News.Infrastructure.Persistence.Stores;

public class NewsStore : INewsStore
{
    private readonly IMongoCollection<Domain.Entities.News> _news;

    public NewsStore(IOptions<AppConfig> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionStrings.ConnectionString);
        var database = client.GetDatabase(settings.Value.ConnectionStrings.DatabaseName);
        _news = database.GetCollection<Domain.Entities.News>(settings.Value.ConnectionStrings.CollectionName);
    }
    
    public async Task<IEnumerable<Domain.Entities.News>> GetNewsAsync()
    {
        return await _news.Find(news => true).ToListAsync();
    }

    public async Task<Domain.Entities.News> GetNewsAsync(string id)
    {
        return await _news.Find(book => book.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Domain.Entities.News>> GetNewsAsync(int skip, int take)
    {
        return await _news.Find(news => true).Skip(skip).Limit(take).ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.News>> AddNewsAsync(IEnumerable<Domain.Entities.News> news)
    {
        await _news.InsertManyAsync(news);
        
        return news;    
    }

    public async Task<Domain.Entities.News> AddNewsSingleAsync(Domain.Entities.News news)
    {
        await _news.InsertOneAsync(news);
        return news;
    }

    public async Task UpdateNewsAsync(string id, Domain.Entities.News news)
    {
        await _news.ReplaceOneAsync(book => book.Id == id, news);
    }

    public async Task DeleteNewsAsync(string id)
    {
        await _news.DeleteOneAsync(book => book.Id == id);
    }
}