using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{

    public partial class Prices
    {
        public string Id { get; set; }
        public Nullable<int> MarketPlaceId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Tax { get; set; }
        public Nullable<double> Total { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }

        public virtual Products Products { get; set; }
    }
}
