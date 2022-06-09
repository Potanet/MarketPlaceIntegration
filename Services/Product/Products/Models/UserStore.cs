using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MarketPlaceIntegration.Services.Products.Models
{
    public class UserStore
    {
        public UserStore()
        {
            this.MarketplaceLogin = new List<MarketplaceLogin>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public virtual List<MarketplaceLogin> MarketplaceLogin { get; set; }
    }
}
