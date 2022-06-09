using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{
    public partial class Products
    {
        public Products()
        {
            this.Attributes = new HashSet<Attributes>();
            this.Images = new HashSet<Images>();
            this.MarketPlaceProduct = new HashSet<MarketPlaceProduct>();
            this.Prices = new HashSet<Prices>();
        }

        public string Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public Nullable<double> ListPrice { get; set; }
        public Nullable<double> SalePrice { get; set; }


        public virtual ICollection<Attributes> Attributes { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Images> Images { get; set; }

        public virtual ICollection<MarketPlaceProduct> MarketPlaceProduct { get; set; }

        public virtual ICollection<Prices> Prices { get; set; }
    }
}
