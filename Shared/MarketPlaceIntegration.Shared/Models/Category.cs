using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.MarketPlacesCategory = new HashSet<MarketPlacesCategory>();
            this.Products = new HashSet<Products>();
        }

        public string Id { get; set; }
        public Nullable<int> SubId { get; set; }
        public string Titile { get; set; }
        public string Code { get; set; }

        public virtual ICollection<MarketPlacesCategory> MarketPlacesCategory { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
