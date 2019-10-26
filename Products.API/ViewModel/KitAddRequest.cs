using System;
using System.Collections.Generic;

namespace products_api.Products.API.ViewModel
{
    public class KitAddRequest : RequestBaseModel
    {
        public List<string> Components { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}