using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class PatientService : ServiceBaseAsync<Patient>, IPatientService
    {
        private readonly CliniqueDbContext _context;

        public PatientService(CliniqueDbContext context) : base(context)
        {
            _context = context;
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
        public async Task<Patient?> ObtenirPatientParEmailAsync(string courriel)
        {
            if (courriel == null)
            {
                return null;
            }
            return await _dbContext.Set<Patient>()
                .Where(p => p.Courriel.ToUpper() == courriel.ToUpper())
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
        public int CalculerAge(DateTime dateDeNaissance)
        {
            DateDeNaissanceEstValid(dateDeNaissance);

            int jours = (DateTime.Now - dateDeNaissance).Days;
            //int annees = DateTime.Now.Year - dateDeNaissance.Year;

            //bool estAnneeCouranteBissextile = DateTime.IsLeapYear(DateTime.Now.Year);
            //bool estAnneeNaissanceBissextile = DateTime.IsLeapYear(dateDeNaissance.Year);

            int age = (int)((DateTime.Now - dateDeNaissance).TotalDays / 365.242199);

            return age;
        }

        /// <summary>
        /// Vérifier si l'âge spécifié est supérieur ou égal à l'âge de la majorité.
        /// </summary>
        /// <param name="age">Âge à vérifier.</param>
        /// <returns>Vrai si l'âge est supérieur ou égal à l'âge de la majorité ; sinon Faux.</returns>
        public bool EstMajeurAge(int age)
        {
            return age >= AppConstants.AgeMajorite; ;
        }

        /// <summary>
        /// Vérifier si l'âge calculé à partir de la date de naissance est supérieur ou égal à l'âge de la majorité.
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de la personne.</param>
        /// <returns>Vrai si l'âge est supérieur ou égal à l'âge de la majorité ; sinon Faux.</returns>
        public bool EstMajeurDateDeNaissance(DateTime dateDeNaissance)
        {
            int age = CalculerAge(dateDeNaissance);

            return EstMajeurAge(age);
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
        public async Task<bool> VerifierExistencePatientParEmailAsync(string curriel)
        {
            var patientTrouve = await ObtenirPatientParEmailAsync(curriel);
            return patientTrouve != null;
        }

        public async Task<Patient> EnregistrerPatient(Patient patient)
        {

            if (await VerifierExistencePatientParEmailAsync(patient.Courriel))
            {
                throw new Exception("Cet email est déjà enregistré.");
            }
            if (await VerifierExistencePatientParNAM(patient.NAM))
            {
                throw new Exception("Ce numéro d'assurance médicale est déjà enregistré.");
            }
            if (!DateDeNaissanceEstValid(patient.DateDeNaissance))
            {
                throw new ArgumentException("La date de naissance n'est pas valide.");
            }
            int age = CalculerAge(patient.DateDeNaissance);
            if (!EstMajeurAge(age))
            {
                throw new Exception("Vous devez être majeur pour vous inscrire.");
            }
            patient.Age = age;
            return await CreerAsync(patient);
        }

        //            public async Task<T> CreerAsync(T entity)
        //{
        //    await _dbContext.Set<T>().AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();

        //    return entity;

        //}
    }
}
