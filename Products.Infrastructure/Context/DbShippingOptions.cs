using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Infrastructure.Context
{
    public class DbShippingOptions
    {
        [BsonElement("hazardShipping")]
        public bool HazardShipping { get; set; }
        [BsonElement("coldShipping")]
        public bool ColdShipping { get; set; }
        [BsonElement("typeIceShipping")]
        public string TypeIceShipping { get; set; }
        [BsonElement("shippingTemp")]
        public double ShippingTemp { get; set; }
    }
}