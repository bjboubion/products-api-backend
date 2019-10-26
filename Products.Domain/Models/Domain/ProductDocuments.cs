using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Domain.Models
{
    public class ProductDocuments
    {
        public string Protocol { get; private set; }
        public string Datasheet { get; private set; }
        public string SDS { get; private set; }

        public ProductDocuments(string protocol, string datasheet, string sds)
        {
            Protocol = protocol;
            Datasheet = datasheet;
            SDS = sds;   
        }
    }
}