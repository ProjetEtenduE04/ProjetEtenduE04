using Clinique2000_Core.Models;

namespace Clinique2000_Services.IServices
{
    public interface IPatientService : IServiceBaseAsync<Patient>
    {
        Task<Patient?> ObtenirPatientParNAMAsync(string nam);
        //Task<Patient?> ObtenirPatientParEmailAsync(string curriel);
        bool DateDeNaissanceEstValid(DateTime dateDeNaissance);
        int CalculerAge(DateTime dateDeNaissance);
        bool EstMajeurAge(int age);
        bool EstMajeurDateDeNaissance(DateTime dateDeNaissance);
        Task<bool> VerifierExistencePatientParNAM(string nam);
        //Task<bool> VerifierExistencePatientParEmailAsync(string curriel);
        Task<Patient> EnregistrerPatient(Patient patient);

    }
}
