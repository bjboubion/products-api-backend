using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Infrastructure.Context
{
    public class DbKit : DbComponent
    {

        [BsonElement("components")]
        public List<string> Components { get; set; }
    }
}