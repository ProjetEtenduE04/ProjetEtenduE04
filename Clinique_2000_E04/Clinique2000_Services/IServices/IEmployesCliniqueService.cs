using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;

namespace Clinique2000_Services.IServices
{
    public interface IEmployesCliniqueService:IServiceBaseAsync<EmployesClinique>
    {
        Task<IList<Clinique>> ObtenirCliniquesDeLEmploye(EmployesClinique employesClinique);
        Task<Clinique> SelectionnerClinique(int? cliniqueID);
        Task<ListeAttente> ObtenirListeAttenteDeLaClinqueDeLEmploye(int cliniqueID);
        Task<EmployesClinique> GetEmployeUserID(string userEmail, string userId);
        Task<EmployesClinique> VerifierSiUserAuthEstEmploye(string userEmail);
        Task<List<EmployesClinique>> GetEmployeSelonLaListeClinique(IEnumerable<Clinique> listClinique);
        Task<bool> EmployeCliniqueEstReceptionniste(EmployesClinique employeclinique);
    }
}