using System.Collections.Generic;
using System.Reflection.Metadata;
using asp_net_microservice_template.Models;
using MongoDB.Driver;

namespace asp_net_microservice_template.DAO
{
    public class AboutContentDao : IAboutContentDao
    {
        private readonly IMongoCollection<PortfolioContentDocument> _aboutContent;
        private readonly int _aboutContentDocumentVersion;

        public AboutContentDao(IPortfolioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _aboutContent = database.GetCollection<PortfolioContentDocument>(settings.AboutCollectionName);
            _aboutContentDocumentVersion = settings.AboutCollectionVersion;
        }

        public PortfolioContentDTO Get() => _aboutContent
            .Find(content => content.Version == _aboutContentDocumentVersion)
            .SortByDescending(content => content.Timestamp).First().ToDTO();

        public PortfolioContentDTO Update(string newAboutContent)
        {
            PortfolioContentDocument documentToInsert =
                new PortfolioContentDocument(newAboutContent, _aboutContentDocumentVersion);
            
            _aboutContent.InsertOne(documentToInsert);

            return documentToInsert.ToDTO();
        }
    }

    public interface IAboutContentDao
    {
        public PortfolioContentDTO Get();
        public PortfolioContentDTO Update(string newAboutContent);
    }
}