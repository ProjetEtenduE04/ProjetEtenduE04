using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class ApiKeyAuthenticationService : IApiKeyAuthenticationService
    {
        private readonly IAPIKeyService _apiKeyService;

        public ApiKeyAuthenticationService(IAPIKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<bool> AuthenticateAsync(HttpContext context)
        {
            // Extract API key from request header
            string? apiKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

            // Validate API key
            if (!string.IsNullOrEmpty(apiKey) && await _apiKeyService.ValidateApiKeyAsync(apiKey))
            {
                // API key is valid
                return true;
            }

            // API key is invalid or missing
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Invalid API key");
            return false;
        }
    }
}