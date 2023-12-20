using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;
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
        /// Calculer l'âge selon la date de naissance fournie.Prendre en compte les personnes nées dans les années bissextiles
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de la personne.</param>
        /// <returns>Âge de la personne calculé en années.</returns>
        public int CalculerAge(DateTime dateDeNaissance)
        {
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
        public bool VerifierExistencePatientParNAM(string nam)
        {
            var patientTrouve = ObtenirParNomAsync(nam);
            return patientTrouve != null;
        }
        
    }
}
