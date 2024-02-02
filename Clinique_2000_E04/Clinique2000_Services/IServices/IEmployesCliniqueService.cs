using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;

namespace Clinique2000_Services.IServices
{
    public interface IEmployesCliniqueService:IServiceBaseAsync<EmployesClinique>
    {
        Task <IList<Clinique>>ObtenirCliniquesDeLEmploye(EmployesClinique employesClinique);
       // Task<EmployesCliniqueVM> obtenirDonnees(EmployesClinique employesClinique);
        Task<ListeAttente> ObtenirListeAttenteDeLaClinqueDeLEmploye(int cliniqueID);
        Task<Clinique> SelectionnerClinique(int? cliniqueID);
    }
}