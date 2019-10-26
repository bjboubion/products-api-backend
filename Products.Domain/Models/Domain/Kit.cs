using System;
using System.Collections.Generic;

namespace products_api.Products.Domain.Models
{
    public class Kit
    {
        // private DateTime _modifiedDate;
        private decimal _zrcPrice;
        private decimal _zrePrice;
        private readonly List<string> _componentList;
        public string Name { get; private set; }
        public string Sku { get; private set; }

        protected Kit()
        {
            _componentList = new List<string>();
        }

        public Kit(string name, string sku, long? zrcShopifyId = null) : this()
        {
            Name = name;
            Sku = sku;
        }

        public void AddComponent(string sku)
        {
            _componentList.Add(sku);
        }

        public void SetAllPrices(decimal zrc, decimal zre)
        {
            _zrcPrice = zrc;
            _zrePrice = zre;
        }

        public void SetZrcPrice(decimal zrc)
        {
            _zrcPrice = zrc;
        }
    }
}