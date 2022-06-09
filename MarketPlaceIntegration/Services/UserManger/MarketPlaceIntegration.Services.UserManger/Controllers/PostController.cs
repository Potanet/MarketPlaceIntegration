using MarketPlaceIntegration.Services.UserManger.IServices;
using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MarketPlaceIntegration.Services.UserManger.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : CustomBaseController
    {
        private readonly IMarketplaceService marketplaceService;
        private readonly IUserStoreService userStoreService;
        private readonly IMarketplaceLoginService marketplaceLoginService;

        public PostController(IMarketplaceService marketplaceService,
                              IUserStoreService userStoreService,
                              IMarketplaceLoginService marketplaceLoginService)
        {
            this.marketplaceService = marketplaceService;
            this.userStoreService = userStoreService;
            this.marketplaceLoginService = marketplaceLoginService;
        }

        [HttpPost]
        public async Task<IActionResult> Marketplace(MarketplaceDto marketplaceDto)
        {
            var response = await marketplaceService.CreateAsync(marketplaceDto);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> UserStore(UserStoreDto userStoreDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            var response = await userStoreService.CreateAsync(userStoreDto, userIdClaim.Value);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> MarketplaceLogin(MarketplaceLoginDto marketplaceLoginDto)
        {
            var response = await marketplaceLoginService.CreateAsync(marketplaceLoginDto);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> MarketplaceLoginRang(List<MarketplaceLoginDto> marketplaceLoginDtos)
        {
            var response = await marketplaceLoginService.CreateRangeAsync(marketplaceLoginDtos);

            return CreateActionResultInstance(response);
        }
    }
}