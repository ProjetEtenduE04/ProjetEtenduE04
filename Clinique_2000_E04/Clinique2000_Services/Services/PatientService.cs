using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Clinique2000_Utility.CustomAttributesValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class PatientService : ServiceBaseAsync<Patient>, IPatientService
    {
        private readonly CliniqueDbContext _context;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly UserManager<IdentityUser> _userManager;

        public PatientService(CliniqueDbContext context
            //,
            //            SignInManager<IdentityUser> signInManager,
            //            UserManager<IdentityUser> userManager
            ) : base(context)
        {
            _context = context;
            //_signInManager = signInManager;
            //_userManager = userManager;
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

        /// <summary>
        /// Obtenir un patient de manière asynchrone par courrier électronique
        /// </summary>
        /// <param name="courriel">courrier électronique</param>
        /// <returns>Le patient correspond à l'adresse électronique fournie, s'il existe, sinon null.</returns>
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

            //int jours = (DateTime.Now - dateDeNaissance).Days;
            //int annees = DateTime.Now.Year - dateDeNaissance.Year;

            //bool estAnneeCouranteBissextile = DateTime.IsLeapYear(DateTime.Now.Year);
            //bool estAnneeNaissanceBissextile = DateTime.IsLeapYear(dateDeNaissance.Year);

            //int age = (int)((DateTime.Now - dateDeNaissance).TotalDays / 365.242199);

            var ageExactJMA = new Age(dateDeNaissance, DateTime.Now);

            return ageExactJMA;
        }

        /// <summary>
        /// Vérifier si l'âge spécifié est supérieur ou égal à l'âge de la majorité.
        /// </summary>
        /// <param name="age">Âge à vérifier.</param>
        /// <returns>Vrai si l'âge est supérieur ou égal à l'âge de la majorité ; sinon Faux.</returns>
        public bool EstMajeurAge(int ageEnAnnees)
        {
            return ageEnAnnees >= AppConstants.AgeMajorite; ;
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

        /// <summary>
        /// Vérifier si un patient existe dans la base de données avec l'adresse électronique donnée.
        /// </summary>
        /// <param name="curriel">Courriel du patient authentifié pour vérification.</param>
        /// <returns>Vrai si le patient existe dans la base de données, sinon Faux.</returns>
        public async Task<bool> VerifierExistencePatientParEmailAsync(string nom)
        {
            var patientTrouve = await ObtenirPatientParNomAsync(nom);
            return patientTrouve != null;
        }

        public async Task<Patient> EnregistrerPatient(Patient patient)
        {

            if (await VerifierExistencePatientParNAM(patient.NAM))
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
            return await CreerAsync(patient);
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
    }
}
