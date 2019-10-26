using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Infrastructure.Context
{
    public class DbProductDocuments
    {
        [BsonElement("protocol")]
        public string Protocol { get; set; }
        [BsonElement("datasheet")]
        public string Datasheet { get; set; }
        [BsonElement("sds")]
        public string SDS { get; set; }
    }
}