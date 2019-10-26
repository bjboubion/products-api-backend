using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Infrastructure.Context
{
    public class DbComponent
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("sku")]
        public string Sku { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }
        [BsonElement("zrePrice")]
        public double ZREPrice { get; set; }
        [BsonElement("shopifyID")]
        public long? ShopifyID { get; set; }
        [BsonElement("zreShopifyID")]
        public long? ZREShopifyID { get; set; }
        [BsonElement("option")]
        public string Option { get; set; }
        [BsonElement("webActive")]
        public bool WebActive { get; set; }
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("highlightA")]
        public string HighlightA { get; set; }
        [BsonElement("highlightB")]
        public string HighlightB { get; set; }
        [BsonElement("highlightC")]
        public string HighlightC { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("shortDescription")]
        public string ShortDescription { get; set; }
        [BsonElement("productType")]
        [BsonRepresentation(BsonType.String)]
        public ProductType ProductType { get; set; }
        [BsonElement("manufacturingOptions")]
        public DbManufacturingOptions ManufacturingOptions { get; set; }
        [BsonElement("shippingOptions")]
        public DbShippingOptions ShippingOptions { get; set; }
        [BsonElement("documents")]
        public DbProductDocuments Documents { get; set; }
        [BsonElement("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }
    }

    public enum ProductType 
    {
        component,
        kit
    }
}