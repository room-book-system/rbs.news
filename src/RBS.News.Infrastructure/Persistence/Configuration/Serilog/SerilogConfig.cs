namespace RBS.News.Infrastructure.Persistence.Configuration.Serilog;

public class SerilogConfig
{
    public MinimumLevelConfig MinimumLevel { get; set; }
}

public class MinimumLevelConfig
{
    public string Default { get; set; }
    public OverrideConfig Override { get; set; }
}

public class OverrideConfig
{
    public string Microsoft { get; set; }
    public string System { get; set; }
}