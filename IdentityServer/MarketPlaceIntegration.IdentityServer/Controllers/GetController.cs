using MarketPlaceIntegration.IdentityServer.Models;
using MarketPlaceIntegration.Shared.ControllerBases;
using MarketPlaceIntegration.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MarketPlaceIntegration.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public GetController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserById()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

    }
}
