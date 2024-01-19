using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
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
        Task<bool> VerifierSiHeureOuvertureValide(Clinique clinique);
        Task<Clinique> EnregistrerCliniqueAsync(CliniqueAdresseVM viewModel);
    }
}
