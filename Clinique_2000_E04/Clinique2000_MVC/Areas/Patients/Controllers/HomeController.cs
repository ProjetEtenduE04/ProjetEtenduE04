using Clinique2000_Core.Models;
using Clinique2000_MVC.Models;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinique2000_MVC.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IServiceBaseAsync<Patient> _serviceBase;
        private readonly IAuthenGoogleService _authenGoogleService;

        public HomeController(ILogger<HomeController> logger, IServiceBaseAsync<Patient> serviceBase, IAuthenGoogleService authenGoogleService)
        {
            _serviceBase = serviceBase;
            _authenGoogleService = authenGoogleService;
            _logger = logger;
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

        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
