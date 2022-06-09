using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{

    public partial class MarketPlacesCategory
    {
        public string Id { get; set; }
        public Nullable<int> CategoriId { get; set; }
        public Nullable<int> MarketPalceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string MarketPlacesCategoryId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Json { get; set; }

        public virtual Category Category { get; set; }
        public virtual SharedMarketPlace MarketPlace { get; set; }
    }
}
