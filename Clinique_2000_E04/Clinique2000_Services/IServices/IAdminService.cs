using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinique2000_Services.IServices
{
    public interface IAdminService
    {
        public Task<List<Clinique>> ApprobationCliniqueListe();
        public Task<List<ApplicationUser>> ApprobationUtilisateurListe();
        public Task<int> ApprobationCliniqueParID(int id);
        public Task<int> RefuserCliniqueParID(int id);
        public Task<int> ApprobationUtilisateurParID(int id);
        public Task<int> RefuserUtilisateurParID(int id);
        public Task<List<CliniqueRefusee>> ListeCliniquesRefusees();
    }
}