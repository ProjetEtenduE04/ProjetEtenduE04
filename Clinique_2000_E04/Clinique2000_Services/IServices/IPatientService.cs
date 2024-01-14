using Clinique2000_Core.Models;
using static Clinique2000_Services.Services.PatientService;

namespace Clinique2000_Services.IServices
{
    public interface IPatientService : IServiceBaseAsync<Patient>
    {
        Task<Patient?> ObtenirPatientParNAMAsync(string nam);
        bool DateDeNaissanceEstValid(DateTime dateDeNaissance);
        Age CalculerAge(DateTime dateDeNaissance);
        bool EstMajeurAge(int age);
        bool EstMajeurDateDeNaissance(DateTime dateDeNaissance);
        Task<bool> VerifierExistencePatientParNAM(string nam);
        Task<Patient> EnregistrerPatient(Patient patient);
        Task<bool> UserEstPatientAsync(string userId);
        Task<Patient> GetPatientParUserIdAsync(string userId);
        Task<bool> VerifierExistencePatientParEmailAsync(string curriel);
        Task<Patient?> ObtenirPatientParNomAsync(string curriel);
    }
}
