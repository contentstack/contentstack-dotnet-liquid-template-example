using System;
using Newtonsoft.Json;
using Contentstack.Core.Models;
using System.Collections.Generic;

namespace contentstack_liquid_template_example.Models
{
    public class ProductModel
    {

        public string Title { get; set; }
        public string Uid { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "featured_image")]
        public IEnumerable<Asset> FeaturedImage { get; set; }
        public double Price { get; set; }
        [JsonProperty(PropertyName = "offer_price")]
        public double OfferPrice { get; set; }
        [JsonProperty(PropertyName = "in_stock")]
        public bool InStock { get; set; }

        public ProductModel()
        {
        }
    }
}
