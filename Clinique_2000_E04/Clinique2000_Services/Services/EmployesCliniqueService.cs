using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class EmployesCliniqueService : ServiceBaseAsync<EmployesClinique>, IEmployesCliniqueService
    {
        private readonly CliniqueDbContext _context;

        public EmployesCliniqueService(CliniqueDbContext context) : base(context)
        {
            _context = context;

        }


        //public async Task<EmployesCliniqueVM> obtenirDonnees(EmployesClinique employesClinique)
        //{
        //    Clinique clinique= await SelectionnerClinique(employesClinique.CliniqueID);
        //    ListeAttente listeAttente = await ObtenirListeAttenteDeLaClinqueDeLEmploye(employesClinique.CliniqueID);
            

        //    var employesClinqueVM = new EmployesCliniqueVM()
        //    {
        //        EmployesClinique = employesClinique,
        //        MesCliniques = _context.Cliniques.Where(c => c.CliniqueID == employesClinique.CliniqueID).ToList(),
        //        ListeAttente = listeAttente,
                
        //    };
            
        //    return employesClinqueVM;
        //}

        

        public async Task<IList<Clinique>>ObtenirCliniquesDeLEmploye(EmployesClinique employesClinique)
        {
            var MesCliniques = _context.Cliniques.Where(c => c.CliniqueID == employesClinique.CliniqueID).ToList();
            return MesCliniques;
        }

        public async Task<Clinique> SelectionnerClinique(int? cliniqueID)
        {
            Clinique clinique = await _context.Cliniques.FindAsync(cliniqueID);
            if (clinique != null)
            {
                return clinique;
            }

            return null;
        }

        public async Task<ListeAttente> ObtenirListeAttenteDeLaClinqueDeLEmploye(int cliniqueID)
        {
            var listeAttente = await _context.ListeAttentes.Where(l => l.CliniqueID == cliniqueID && l.IsOuverte==true).Include(l => l.PlagesHoraires).Include(x=>x.Consultations).FirstOrDefaultAsync();
            return listeAttente;
        }




        public async Task<EmployesClinique> GetEmployeUserID( string userEmail, string userId)
        {


            EmployesClinique employeUser = await _context.EmployesClinique.FirstAsync(e => e.EmployeCliniqueCourriel == userEmail);

            if (employeUser!= null)
            {
                employeUser.UserID = userId;
                 await _context.SaveChangesAsync();
            }

            return employeUser;
        }




       
    }
}
