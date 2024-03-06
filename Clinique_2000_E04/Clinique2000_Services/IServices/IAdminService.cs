using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinique2000_Services.IServices
{
    public interface IAdminService
    {
        public Task<List<Clinique>> ApprobationCliniqueListe();
        public Task<List<ApplicationUser>> ApprobationUtilisateurListe();
    }
}