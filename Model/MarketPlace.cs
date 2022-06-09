namespace MarketPlaceIntegration.Services.N11.Model
{
    public class MarketPlace
    {
        public MarketPlace()
        {
            this.Attributes = new HashSet<Attributes>();
            this.MarketPlaceProduct = new HashSet<MarketPlaceProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Attributes> Attributes { get; set; }
        public virtual ICollection<MarketPlaceProduct> MarketPlaceProduct { get; set; }
    }
}
