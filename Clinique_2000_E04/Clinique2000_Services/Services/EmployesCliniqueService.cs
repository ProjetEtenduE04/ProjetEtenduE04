using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class EmployesCliniqueService : ServiceBaseAsync<EmployesClinique>, IEmployesCliniqueService
    {
        private readonly CliniqueDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public EmployesCliniqueService(CliniqueDbContext context, UserManager<IdentityUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;

        }


        public async Task<EmployesCliniqueVM> obtenirDonnees(EmployesClinique employesClinique)
        {
            Clinique clinique = await SelectionnerClinique(employesClinique.CliniqueID);
            ListeAttente listeAttente = await ObtenirListeAttenteDeLaClinqueDeLEmploye(employesClinique.CliniqueID);


            var employesClinqueVM = new EmployesCliniqueVM()
            {
                EmployesClinique = employesClinique,
                MesCliniques = _context.Cliniques.Where(c => c.CliniqueID == employesClinique.CliniqueID).ToList(),
                ListeAttente = listeAttente,

            };

            return employesClinqueVM;
        }



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
            var listeAttente = await _context.ListeAttentes.Where(l => l.CliniqueID == cliniqueID /*&& l.IsOuverte==true*/).Include(l => l.PlagesHoraires).Include(x=>x.Consultations).FirstOrDefaultAsync();
            return listeAttente;
        }




        public async Task<EmployesClinique> GetEmployeUserID(string userEmail, string userId)
        {

            EmployesClinique employeUser = await _context.EmployesClinique.Where(e => e.EmployeCliniqueCourriel == userEmail).FirstOrDefaultAsync();

            if (employeUser!= null)
            {
                employeUser.UserID = userId;
                 await _context.SaveChangesAsync();
            }

            return employeUser;
        }

        /// <summary>
        /// V�rifie si l'utilisateur authentifi� est un employ� de la clinique.
        /// </summary>
        /// <param name="userEmail">L'adresse e-mail de l'utilisateur.</param>
        /// <returns>L'objet EmployesClinique correspondant si trouv�, sinon null.</returns>
        public async Task<EmployesClinique> VerifierSiUserAuthEstEmploye(string userEmail)
        {
            EmployesClinique employeUser = await _context.EmployesClinique.Where(e => e.EmployeCliniqueCourriel == userEmail).FirstOrDefaultAsync();
            if (employeUser != null)
            {
                return employeUser;
            }
            return null;
        }


        /// <summary>
        /// Obtient la liste des employ�s selon la liste des cliniques fournies.
        /// </summary>
        /// <param name="listClinique">La liste des cliniques.</param>
        /// <returns>La liste des employ�s de toutes les cliniques fournies.</returns>
        public async Task<List<EmployesClinique>> GetEmployeSelonLaListeClinique(IEnumerable<Clinique> listClinique)
        {
            var employesClinique = new List<EmployesClinique>();
            foreach (var clinique in listClinique)
            {
                var employesListe = await _context.EmployesClinique.Where(e => e.CliniqueID == clinique.CliniqueID).ToListAsync();
                employesClinique.AddRange(employesListe);
            }
            return employesClinique;
        }


        public async Task<bool> EmployeCliniqueEstReceptionniste(EmployesClinique employeclinique)
         {
          
            if (employeclinique.EmployeCliniquePosition==EmployeCliniquePosition.Receptionniste)
                return true;
            else
                return false;
        }

      

    }
}
