using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MarketPlaceIntegration.Services.UserManger.Models
{
    public class Marketplace
    {
        public Marketplace()
        {
            this.MarketplaceLogin = new List<MarketplaceLogin>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<MarketplaceLogin> MarketplaceLogin { get; set; }
    }
}
