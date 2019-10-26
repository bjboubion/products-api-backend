using System.Collections.Generic;

namespace products_api.Products.API.ViewModel
{
    public class KitViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Sku { get; set; }
        //  public List<string> Highlights { get; set; }
        // public List<DbLink> Links { get; set; }
        public string ImageSrc { get; set; }
        public string ShortDescription { get; set; }
    }
}