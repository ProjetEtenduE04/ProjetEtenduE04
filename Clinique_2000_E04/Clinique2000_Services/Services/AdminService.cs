using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly CliniqueDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminService(CliniqueDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Clinique>> ApprobationCliniqueListe()
        {
            List<Clinique> inactiveCliniques = await _context.Cliniques
                .Where(c => c.EstActive == false)
                .ToListAsync();

            return inactiveCliniques;
        }

        public async Task<List<ApplicationUser>> ApprobationUtilisateurListe()
        {
            throw new NotImplementedException();
        }
    }
}
