using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Clinique2000_Utility.CustomAttributesValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Clinique2000_Services.Services
{
    public class PatientService : ServiceBaseAsync<Patient>, IPatientService
    {
        private readonly CliniqueDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdresseService _adresseService;

        public PatientService(CliniqueDbContext context,
                UserManager<IdentityUser> userManager,
                IHttpContextAccessor httpContextAccessor,
                IAdresseService adresseService) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _adresseService = adresseService;

        }

        /// <summary>
        /// Obtient un patient par son numéro d'assurance médicale (NAM) de manière asynchrone.
        /// </summary>
        /// <param name="nam">Numéro d'assurance médicale à rechercher.</param>
        /// <returns>Le patient correspondant au numéro d'assurance médicale fourni, s'il existe ; sinon, null.</returns>
        public async Task<Patient?> ObtenirPatientParNAMAsync(string nam)
        {
            if (nam == null)
            {
                return null;
            }
            return await _dbContext.Set<Patient>()
                .Where(p => p.NAM.ToUpper() == nam.ToUpper())
                .FirstOrDefaultAsync();
        }


        public async Task<PatientACharge?> ObtenirPatientAchargeParNAMAsync(string nam)
        {
            if (nam == null)
            {
                return null;
            }
            return await _dbContext.Set<PatientACharge>()
                .Where(p => p.NAM.ToUpper() == nam.ToUpper())
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtenir un patient de manière asynchrone par nom
        /// </summary>
        /// <param name="courriel">Nom</param>
        /// <returns>Le patient correspond au nom transmis, s'il existe, sinon null.</returns>
        public async Task<Patient?> ObtenirPatientParNomAsync(string nom)
        {
            if (nom == null)
            {
                return null;
            }
            return await _dbContext.Set<Patient>()
                .Where(p => p.Nom.ToUpper() == nom.ToUpper())
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Valider la date de naissance par rapport à la date du jour et au nombre de jours du mois.
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de la personne.</param>
        /// <returns>True</returns>
        /// <exception cref="ArgumentException">L'exception est lancée si l'anniversaire se situe dans le futur ou si le jour dépasse le nombre de jours du mois.</exception>
        public bool DateDeNaissanceEstValid(DateTime dateDeNaissance)
        {
            if (dateDeNaissance > DateTime.Now)
            {
                throw new ArgumentException("La date de naissance ne peut pas se situer dans le futur.");
            }
            return true;
        }

        /// <summary>
        /// Calculer l'âge selon la date de naissance fournie.Prendre en compte les personnes nées dans les années bissextiles
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de la personne.</param>
        /// <returns>Âge de la personne calculé en années.</returns>
        public Age CalculerAge(DateTime dateDeNaissance)
        {
            DateDeNaissanceEstValid(dateDeNaissance);

            #region refactoriser, supprimer ultérieurement
            //int jours = (DateTime.Now - dateDeNaissance).Days;
            //int annees = DateTime.Now.Year - dateDeNaissance.Year;

            //bool estAnneeCouranteBissextile = DateTime.IsLeapYear(DateTime.Now.Year);
            //bool estAnneeNaissanceBissextile = DateTime.IsLeapYear(dateDeNaissance.Year);

            //int age = (int)((DateTime.Now - dateDeNaissance).TotalDays / 365.242199);
            #endregion

            var ageExactJMA = new Age(dateDeNaissance, DateTime.Now);

            return ageExactJMA;
        }

        /// <summary>
        /// calculer le delai à partir de la date fournie.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Age CalculerDelai(DateTime date)
        {
            return new Age(date, DateTime.Now);
        }


        /// <summary>
        /// Vérifier si l'âge spécifié est supérieur ou égal à l'âge de la majorité.
        /// </summary>
        /// <param name="age">Âge à vérifier.</param>
        /// <returns>Vrai si l'âge est supérieur ou égal à l'âge de la majorité ; sinon Faux.</returns>
        public bool EstMajeurAge(int ageEnAnnees)
        {
            return ageEnAnnees >= AppConstants.AgeMajorite; 
        }

        /// <summary>
        /// Vérifier si l'âge calculé à partir de la date de naissance est supérieur ou égal à l'âge de la majorité.
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de la personne.</param>
        /// <returns>Vrai si l'âge est supérieur ou égal à l'âge de la majorité ; sinon Faux.</returns>
        public bool EstMajeurDateDeNaissance(DateTime dateDeNaissance)
        {
            Age ageExacte = CalculerAge(dateDeNaissance);

            return EstMajeurAge(ageExacte.Annees);
        }

        /// <summary>
        /// Vérifier l'existence d'un patient dans la base de données à l'aide d'une NAM .
        /// </summary>
        /// <param name="nam">Le numéro d'assurance médicale du patient pour vérification.</param>
        /// <returns>Vrai si le patient existe dans la base de données, sinon Faux.</returns>
        public async Task<bool> VerifierExistencePatientParNAM(string nam)
        {
            var patientTrouve = await ObtenirPatientParNAMAsync(nam);
            return patientTrouve != null;
        }


        public async Task<bool> VerifierExistencePatientAchargeParNAM(string nam)
        {
            var patientTrouve = await ObtenirPatientParNAMAsync(nam);
            return patientTrouve != null;
        }

        /// <summary>
        /// Vérifier si un patient existe dans la base de données avec l'adresse électronique donnée.
        /// </summary>
        /// <param name="curriel">Courriel du patient authentifié pour vérification.</param>
        /// <returns>Vrai si le patient existe dans la base de données, sinon Faux.</returns>
        public async Task<bool> VerifierExistencePatientParNomAsync(string nom)
        {
            var patientTrouvee = await ObtenirPatientParNomAsync(nom);
            return patientTrouvee != null;
        }
        #region Méthodes de création et d'édition, modulaires, séparée
        //public async Task<Patient> EnregistrerPatient(Patient patient)
        //{

        //    if (await VerifierExistencePatientParNAM(patient.NAM))
        //    {
        //        throw new Exception("Ce numéro d'assurance médicale est déjà enregistré.");
        //    }
        //    if (!DateDeNaissanceEstValid(patient.DateDeNaissance))
        //    {
        //        throw new ArgumentException("La date de naissance n'est pas valide.");
        //    }
        //    Age ageExact = CalculerAge(patient.DateDeNaissance);
        //    if (!EstMajeurAge(ageExact.Annees))
        //    {
        //        throw new Exception("Vous devez être majeur pour vous inscrire.");
        //    }
        //    patient.Age = ageExact.Annees;
        //    return await CreerAsync(patient);
        //}

        //public async Task<Patient> ModifierPatient(Patient patient)
        //{
        //    if (patient.PatientId == 0)
        //    {
        //        throw new ArgumentException("L'identifiant du patient est nécessaire pour la modification.");
        //    }

        //    var existingPatient = await ObtenirParIdAsync(patient.PatientId);
        //    if (existingPatient == null)
        //    {
        //        throw new Exception("Le patient n'existe pas.");
        //    }

        //    if (existingPatient.NAM != patient.NAM && await VerifierExistencePatientParNAM(patient.NAM))
        //    {
        //        throw new Exception("Un autre patient est déjà enregistré avec ce numéro d'assurance maladie, veuillez vérifier vos renseignements ou contacter le service clientèle.");
        //    }

        //    if (!DateDeNaissanceEstValid(patient.DateDeNaissance))
        //    {
        //        throw new ArgumentException("La date de naissance n'est pas valide.");
        //    }
        //    Age ageExact = CalculerAge(patient.DateDeNaissance);
        //    if (!EstMajeurAge(ageExact.Annees))
        //    {
        //        throw new Exception("Vous devez être majeur pour vous inscrire.");
        //    }
        //    patient.Age = ageExact.Annees;

        //    return await EditerAsync(patient);
        //}
        #endregion

        /// <summary>
        /// Enregistre ou modifie un patient dans la base de données.
        /// </summary>
        /// <param name="patient">Le patient à enregistrer ou modifier.</param>
        /// <returns>Le patient enregistré ou modifié.</returns>
        /// <exception cref="Exception">Exception générale levée lors de problèmes.</exception>
        /// <exception cref="ArgumentException">Exception levée en cas d'argument non valide.</exception>
        public async Task<Patient> EnregistrerOuModifierPatient(Patient patient)
        {

            if (patient.PatientId == 0 && await VerifierExistencePatientParNAM(patient.NAM))
            {
                throw new Exception("Ce numéro d'assurance médicale est déjà enregistré.");
            }
            if (!DateDeNaissanceEstValid(patient.DateDeNaissance))
            {
                throw new ArgumentException("La date de naissance n'est pas valide.");
            }
            Age ageExact = CalculerAge(patient.DateDeNaissance);
            if (!EstMajeurAge(ageExact.Annees))
            {
                throw new Exception("Vous devez être majeur pour vous inscrire.");
            }
            patient.Age = ageExact.Annees;

            await _adresseService.VerifierCodePostalValideAsync(patient.CodePostal);

            if (patient.PatientId != 0)
            {
                var existingPatient = await ObtenirParIdAsync(patient.PatientId);
                if (existingPatient != null && existingPatient.NAM != patient.NAM && await VerifierExistencePatientParNAM(patient.NAM))
                {
                    throw new Exception("Un autre patient est déjà enregistré avec ce numéro d'assurance maladie, veuillez vérifier vos renseignements ou contacter le service clientèle.");
                }
                return await EditerAsync(patient);
            }
            else
            {
                return await CreerAsync(patient);
            }
        }

        /// <summary>
        /// Vérifie si un utilisateur est enregistré en tant que patient.
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur.</param>
        /// <returns>True si l'utilisateur est enregistré en tant que patient, sinon False.</returns>
        public async Task<bool> UserEstPatientAsync(string userId)
        {
            return await _context.Patients.AnyAsync(p => p.UserId == userId);
        }

        /// <summary>
        /// Récupère un patient en fonction de l'identifiant de l'utilisateur.
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur associé au patient.</param>
        /// <returns>Le patient correspondant à l'identifiant de l'utilisateur, ou null si non trouvé.</returns>
        public async Task<Patient> GetPatientParUserIdAsync(string userId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        /// <summary>
        /// Vérifie si un utilisateur authentifié est enregistré en tant que patient.
        /// </summary>
        /// <returns>True si l'utilisateur est enregistré en tant que patient, sinon False. </returns>
        public async Task<bool> UserAuthEstPatientAsync()
        {
            //string courrielUserAuth = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            //var user = await _userManager.FindByEmailAsync(courrielUserAuth);
            var user = await GetUserAuthAsync();

            if (user != null)
            {
                return await UserEstPatientAsync(user.Id);
            }
            else
            {
                // Handle the case when the user is null
                return false;
            }
        }

        /// <summary>
        /// Obtient un patient en fonction de l'utilisateur authentifié.
        /// </summary>
        /// <returns>IdentityUser</returns>
        public async Task<IdentityUser> GetUserAuth()
        {
            string courrielUserAuth = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(courrielUserAuth);
            return user;
        }

        /// <summary>
        /// Récupère l'ID du patient en fonction de l'identifiant de l'utilisateur.
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur associé au patient.</param>
        /// <returns>L'ID du patient correspondant à l'identifiant de l'utilisateur, ou 0 si non trouvé.</returns>
        public async Task<int> GetPatientIdFromUserIdAsync(string userId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
            return patient?.PatientId ?? 0; // Retourne 0 si aucun patient n'est trouvé
        }

        /// <summary>
        /// Obtient l'utilisateur authentifié.
        /// </summary>
        /// <returns>L'utilisateur authentifié.</returns>
        /// <remarks>
        /// Cette méthode récupère l'utilisateur authentifié en utilisant son adresse e-mail.
        /// </remarks>
        public async Task<IdentityUser> GetUserAuthAsync()
        {
            string courrielUserAuth = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(courrielUserAuth);
            return user;
        }

        /// <summary>
        /// Obtient un utilisateur en fonction de son identifiant.
        /// </summary>
        /// <param name="userId"> Id de l'utilisateur  </param>
        /// <returns> IdentityUser </returns>
        public async Task<IdentityUser> GetUserByUserId(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        /// <summary>
        /// Représente l'âge d'une personne en années, mois et jours.
        /// </summary>
        public class Age
        {
            public int Annees;
            public int Mois;
            public int Jours;

            /// <summary>
            /// Initialise une nouvelle instance de la classe <see cref="Age"/> avec la date de naissance spécifiée.
            /// </summary>
            /// <param name="dateNaissance">La date de naissance.</param>
            public Age(DateTime dateNaissance)
            {
                Compter(dateNaissance);
            }

            /// <summary>
            /// Initialise une nouvelle instance de la classe <see cref="Age"/> avec les dates de naissance et actuelle spécifiées.
            /// </summary>
            /// <param name="dateNaissance">La date de naissance.</param>
            /// <param name="dateActuelle">La date actuelle.</param>
            public Age(DateTime dateNaissance, DateTime dateActuelle)
            {
                Compter(dateNaissance, dateActuelle);
            }

            /// <summary>
            /// Calcule l'âge en années, mois et jours entre la date de naissance et la date actuelle.
            /// </summary>
            /// <param name="dateNaissance">La date de naissance.</param>
            /// <returns>Un objet Age représentant l'âge calculé.</returns>
            public Age Compter(DateTime dateNaissance)
            {
                return Compter(dateNaissance, DateTime.Today);
            }

            /// <summary>
            /// Calcule l'âge en années, mois et jours entre la date de naissance et la date actuelle.
            /// </summary>
            /// <param name="dateNaissance">La date de naissance.</param>
            /// <param name="dateActuelle">La date actuelle.</param>
            /// <returns>Un objet Age représentant l'âge calculé.</returns>
            /// <exception cref="ArgumentException">Exception levée si la date de naissance est postérieure à la date actuelle.</exception>
            public Age Compter(DateTime dateNaissance, DateTime dateActuelle)
            {
                if ((dateActuelle.Year - dateNaissance.Year) > 0 ||
                    (((dateActuelle.Year - dateNaissance.Year) == 0) && ((dateNaissance.Month < dateActuelle.Month) ||
                      ((dateNaissance.Month == dateActuelle.Month) && (dateNaissance.Day <= dateActuelle.Day)))))
                {
                    int joursDansMoisNaissance = DateTime.DaysInMonth(dateNaissance.Year, dateNaissance.Month);
                    int joursRestants = dateActuelle.Day + (joursDansMoisNaissance - dateNaissance.Day);

                    if (dateActuelle.Month > dateNaissance.Month)
                    {
                        Annees = dateActuelle.Year - dateNaissance.Year;
                        Mois = dateActuelle.Month - (dateNaissance.Month + 1) + Math.Abs(joursRestants / joursDansMoisNaissance);
                        Jours = (joursRestants % joursDansMoisNaissance + joursDansMoisNaissance) % joursDansMoisNaissance;
                    }
                    else if (dateActuelle.Month == dateNaissance.Month)
                    {
                        if (dateActuelle.Day >= dateNaissance.Day)
                        {
                            Annees = dateActuelle.Year - dateNaissance.Year;
                            Mois = 0;
                            Jours = dateActuelle.Day - dateNaissance.Day;
                        }
                        else
                        {
                            Annees = (dateActuelle.Year - 1) - dateNaissance.Year;
                            Mois = 11;
                            Jours = DateTime.DaysInMonth(dateNaissance.Year, dateNaissance.Month) - (dateNaissance.Day - dateActuelle.Day);
                        }
                    }
                    else
                    {
                        Annees = (dateActuelle.Year - 1) - dateNaissance.Year;
                        Mois = dateActuelle.Month + (11 - dateNaissance.Month) + Math.Abs(joursRestants / joursDansMoisNaissance);
                        Jours = (joursRestants % joursDansMoisNaissance + joursDansMoisNaissance) % joursDansMoisNaissance;
                    }
                }
                else
                {
                    throw new ArgumentException("La date de naissance doit être antérieure à la date actuelle");
                }
                return this;
            }

        }

        /// <summary>
        /// Verifier si un patient peut ajouter une critique à une clinique.
        /// </summary>
        /// <param name="patientId">L'identifiant du patient.
        /// </param>
        /// <param name="cliniqueId">L'identifiant de la clinique.
        /// </param>
        /// <returns>True si le patient peut ajouter une critique à la clinique, sinon False.
        /// </returns>
        public async Task<bool> PeutAjouterNoteAClinique(int patientId, int cliniqueId)
        {
            var critique = await _context.Critiques
                .Where(c => c.PatientId == patientId && c.CliniqueId == cliniqueId)
                .OrderByDescending(c => c.Date)
                .FirstOrDefaultAsync();

            if (critique != null)
            {
                var intervalleDeTemps = CalculerDelai(critique.Date).Mois;
                return intervalleDeTemps >= 1; // Si l'intervalle de temps est supérieur à 1 mois, le patient peut ajouter une critique
            }
            else
            {
                return true; // En supposant que le patient puisse ajouter un avis pour la première fois
            }
        }

    }
}
