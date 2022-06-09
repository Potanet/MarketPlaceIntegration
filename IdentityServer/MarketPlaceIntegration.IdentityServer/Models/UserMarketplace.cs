namespace MarketPlaceIntegration.IdentityServer.Models
{
    public class UserMarketplace
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string MarketplaceId { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Marketplace Marketplace { get; set; }
    }
}
