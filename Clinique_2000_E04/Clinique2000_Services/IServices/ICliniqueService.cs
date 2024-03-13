using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface ICliniqueService : IServiceBaseAsync<Clinique>
    {
        Task<Clinique?> ObtenirCliniqueParNomAsync(string nomClinique);
        Task<Clinique?> ObtenirCliniqueParCourrielAsync(string courriel);
        Task<bool> VerifierExistenceCliniqueParNomAsync(string nomClinique);
        Task<bool> VerifierExistenceCliniqueParCourrielAsync(string courriel);
        Task<bool> VerifierExistenceCliniqueParIdAsync(int? id);
        Task<bool> VerifierSiHeureOuvertureValide(Clinique clinique);
        Task ListeDeVerificationClinique(Clinique clinique);
        Task ListeDeVerificationCliniqueEdit(Clinique clinique);
        Task<Clinique> EnregistrerCliniqueAsync(CliniqueAdresseVM viewModel);
        Task EditerCliniqueAsync(CliniqueAdresseVM viewModel);
        Task<IList<ListeAttente>> GetListeAttentePourPatientAsync(int clinicId, bool? isOuvert);
        Task<IEnumerable<CliniqueDistanceVM>> ObtenirLes5CliniquesLesPlusProches();
        Task<bool> UserEstAdminClinique(IdentityUser user);
        Task<Clinique> ObtenirCliniqueParCreteurId(string? createurId);
        Task<IEnumerable<Clinique>> ObtenirListeCliniquesParCreateurId(string? createurId);
        Task<bool> VerifierSiUserAuthEstCreateurClinique(IdentityUser user);
        List<Clinique> GetAllClinique();
        string GetClinicNameById(int id);
    }
}