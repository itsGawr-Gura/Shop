using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Shop
{
    [Serializable]
    public class Beverages
    {
        public Beverages() { }
        public List<Beverage> BeveragesList { get; set; } = new List<Beverage>();
    }

    
    [Serializable]
    public class Beverage
    {
        [XmlElement("BEVERAGE")]
        [JsonProperty("Product")]
        public string Product { get; set; }
        public string Price { get; set; }
        public int Flavor { get; set; }
        public double Volume { get; set; }
        public int Quantity { get; set; }

        public Beverage() { }
        public Beverage(string price, double volume, int quantity, string product, int flavor)
        {
            this.Flavor = flavor;
            this.Price = price;
            this.Product = product;
            this.Volume = volume;
            this.Quantity = quantity;
        }
    }
}
