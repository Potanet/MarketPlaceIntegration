using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{
    public partial class Images
    {
        public string Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public virtual Products Products { get; set; }
    }
}
