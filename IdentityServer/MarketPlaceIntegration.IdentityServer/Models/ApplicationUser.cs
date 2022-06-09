using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MarketPlaceIntegration.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string RepresentativeName { get; set; }
        public string Tel { get; set; }
        public string XfaturaUserName { get; set; }
        public string XfaturaPassword { get; set; }
        public bool Status { get; set; }
        public List<UserMarketplace> UserMarketplaces { get; set; }
    }
}
