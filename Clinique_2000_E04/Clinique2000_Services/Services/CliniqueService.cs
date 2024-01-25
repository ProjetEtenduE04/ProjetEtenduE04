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
        private readonly IConsultationService _consultationService;


        public CliniqueService(
            CliniqueDbContext dbContext,
            IAdresseService adresseService,
            IConsultationService consultationService
            ) : base(dbContext)
        {
            _context = dbContext;
            _adresseService = adresseService;
            _consultationService = consultationService;
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
        /// Vérifie l'existence d'une clinique en fonction de son identifiant de manière asynchrone.
        /// </summary>
        /// <param name="id"> L'identifiant de la clinique </param>
        /// <returns>A été trouvée (true) ou non (false).</returns>
        public async Task<bool> VerifierExistenceCliniqueParIdAsync(int? id)
        {
            return id != null && await ObtenirParIdAsync(id.Value) != null;
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
            return clinique.HeureOuverture < clinique.HeureFermeture;
        }

        /// <summary>
        /// Effectue une liste de vérifications pour une clinique, y compris la validation de l'existence par nom et par adresse e-mail,
        /// ainsi que la vérification de la validité des heures d'ouverture.
        /// </summary>
        /// <param name="clinique">La clinique à vérifier.</param>
        /// <exception cref="ValidationException">
        ///     Levée si une validation échoue, par exemple:
        ///     - Une clinique avec le même nom existe déjà.
        ///     - Une clinique avec la même adresse e-mail existe déjà.
        ///     - Les heures d'ouverture ne sont pas valides.
        /// </exception>
        public async Task ListeDeVerificationClinique(Clinique clinique)
        {
            if (await VerifierExistenceCliniqueParNomAsync(clinique.NomClinique))
            {
                throw new ValidationException("Une clinique avec le même nom existe déjà.");
            }

            if (await VerifierExistenceCliniqueParCourrielAsync(clinique.Courriel))
            {
                throw new ValidationException("Une clinique avec la même adresse e-mail existe déjà.");
            }

            if (!await VerifierSiHeureOuvertureValide(clinique))
            {
                throw new ValidationException("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.");

            }
        }
        /// <summary>
        /// Effectue une vérification pour l'édition d'une clinique, y compris la validation de l'existence par nom et par adresse e-mail,
        /// ainsi que la vérification de la validité des heures d'ouverture.
        /// </summary>
        /// <param name="clinique">La clinique à vérifier et à éditer.</param>
        /// <exception cref="ValidationException">
        ///     Levée si une validation échoue, par exemple:
        ///     - Une clinique avec le même nom existe déjà.
        ///     - Une clinique avec la même adresse e-mail existe déjà.
        ///     - Les heures d'ouverture ne sont pas valides.
        /// </exception>
        public async Task ListeDeVerificationCliniqueEdit(Clinique clinique)
        {

            var cliniqueOriginale = await ObtenirParIdAsync(clinique.CliniqueID);

            if (cliniqueOriginale != null && clinique.NomClinique != cliniqueOriginale.NomClinique && await VerifierExistenceCliniqueParNomAsync(clinique.NomClinique))
            {
                throw new ValidationException("Une clinique avec le même nom existe déjà.");
            }

            if (cliniqueOriginale != null && clinique.Courriel != cliniqueOriginale.Courriel && await VerifierExistenceCliniqueParCourrielAsync(clinique.Courriel))
            {
                throw new ValidationException("Une clinique avec la même adresse e-mail existe déjà.");
            }

            if (!await VerifierSiHeureOuvertureValide(clinique))
            {
                throw new ValidationException("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.");

            }
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

            await ListeDeVerificationClinique(clinique);
            await _adresseService.VerifierCodePostalValideAsync(adresse.CodePostal);

            await _adresseService.CreerAsync(adresse);

            clinique.AdresseID = adresse.AdresseID;
            clinique.Adresse = adresse;

            var cliniqueEnregistree = await CreerAsync(clinique);

            return cliniqueEnregistree;
        }

        /// <summary>
        /// Effectue la vérification de la clinique et met à jour les informations de la clinique et de son adresse associée.
        /// </summary>
        /// <param name="id">L'ID de la clinique à mettre à jour.</param>
        /// <param name="viewModel">Le modèle de vue contenant les informations de la clinique et de l'adresse.</param>
        /// <exception cref="ValidationException">
        ///     Levée si une validation échoue, par exemple:
        ///     - Une clinique avec le même nom existe déjà.
        ///     - Une clinique avec la même adresse e-mail existe déjà.
        ///     - Les heures d'ouverture ne sont pas valides.
        ///     - Le format du code postal n'est pas valide.
        /// </exception>
        public async Task EditerCliniqueAsync(CliniqueAdresseVM viewModel)
        {
            var clinique = viewModel.Clinique;
            var adresse = viewModel.Adresse;

            await ListeDeVerificationClinique(clinique);
            await _adresseService.VerifierCodePostalValideAsync(adresse.CodePostal);

            await _adresseService.EditerAsync(adresse);
            await EditerAsync(clinique);
        }


        /// <summary>
        /// Obtient les listes d'attentes (la vue pour les patients)
        /// </summary>
        /// <param name="clinicId">ID de clinique qui a choisi</param>
        /// <param name="isOuvert"> filtre selon l'etat pour affichie seulement les listes d'attentes sont ouvert</param>
        /// <returns>Les listes d'attentes sont ouvert pour un clinique a choisi</returns>
        /// 
        public async Task<IList<ListeAttente>> GetListeAttentePourPatientAsync(int clinicId, bool? isOuvert)
        {
            IQueryable<ListeAttente> query = _context.Set<ListeAttente>();

            if (!isOuvert.HasValue)
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);
            }
            else if (isOuvert.Value)
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);
            }
            else
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && !la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);

            }
            return await query.ToListAsync();
        }


        public async Task<IEnumerable<Clinique>> ObtenirLes5CliniquesLesPlusProches()
        {
            var patientID = await _consultationService.ObtenirIdPatientAsync();
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == patientID);

            var cliniquesAvecDistanceVM = new List<(Clinique clinique, double distance)>();

            foreach (var clinique in _context.Cliniques)
            {
                double distance = await _adresseService.CalculerDistanceEntre2CodesPostaux(
                    clinique.Adresse.CodePostal, patient.CodePostal);

                cliniquesAvecDistanceVM.Add((clinique, distance));
            }

            IEnumerable<Clinique> lesPlusProchesCliniques = cliniquesAvecDistanceVM
                .Where(x=>x.clinique.EstActive)
                .OrderBy(cd => cd.distance)
                .Take(5)
                .Select(cd => cd.clinique)
                .ToList();

            return lesPlusProchesCliniques;
        }

    }

}