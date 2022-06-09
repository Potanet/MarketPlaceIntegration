namespace MarketPlaceIntegration.Shared.Settings
{
    public interface IDatabaseSettings
    {
        public string UserStoreCollectionName { get; set; }
        public string MarketplaceCollectionName { get; set; }
        public string MarketplaceLoginCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
