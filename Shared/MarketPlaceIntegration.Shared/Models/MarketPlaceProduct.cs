using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{
    public partial class MarketPlaceProduct
    {
        public string Id { get; set; }
        public Nullable<int> MarketPlaceId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<double> PriceId { get; set; }
        public Nullable<double> ListPrice { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Json { get; set; }

        public virtual SharedMarketPlace MarketPlace { get; set; }
        public virtual Products Products { get; set; }
    }
}
