using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceIntegration.Shared.IServices
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }
    }
}
