namespace MarketPlaceIntegration.Services.N11.Model
{
    public class Images
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public virtual Products Products { get; set; }
    }
}
