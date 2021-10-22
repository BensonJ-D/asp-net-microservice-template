using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace asp_net_microservice_template.Models
{
    public class PortfolioContentDocument
    {
        public PortfolioContentDocument(string content, int version)
        {
            Id = ObjectId.GenerateNewId();
            Content = content;
            Timestamp = DateTime.Now;
            Version = version;
        }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        [BsonElement("content")]
        [JsonProperty("content")]
        public string Content { get; set; }

        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }


        [BsonElement("version")]
        [JsonProperty("version")]
        public int Version { get; set; }

        public PortfolioContentDTO ToDTO() => new PortfolioContentDTO(Content, Timestamp);
    }

    public class PortfolioContentDTO
    {
        public PortfolioContentDTO(string content, DateTime timestamp)
        {
            Content = content;
            Timestamp = timestamp;
        }

        [BsonElement("content")]
        [JsonProperty("content")]
        public string Content { get; set; }

        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}