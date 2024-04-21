using RBS.News.Infrastructure.Persistence.Configuration.ConnectionString;
using RBS.News.Infrastructure.Persistence.Configuration.ElasticSearch;
using RBS.News.Infrastructure.Persistence.Configuration.Serilog;

namespace RBS.News.Infrastructure.Persistence.Configuration;

public class AppConfig
{
    public ConnectionStringsConfig ConnectionStrings { get; set; }
    public SerilogConfig Serilog { get; set; }
    public ElasticSearchConfig ElasticSearch { get; set; }
    
}