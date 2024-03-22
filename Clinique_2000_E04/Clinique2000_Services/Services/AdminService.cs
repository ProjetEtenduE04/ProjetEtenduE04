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
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Data.SqlClient;
using Clinique2000_Utility.Enum;

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
            List<Clinique> cliniques = await _context.Cliniques
                .Where(c => c.Statut == StatutApprobationEnum.EnAttente)
                .ToListAsync();

            return cliniques;
        }

        public async Task<List<ApplicationUser>> ApprobationUtilisateurListe()
        {
            List<ApplicationUser> utilisateurs = await _context.ApplicationUser
                .ToListAsync();

            return utilisateurs;
        }

        public async Task<int> ApprobationCliniqueParID(int id)
        {
            Clinique clinique = await _context.Cliniques.FindAsync(id);
            clinique.Statut = StatutApprobationEnum.Approuve;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RefuserCliniqueParID(int id)
        {
            Clinique clinique = await _context.Cliniques.FindAsync(id);
            clinique.Statut = StatutApprobationEnum.Refuse;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ApprobationUtilisateurParID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RefuserUtilisateurParID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Clinique>> ListeCliniquesRefusees()
        {
            List<Clinique> cliniquesRefusees = await _context.Cliniques
                .Where(c => c.Statut == StatutApprobationEnum.Refuse)
                .ToListAsync();

            return cliniquesRefusees;
        }
    }
}
