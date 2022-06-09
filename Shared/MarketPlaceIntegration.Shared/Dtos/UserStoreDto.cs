using System.Collections.Generic;

namespace MarketPlaceIntegration.Shared.Dtos
{
    public class UserStoreDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<MarketplaceLoginDto> MarketplaceLoginDto { get; set; }
    }
}
