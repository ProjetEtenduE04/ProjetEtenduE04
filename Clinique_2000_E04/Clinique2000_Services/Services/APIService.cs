using Clinique2000_Core.DTO;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIService : ControllerBase, IAPIService
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly CliniqueDbContext _db;
        readonly SignInManager<IdentityUser> _signInManager;

        public APIService(UserManager<IdentityUser> userManager, CliniqueDbContext db, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
        }

        [HttpPost()]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, true, false);
            if (result.Succeeded)
            {
                return Ok(); 
            }
            return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
        }


        public async Task<bool> UserPossedeUneCleAPI()
        {
            var user1 = User.Identity.Name;
            var appuser =await _db.ApplicationUser.Where(x=>x.UserName.ToUpper()==user1.ToUpper()).FirstOrDefaultAsync();

            if (_db.ApiKeys.Any(x => x.UserId == appuser.Id))
                return true;
            else
                return false;
        }

        //[HttpPost]
        //public async Task<bool> VerifierLogin(LoginDTO loginDTO)
        //{
        //    var user = await _userManager.FindByNameAsync(loginDTO.Username);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
        //    if (result.Succeeded)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


    }
}
