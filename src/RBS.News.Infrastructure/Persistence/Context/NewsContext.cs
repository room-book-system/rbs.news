using MongoDB.Driver;
using RBS.News.Infrastructure.Persistence.Configuration;

namespace RBS.News.Infrastructure.Persistence.Context;

public class NewsContext
{
    private readonly IMongoDatabase _db;

    public NewsContext(INewsDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _db = client.GetDatabase(settings.DatabaseName);
    }
    
    public IMongoCollection<Domain.Entities.News> News => _db.GetCollection<Domain.Entities.News>(nameof(News));
}