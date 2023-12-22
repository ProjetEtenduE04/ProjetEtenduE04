using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _dbContext.Set<Patient>()
                .Where(p => p.NAM.ToUpper() == nam.ToUpper())
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

            bool estAnneeCouranteBissextile = DateTime.IsLeapYear(DateTime.Now.Year);
            bool estAnneeNaissanceBissextile = DateTime.IsLeapYear(dateDeNaissance.Year);

            double diviseur = (estAnneeCouranteBissextile || estAnneeNaissanceBissextile) ? 366.0 : 365.0;

            int age = (int)(jours / diviseur);

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
        public bool EstMajeurDateDeNaissance (DateTime dateDeNaissance)
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
        
    }
}
