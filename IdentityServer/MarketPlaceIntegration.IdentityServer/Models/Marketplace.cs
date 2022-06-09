using System.Collections.Generic;

namespace MarketPlaceIntegration.IdentityServer.Models
{
    public class Marketplace
    {
        public Marketplace()
        {
            this.MarketplaceLogin = new List<MarketplaceLogin>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<MarketplaceLogin> MarketplaceLogin { get; set; }
    }
}
