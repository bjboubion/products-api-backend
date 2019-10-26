using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Infrastructure.Context
{
    public class DbManufacturingOptions
    {
        [BsonElement("weight")]
        public double Weight { get; set; }        
        [BsonElement("height")]
        public double Height { get; set; }
        [BsonElement("width")]
        public double Width { get; set; }
        [BsonElement("length")]
        public double Length { get; set; }
    }
}