﻿using IdentityModel;
using IdentityServer4.Validation;
using MarketPlaceIntegration.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlaceIntegration.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);

            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
                context.Result.CustomResponse = errors;
                return;
            }
            else
            {
                bool passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);
                if (!passwordCheck)
                {
                    var errors = new Dictionary<string, object>();
                    errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
                    context.Result.CustomResponse = errors;
                    return;
                }
            }
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);

        }
    }
}
