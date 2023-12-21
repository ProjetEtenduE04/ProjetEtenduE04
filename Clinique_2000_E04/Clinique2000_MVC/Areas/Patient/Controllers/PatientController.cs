using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using System.Security.Claims;

namespace Clinique2000_MVC.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {
        private readonly IServiceBaseAsync<Clinique2000_Core.Models.Patient> _serviceBase;
        private readonly IAuthenGoogleService _authenGoogleService;

        public PatientController(IServiceBaseAsync<Clinique2000_Core.Models.Patient> serviceBase, IAuthenGoogleService authenGoogleService)
        {
            _serviceBase = serviceBase;
            _authenGoogleService = authenGoogleService;
        }

       

        public IActionResult Index()
        {
            //return View(); 
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            return View("~/Areas/Patient/Views/Patient/Index.cshtml");
        }

        public async Task Login()
        {
            await _authenGoogleService.LoginAsync();
        }

        public async Task<IActionResult> GoogleReponse()
        {
            return await _authenGoogleService.HandleGoogleResponseAsync();
        }

        public async Task<IActionResult> Logout()
        {
            await _authenGoogleService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
