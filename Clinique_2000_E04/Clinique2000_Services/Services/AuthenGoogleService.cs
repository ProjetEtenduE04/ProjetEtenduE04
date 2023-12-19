using Clinique2000_Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Clinique2000_Services.Services
{
    public class AuthenGoogleService : IAuthenGoogleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuthenGoogleService> _logger;

        public AuthenGoogleService(IHttpContextAccessor httpContextAccessor, ILogger<AuthenGoogleService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task LoginAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                await httpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                    new AuthenticationProperties
                    {
                        RedirectUri = httpContext.Request.PathBase + "/Patient/GoogleReponse"
                    });
            }
        }

        public async Task<IActionResult> HandleGoogleResponseAsync()
        {
            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result?.Succeeded ?? false)
            {
                var claims = result.Principal.Identities.FirstOrDefault()?.Claims?.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

                _logger.LogInformation($"User authenticated successfully. Claims: {JsonConvert.SerializeObject(claims)}");

                return new RedirectToActionResult("Index", "Home", null);
            }
            else
            {
                _logger.LogError("Authentication failed.");

                return new RedirectToActionResult("Index", "Home", null);
            }
        }

        public async Task LogoutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
