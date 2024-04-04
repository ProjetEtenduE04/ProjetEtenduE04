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

        public APIService(UserManager<IdentityUser> userManager, CliniqueDbContext db)
        {
            _userManager = userManager;
            _db = db;
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

    }
}
