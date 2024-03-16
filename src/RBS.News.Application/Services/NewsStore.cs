using MongoDB.Driver;
using RBS.News.Domain.Operations;
using RBS.News.Infrastructure.Persistence.Configuration;

namespace RBS.News.Application.Services;

public class NewsStore : INewsStore
{
    private readonly IMongoCollection<Domain.Entities.News> _news;

    public NewsStore(INewsDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _news = database.GetCollection<Domain.Entities.News>(settings.NewsCollectionName);
    }
    
    public async Task<IEnumerable<Domain.Entities.News>> GetNews()
    {
        return await _news.Find(news => true).ToListAsync();
    }

    public async Task<Domain.Entities.News> GetNews(string id)
    {
        return await _news.Find(book => book.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Domain.Entities.News>> AddNews(IEnumerable<Domain.Entities.News> news)
    {
        await _news.InsertManyAsync(news);
        return news;    
    }

    public async Task UpdateNews(string id, Domain.Entities.News news)
    {
        await _news.ReplaceOneAsync(book => book.Id == id, news);
    }

    public async Task DeleteNews(string id)
    {
        await _news.DeleteOneAsync(book => book.Id == id);
    }
}