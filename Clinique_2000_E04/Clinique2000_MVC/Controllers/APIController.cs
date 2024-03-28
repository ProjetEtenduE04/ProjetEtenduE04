using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinique2000_Core.Models;
using Clinique2000_Core.DTO;
using Clinique2000_DataAccess.Data;
using Clinique2000_MVC.Areas.Identity.Pages.Account;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;

namespace Clinique2000_MVC.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly CliniqueDbContext _db;
        public IClinique2000Services _services { get; set; }

        public APIController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, CliniqueDbContext db, IClinique2000Services services)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            db = _db;
            services = _services;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, true, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
            }
            catch (Exception e)
            {
                return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
            }
            


        }

        [HttpPost("transfert")]
        public async Task<IActionResult> Import()
        {

            return Ok();
        }
    }
}
