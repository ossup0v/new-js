namespace TestVue.InternalApi.Configs;

public class MongoDbConfig
{
    public const string Section = "MongoDbConfig";
    public string ConnectionUri { get; set; }
    public string DatabaseName { get; set; }
}