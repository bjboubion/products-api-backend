using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Products.Domain.Models
{
    public class ShippingOptions
    {
        public bool HazardShipping { get; private set; }
        public bool ColdShipping { get; private set; }
        public string TypeIceShipping { get; private set; }
        public double ShippingTemp { get; private set; }

        public ShippingOptions(bool hazardShipping, bool coldShipping, string typeIceShipping, double shippingTemp)
        {
            HazardShipping = hazardShipping;
            ColdShipping = coldShipping;
        }
    }
}