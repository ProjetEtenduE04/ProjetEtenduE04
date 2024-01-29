using Clinique2000_Core.Models;
using Clinique2000_MVC.Models;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Clinique2000_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IClinique2000Services _services { get; set; }
        public HomeController(ILogger<HomeController> logger, IClinique2000Services services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
           
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return View();
                }

                var estPatient = await _services.patient.GetPatientParUserIdAsync(userId);
                if (estPatient == null)
                {
                    return View();
                }

                return View(estPatient);
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
        public IActionResult Create()
        {
            return View();
        }
    }
}