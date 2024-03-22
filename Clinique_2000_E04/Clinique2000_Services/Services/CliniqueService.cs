using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Clinique2000_Utility.Enum;
using Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

            await ListeDeVerificationCliniqueEdit(clinique);
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


        /// <summary>
        /// Obtient les listes d'attentes (la vue pour les employes)
        /// </summary>
        /// <returns> Les listes d'attentes sont ouvert pour un clinique a choisi</returns>
        public async Task<IEnumerable<CliniqueDistanceVM>> ObtenirLes5CliniquesLesPlusProches()
        {
            var patientID = await _consultationService.ObtenirIdPatientAsync();
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == patientID);
            var patientLocation = await _adresseService.GetLocationByPostalCodeAsync(patient.CodePostal);

            List<CliniqueDistanceVM> cliniquesAvecDistance = new List<CliniqueDistanceVM>();

            foreach (var clinique in _context.Cliniques)
            {
                bool aListeAttenteOuverteAvecConsultations = _context.ListeAttentes
                    .Any(la => la.CliniqueID == clinique.CliniqueID &&
                               la.IsOuverte &&
                               la.PlagesHoraires.Any(ph => ph.Consultations.Any(c => c.StatutConsultation == StatutConsultation.DisponiblePourReservation)));

                if (aListeAttenteOuverteAvecConsultations)
                {
                    var adresseClinique = await _adresseService.GetLocationByPostalCodeAsync(clinique.Adresse.CodePostal);
                    double distance = await _adresseService.CalculerDistanceEntre2CodesPostaux(patientLocation.PostalCode, adresseClinique.PostalCode);

                    var prochainePlageHoraire = _context.PlagesHoraires
                        .Include(ph => ph.Consultations)
                        .Where(ph => ph.ListeAttente.CliniqueID == clinique.CliniqueID &&
                                     ph.Consultations.Any(c => c.StatutConsultation == StatutConsultation.DisponiblePourReservation))
                        .OrderBy(ph => ph.HeureDebut)
                        .FirstOrDefault();

                    cliniquesAvecDistance.Add(new CliniqueDistanceVM
                    {
                        Clinique = clinique,
                        Distance = distance,
                        HeureProchaineConsultation = prochainePlageHoraire?.HeureDebut,
                        CliniqueLatitude = adresseClinique.Latitude.ToString(CultureInfo.InvariantCulture),
                        CliniqueLongitude = adresseClinique.Longitude.ToString(CultureInfo.InvariantCulture),
                        PatientLatitude = patientLocation.Latitude.ToString(CultureInfo.InvariantCulture),
                        PatientLongitude = patientLocation.Longitude.ToString(CultureInfo.InvariantCulture)
                    });
                }
            }

            return cliniquesAvecDistance
                    .OrderBy(cd => cd.Distance)
                    .Where(x => x.Clinique.EstActive)
                    .Take(5)
                    .ToList();
        }


        /// <summary>
        /// Verifie si l'utilisateur est le créateur d'une clinique.
        /// </summary>
        /// <param name="User"> utilisateur authentifié</param>
        /// <returns> true si l'utilisateur est le créateur d'une clinique, sinon false.</returns>
        public async Task<bool> UserEstAdminClinique(IdentityUser User)
        {
            if (_context.Cliniques.Any(x => x.CreateurID == User.Id))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Obtient la clinique associée à l'identifiant du créateur.
        /// </summary>
        /// <param name="createurId">L'identifiant du créateur.</param>
        /// <returns>La clinique correspondante, ou null si non trouvée.</returns>
        public async Task<Clinique> ObtenirCliniqueParCreteurId(string? createurId)
        {
            var clinique = await _dbContext.Cliniques.Where(c => c.CreateurID == createurId).FirstOrDefaultAsync();

            return clinique;
        }

        /// <summary>
        /// Obtient la clinique associée à l'identifiant du créateur.
        /// </summary>
        /// <param name="createurId">L'identifiant du créateur.</param>
        /// <returns>La clinique correspondante, ou null si non trouvée.</returns>
        public async Task<List<Clinique>> ObtenirLESCliniquesParCreateurId(string? createurId)
        {
            var clinique = await _dbContext.Cliniques.Where(c => c.CreateurID == createurId).ToListAsync();

            return clinique;
        }


        /// <summary>
        /// Obtient la liste des cliniques associées à l'identifiant du créateur.
        /// </summary>
        /// <param name="createurId">L'identifiant du créateur.</param>
        /// <returns>La liste des cliniques associées à l'identifiant du créateur.</returns>
        public async Task<IEnumerable<Clinique>> ObtenirListeCliniquesParCreateurId(string? createurId)
        {
            var cliniques = await _dbContext.Cliniques.Where(c => c.CreateurID == createurId).ToListAsync();

            return cliniques;
        }


        /// <summary>
        /// Vérifie si l'utilisateur authentifié est le créateur d'une clinique.
        /// </summary>
        /// <param name="user">L'utilisateur à vérifier.</param>
        /// <returns>True si l'utilisateur est le créateur d'une clinique, sinon false.</returns>
        public async Task<bool> VerifierSiUserAuthEstCreateurClinique(IdentityUser appUser)
        {
            Clinique clinique = await ObtenirCliniqueParCreteurId(appUser.Id) ;

            return clinique != null && clinique.CreateurID == appUser.Id;        
        }

        /// <summary>
        /// Modifier le statut de la clinique pour l'activer.
        /// </summary>
        /// <param name="clinique"> La clinique à activer.</param>
        /// <returns> La clinique activée.</returns>
        public async Task ApproverClinique(Clinique clinique)
        {
            clinique.EstActive = true;
            await EditerAsync(clinique);
        }

        public List<Clinique> GetAllClinique()
        {
            return _context.Cliniques.ToList();
        }

        public string GetClinicNameById(int id)
        {
            var clinic = _context.Cliniques.FirstOrDefault(c => c.CliniqueID == id);
            return clinic?.NomClinique;
        }

        public async Task<Critique> CreerCritiqueAsync(Critique critique)
        {
            _context.Critiques.Add(critique);
            _context.SaveChanges();

            var critiqueClinique = critique;

            return (critiqueClinique);
        }
    }
}