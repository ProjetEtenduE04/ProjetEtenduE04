using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_Services.IServices
{
    public interface IAuthenGoogleService
    {
        Task LoginAsync();
        Task<IActionResult> HandleGoogleResponseAsync();
        Task LogoutAsync();
        Task<string> GetUserEmailAsync();
        Task<string> GetUserNameIdentifierAsync();
        Task<DateTime?> GetUserDateOfBirthAsync();
        Task<Patient> GetAuthUserDataAsync();
    }
}
