using MarketPlaceIntegration.Services.Products.IServices;
using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MarketPlaceIntegration.Services.Products.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : CustomBaseController
    {
        //private readonly IUserStoreService userStoreService;
        private readonly IMarketplaceLoginService marketplaceLoginService;

        public PostController(/*IUserStoreService userStoreService,*/
                              IMarketplaceLoginService marketplaceLoginService)
        {
            //this.userStoreService = userStoreService;
            this.marketplaceLoginService = marketplaceLoginService;
        }

        [HttpPost]
        public async Task<IActionResult> MarketplaceLogin(MarketplaceLoginDto marketplaceLoginDto)
        {
            var response = await marketplaceLoginService.CreateAsync(marketplaceLoginDto);
            return CreateActionResultInstance(response);
        }

    }
}
