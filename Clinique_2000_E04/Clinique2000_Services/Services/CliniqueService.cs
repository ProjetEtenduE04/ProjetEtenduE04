using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class CliniqueService : ServiceBaseAsync<Clinique>, ICliniqueService
    {
        private readonly CliniqueDbContext _context;
        private readonly IAdresseService _adresseService;

        public CliniqueService(
            CliniqueDbContext dbContext,
            IAdresseService adresseService
            ) : base(dbContext)
        {
            _context = dbContext;
            _adresseService = adresseService;
        }

        /// <summary>
        /// Obtient une clinique par son nom de manière asynchrone.
        /// </summary>
        /// <param name="nomClinique">Nom de la Clinique</param>
        /// <returns>Clinique si existe , sinon null</returns>
        public async Task<Clinique?> ObtenirCliniqueParNomAsync(string nomClinique)
        {
            if (nomClinique == null)
            {
                return null;
            }
            return await _dbContext.Set<Clinique>()
                .Where(p => p.NomClinique.ToUpper() == nomClinique.ToUpper())
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtient une clinique en fonction de l'adresse e-mail de manière asynchrone.
        /// </summary>
        /// <param name="courriel">L'adresse e-mail pour laquelle obtenir la clinique.</param>
        /// <returns>La clinique correspondante ou null si non trouvée.</returns>
        public async Task<Clinique?> ObtenirCliniqueParCourrielAsync(string courriel)
        {
            if (courriel == null)
            {
                return null;
            }
            return await _dbContext.Set<Clinique>()
                .Where(p => p.Courriel.ToUpper() == courriel.ToUpper())
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Vérifie si une clinique existe par son nom de manière asynchrone.
        /// </summary>
        /// <param name="nomClinique">Nom Clinique</param>
        /// <returns>Vrai si la clinique existe dans la base de donées, sinon Faux</returns>
        public async Task<bool> VerifierExistenceCliniqueParNomAsync(string nomClinique)
        {
            var cliniqueTrouvee = await ObtenirCliniqueParNomAsync(nomClinique);
            return cliniqueTrouvee != null;
        }

        /// <summary>
        /// Vérifie l'existence d'une clinique en fonction de l'adresse e-mail de manière asynchrone.
        /// </summary>
        /// <param name="courriel">L'adresse e-mail pour laquelle vérifier l'existence de la clinique.</param>
        /// <returns>A été trouvée (true) ou non (false).</returns>
        public async Task<bool> VerifierExistenceCliniqueParCourrielAsync(string courriel)
        {
            var cliniqueTrouvee = await ObtenirCliniqueParCourrielAsync(courriel);
            return cliniqueTrouvee != null;
        }
        /// <summary>
        /// Vérifie si les heures d'ouverture d'une clinique sont valides.
        /// </summary>
        /// <param name="clinique">La clinique pour laquelle vérifier les heures d'ouverture.</param>
        /// <returns>
        ///   true si les heures d'ouverture sont antérieures aux heures de fermeture, sinon lance une exception.
        /// </returns>
        /// <exception cref="ValidationException">Lancée lorsque les heures d'ouverture ne sont pas valides.</exception>
        public async Task<bool> VerifierSiHeureOuvertureValide(Clinique clinique)
        {
            return clinique.HeureOuverture > clinique.HeureFermeture;
        }

        /// <summary>
        /// Enregistre une nouvelle clinique avec son adresse associée.
        /// </summary>
        /// <param name="viewModel">Le modèle de vue contenant les informations de la clinique et de l'adresse.</param>
        /// <returns>La clinique nouvellement enregistrée.</returns>
        /// <exception cref="ValidationException">
        ///     Levée si une validation échoue, par exemple:
        ///     - Une clinique avec le même nom existe déjà.
        ///     - Une clinique avec la même adresse e-mail existe déjà.
        ///     - Les heures d'ouverture ne sont pas valides.
        ///     - Le format du code postal n'est pas valide.
        /// </exception>
        public async Task<Clinique> EnregistrerCliniqueAsync(CliniqueAdresseVM viewModel)
        {
            var clinique = viewModel.Clinique;
            var adresse = viewModel.Adresse;
            if (await VerifierExistenceCliniqueParNomAsync(clinique.NomClinique))
            {
                throw new ValidationException("Une clinique avec le même nom existe déjà.");
            }

            if (await VerifierExistenceCliniqueParCourrielAsync(clinique.Courriel))
            {
                throw new ValidationException("Une clinique avec la même adresse e-mail existe déjà.");
            }

            if (await VerifierSiHeureOuvertureValide(clinique))
            {
                throw new ValidationException("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.");

            }
            await _adresseService.VerifierCodePostalValideAsync(adresse.CodePostal);

            await _adresseService.CreerAsync(adresse);

            clinique.AdresseID = adresse.AdresseID;
            clinique.Adresse = adresse;

            var cliniqueEnregistre = await CreerAsync(clinique);

            return cliniqueEnregistre;
        }
    }
}

