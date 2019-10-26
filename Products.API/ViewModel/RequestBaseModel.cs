using System;
using System.ComponentModel.DataAnnotations;
using products_api.Products.Domain.Models;

namespace products_api.Products.API.ViewModel
{
    public class RequestBaseModel
    {
        [Required]
        public string Sku { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ZREPrice { get; set; }
        public long? ShopifyID { get; set; }
        public long? ZREShopifyID { get; set; }
        public string Option { get; set; }
        public bool WebActive { get; set; }
        public string ImageUrl { get; set; }
        public string HighlightA { get; set; }
        public string HighlightB { get; set; }
        public string HighlightC { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public ManufacturingOptions ManufacturingOptions { get; set; }
        public ShippingOptions ShippingOptions { get; set; }
        public ProductDocuments Documents { get; set; }
        
    }
}