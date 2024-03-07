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
                .Where(c => c.EstApprouvee == false)
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
            clinique.EstApprouvee = true;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RefuserCliniqueParID(int id)
        {
            Clinique clinique = await _context.Cliniques.FindAsync(id);
            
            if (clinique == null)
            {
                throw new ArgumentException("Invalid clinique ID");
            }

            clinique.DateModification = DateTime.Now;

            CliniqueRefusee cliniqueRefusee = new CliniqueRefusee();

            //cliniqueRefusee.CliniqueRefuseeID = clinique.CliniqueID;
            cliniqueRefusee.NomClinique = clinique.NomClinique;
            cliniqueRefusee.Courriel = clinique.Courriel;
            cliniqueRefusee.HeureOuverture = clinique.HeureOuverture;
            cliniqueRefusee.HeureFermeture = clinique.HeureFermeture;
            cliniqueRefusee.TempsMoyenConsultation = clinique.TempsMoyenConsultation;
            cliniqueRefusee.NumTelephone = clinique.NumTelephone;
            cliniqueRefusee.EstActive = clinique.EstActive;
            cliniqueRefusee.DateCreation = clinique.DateCreation;
            cliniqueRefusee.DateModification = clinique.DateModification;
            cliniqueRefusee.AdresseID = clinique.AdresseID;
            cliniqueRefusee.CreateurID = clinique.CreateurID;
            cliniqueRefusee.EstApprouvee = clinique.EstApprouvee;

            _context.Cliniques.Remove(clinique);
            _context.CliniqueRefusees.Add(cliniqueRefusee); // Add the CliniqueRefusee object to the context
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 544)
                {
                    // Handle the error when IDENTITY_INSERT is set to OFF
                    // Set IDENTITY_INSERT to ON for CliniqueRefusees table
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT CliniqueRefusees ON");
                    int result = await _context.SaveChangesAsync();
                    // Set IDENTITY_INSERT back to OFF for CliniqueRefusees table
                    await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT CliniqueRefusees OFF");
                    return result;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<int> ApprobationUtilisateurParID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RefuserUtilisateurParID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CliniqueRefusee>> ListeCliniquesRefusees()
        {
            List<CliniqueRefusee> cliniquesRefusees = await _context.CliniqueRefusees
                .ToListAsync();

            return cliniquesRefusees;
        }
    }
}
