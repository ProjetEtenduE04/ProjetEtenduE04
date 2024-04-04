using AutoMapper;
using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Clinique2000_MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class APImvcController : Controller
    {
        private readonly Mapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IClinique2000Services _services;
        private readonly CliniqueDbContext _context;


        public APImvcController(
                       UserManager<IdentityUser> userManager,
                       IClinique2000Services services,
                       CliniqueDbContext context
                       )
        {
            _userManager = userManager;
            _services = services;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GenerateApiKeyGET()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var apiKey = await _services.apiKey.GenerateApiKeyAsync(user.Id);
                return View("GenerateApiKeyGET", apiKey.Key);
            }
            return View("Error"); 
        }







    }
}
