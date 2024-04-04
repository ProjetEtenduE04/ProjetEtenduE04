using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Google;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class APIKeyService : IAPIKeyService
    {
        private readonly CliniqueDbContext _context;

        public APIKeyService(CliniqueDbContext context)
        {
            _context = context;
        }

        public async Task<ApiKey> GenerateApiKeyAsync(string userId)
        {
            // Check if the user already has an API key
            var existingApiKey = await _context.ApiKeys.FirstOrDefaultAsync(a => a.UserId == userId);
            if (existingApiKey != null)
            {
                // If the user already has an API key, return the existing key
                return existingApiKey;
            }
            else
            {
                // Generate a new API key
                var apiKey = GenerateSecureApiKey();
                var apiKeyRecord = new ApiKey
                {
                    Key = apiKey,
                    UserId = userId,
                    CreationDate = DateTime.UtcNow
                };

                _context.ApiKeys.Add(apiKeyRecord);
                await _context.SaveChangesAsync();

                return apiKeyRecord;
            }
        }

        public async Task<IEnumerable<ApiKey>> GetApiKeysAsync(string userId)
        {
            return await _context.ApiKeys.Where(x => x.UserId == userId).ToListAsync();
        }

        // Since there's no IsRevoked property, I've removed the ValidateApiKeyAsync method
        // and the RevokeApiKeyAsync method from this version.

        private string GenerateSecureApiKey()
        {
            // Simple example of API key generation
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var apiKeyBytes = new byte[32]; // 256 bits
                randomNumberGenerator.GetBytes(apiKeyBytes);
                return Convert.ToBase64String(apiKeyBytes);
            }
        }


        public async Task<bool> ValidateApiKeyAsync(string apiKey)
        {
            // Check if the API key exists and is valid in the database
            return await _context.ApiKeys.AnyAsync(x => x.Key == apiKey);
        }





    }
}
