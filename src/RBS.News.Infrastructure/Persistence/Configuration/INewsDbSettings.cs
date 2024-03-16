namespace RBS.News.Infrastructure.Persistence.Configuration;

public interface INewsDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string NewsCollectionName { get; set; }
}