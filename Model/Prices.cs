namespace MarketPlaceIntegration.Services.N11.Model;
public class Prices
{
    public int Id { get; set; }
    public Nullable<int> MarketPlaceId { get; set; }
    public Nullable<int> ProductId { get; set; }
    public Nullable<double> Price { get; set; }
    public Nullable<int> Tax { get; set; }
    public Nullable<double> Total { get; set; }
    public bool Status { get; set; }
    public Nullable<System.DateTime> DateTime { get; set; }

    public virtual Products Products { get; set; }
}
