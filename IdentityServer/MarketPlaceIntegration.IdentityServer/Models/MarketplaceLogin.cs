
namespace MarketPlaceIntegration.IdentityServer.Models
{
    public class MarketplaceLogin
    {
        public string Id { get; set; }
        public string UserMarketplaceId { get; set; }
        public string Key { get; set; }
        public string Vlaue { get; set; }

        public virtual UserMarketplace UserMarketplace { get; set; }
    }
}
