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
        public IClinique2000Services _services { get; set; }

        public HomeController(
            ILogger<HomeController> logger,
            IClinique2000Services service)
        {
            _logger = logger;
            _services = service;
        }

        public async Task Login()
        {
            await _services.authenGoogle.LoginAsync();
        }

        //public async Task<IActionResult> GoogleReponse()
        //{
        //    return await _authenGoogleService.HandleGoogleResponseAsync();
        //}

        public async Task<IActionResult> Logout()
        {
            await _services.authenGoogle.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: HomeController
        public IActionResult Index2()
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
