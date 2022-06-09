using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Models
{
    public class SharedMarketplaceLogin
    {
        //public SharedMarketplaceLogin()
        //{
            //this.AbleToInvoice = new HashSet<AbleToInvoice>();
            //this.ApiLog = new HashSet<ApiLog>();
            //this.Order = new HashSet<Order>();
        //}

        //[BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        public string MaeketPlaceId { get; set; }
        public string Key { get; set; }
        public string Vlaue { get; set; }
        //public virtual SharedMarketPlace MarketPlace { get; set; }



        //public virtual ICollection<AbleToInvoice> AbleToInvoice { get; set; }

        //public virtual ICollection<ApiLog> ApiLog { get; set; }
        //public virtual User User { get; set; }

        //public virtual ICollection<Order> Order { get; set; }
    }
}
