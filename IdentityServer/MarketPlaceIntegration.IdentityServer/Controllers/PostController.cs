using MarketPlaceIntegration.IdentityServer.Dtos;
using MarketPlaceIntegration.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MarketPlaceIntegration.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
            };

            var result = await _userManager.CreateAsync(user, signupDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
