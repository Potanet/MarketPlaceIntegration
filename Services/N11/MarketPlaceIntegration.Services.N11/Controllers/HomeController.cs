using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceIntegration.Services.N11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : CustomBaseController
    {
        ISharedIdentityService _sharedIdentityService;

        public HomeController(ISharedIdentityService sharedIdentityService)
        {
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string str = _sharedIdentityService.GetUserId;
            return Ok(str);
        }
    }
}
