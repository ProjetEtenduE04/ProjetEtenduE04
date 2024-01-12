using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;

namespace Clinique2000_Services.Services
{
    public class AuthenGoogleService : IAuthenGoogleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuthenGoogleService> _logger;
        private readonly IPatientService _patientService;

        public AuthenGoogleService(IHttpContextAccessor httpContextAccessor, ILogger<AuthenGoogleService> logger
            , IPatientService patientService)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _patientService = patientService;
        }

        public async Task LoginAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                await httpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                    new AuthenticationProperties
                    {
                        RedirectUri = httpContext.Request.PathBase + "Patients/Home/GoogleReponse"
                    });
            }
        }

        //public async Task<IActionResult> HandleGoogleResponseAsync()
        //{
        //    var result = await _httpContextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    if (result?.Succeeded ?? false)
        //    {
        //        var claims = result.Principal.Identities.FirstOrDefault()?.Claims?.Select(claim => new
        //        {
        //            claim.Issuer,
        //            claim.OriginalIssuer,
        //            claim.Type,
        //            claim.Value
        //        });
        //        //var emailClaim = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
        //        //string courriel = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
        //        string courriel = await GetUserEmailAsync();

        //        _logger.LogInformation($"User authenticated successfully. Claims: {JsonConvert.SerializeObject(claims)}");

        //        if (!string.IsNullOrEmpty(courriel))
        //        {
        //            var patientExists = await _patientService.VerifierExistencePatientParEmailAsync(courriel);

        //            _logger.LogInformation($"User authenticated successfully with email: {courriel}. Patient exists : {patientExists}");
        //            if (!patientExists)
        //                return new RedirectToActionResult("Create", "Patients", null);
        //        }
        //        return new RedirectToActionResult("Index", "Patients", null);
        //    }
        //    else
        //    {
        //        _logger.LogError("Authentication failed.");

        //        return new RedirectToActionResult("Index", "Home", null);
        //    }
        //}

        public async Task LogoutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }

        ///// <summary>
        ///// Récupère le courriel de l'utilisateur authentifié.
        ///// </summary>
        ///// <returns>Le courriel de l'utilisateur ou null si elle n'est pas disponible.</returns>
        //public async Task<string> GetUserEmailAsync()
        //{
        //    string courrielClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        //    return courrielClaim;
        //}

        ///// <summary>
        ///// Récupère l'identifiant Google de l'utilisateur authentifié.
        ///// </summary>
        ///// <returns>GoogleNameIdentifier ou null s'il n'est pas disponible.</returns>
        //public async Task<string> GetUserNameIdentifierAsync()
        //{
        //    var nameIdentifierClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    return nameIdentifierClaim;
        //}

        ///// <summary>
        ///// Récupère la date de naissance de l'utilisateur authentifié.
        ///// </summary>
        ///// <returns>La date de naissance de l'utilisateur ou une valeur par défaut (01/01/1900)</returns>
        //public async Task<DateTime?> GetUserDateOfBirthAsync()
        //{
        //    var dateOfBirthClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.DateOfBirth)?.Value;
        //    if (dateOfBirthClaim != null && DateTime.TryParse(dateOfBirthClaim, out var dateOfBirth))
        //    {
        //        return dateOfBirth;
        //    }
        //    return new DateTime(1900, 1, 1); // valeur par défaut
        //}

        ///// <summary>
        /////  Récupère les données de l'utilisateur authentifié, telles que l'adresse e-mail, l'identifiant Google et la date de naissance.
        ///// </summary>
        ///// <returns>Un objet Patient représentant les données de l'utilisateur authentifié.</returns>
        //public async Task<Patient> GetAuthUserDataAsync()
        //{
        //    var UilisateurConnecte = new Patient
        //    {
        //        Courriel = await GetUserEmailAsync(),
        //        GoogleNameIdentifier = await GetUserNameIdentifierAsync(),
        //        DateDeNaissance = (DateTime)await GetUserDateOfBirthAsync()
        //    };
        //    return UilisateurConnecte;
        //}

    }
}
