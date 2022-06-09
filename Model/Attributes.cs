namespace MarketPlaceIntegration.Services.N11.Model
{
    public class Attributes
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> MarketPlaceId { get; set; }
        public string AttributeId { get; set; }
        public string Keys { get; set; }
        public string Value { get; set; }

        public virtual MarketPlace MarketPlace { get; set; }
        public virtual Products Products { get; set; }

    }
}
