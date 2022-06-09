using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{

    public partial class Attributes
    {
        public string Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> MarketPlaceId { get; set; }
        public string AttributeId { get; set; }
        public string Keys { get; set; }
        public string Value { get; set; }

        public virtual SharedMarketPlace MarketPlace { get; set; }
        public virtual Products Products { get; set; }
    }
}
