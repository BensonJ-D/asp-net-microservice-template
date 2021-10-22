namespace asp_net_microservice_template.Models
{
    public class PortfolioDatabaseSettings : IPortfolioDatabaseSettings
    {
        public string AboutCollectionName { get; set; }
        public int AboutCollectionVersion { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPortfolioDatabaseSettings
    {
        string AboutCollectionName { get; set; }
        int AboutCollectionVersion { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}