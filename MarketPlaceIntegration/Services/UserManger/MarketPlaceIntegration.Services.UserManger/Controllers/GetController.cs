using MarketPlaceIntegration.Services.UserManger.IServices;
using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace MarketPlaceIntegration.Services.UserManger.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetController : CustomBaseController
    {
        private readonly IMarketplaceService marketplaceService;
        private readonly IUserStoreService userStoreService;
        private readonly IMarketplaceLoginService marketplaceLoginService;

        public GetController(IMarketplaceService marketplaceService,
                                IUserStoreService userStoreService,
                                IMarketplaceLoginService marketplaceLoginService)
        {
            this.marketplaceService = marketplaceService;
            this.userStoreService = userStoreService;
            this.marketplaceLoginService = marketplaceLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> AllMarketplace()
        {
            var response = await marketplaceService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        public async Task<IActionResult> UserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            string id = userIdClaim.Value;

            return CreateActionResultInstance(Response<string>.Success(id, 200));
        }

        [HttpGet]
        public async Task<IActionResult> UserStore()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            var response = await userStoreService.GetByUserIdAsync(userIdClaim.Value);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        public async Task<IActionResult> AllMarketplaceLogin()
        {
            var response = await marketplaceLoginService.GetAllAsync();

            return CreateActionResultInstance(response);
        }
    }
}
