using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.Messages
{
    public class CreateMarketplaceLoginMessageCommand
    {
        public string MarketplaceId { get; set; }
        public string UserStoreId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; } 
    }
}
