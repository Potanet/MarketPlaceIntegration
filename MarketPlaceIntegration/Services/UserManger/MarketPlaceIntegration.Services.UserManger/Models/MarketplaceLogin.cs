using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MarketPlaceIntegration.Services.UserManger.Models
{
    public class MarketplaceLogin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MarketplaceId { get; set; }
        public string UserStoreId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        [BsonIgnore]
        public virtual UserStore UserStore { get; set; }
        public virtual Marketplace Marketplace { get; set; }
    }
}
