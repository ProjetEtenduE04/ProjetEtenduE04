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

    public class APIService : IAPIService
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


        [NonAction]
        public async Task<bool> UserPossedeUneCleAPI(string? userName)
        {
            var appuser1 =await _userManager.FindByNameAsync(userName);

            if (_db.ApiKeys.Any(x => x.UserId == appuser1.Id))
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
