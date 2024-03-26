using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_MVC.Areas.Identity.Pages.Account;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Clinique2000_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IClinique2000Services _services { get; set; }

        public APIController(IClinique2000Services service,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _services = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
