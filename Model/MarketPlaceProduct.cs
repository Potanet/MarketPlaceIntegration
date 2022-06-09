namespace MarketPlaceIntegration.Services.N11.Model
{
    public class MarketPlaceProduct
    {
        public int Id { get; set; }
        public Nullable<int> MarketPlaceId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<double> PriceId { get; set; }
        public Nullable<double> ListPrice { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Json { get; set; }

        public virtual MarketPlace MarketPlace { get; set; }
        public virtual Products Products { get; set; }
    }
}
