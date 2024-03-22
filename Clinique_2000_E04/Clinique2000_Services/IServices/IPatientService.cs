using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Identity;
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
        Task<Patient> EnregistrerOuModifierPatient(Patient patient);
        Task<bool> UserEstPatientAsync(string userId);
        Task<Patient> GetPatientParUserIdAsync(string userId);
        Task<bool> VerifierExistencePatientParNomAsync(string nom);
        Task<Patient?> ObtenirPatientParNomAsync(string curriel);
        Task<bool> UserAuthEstPatientAsync();
        Task<IdentityUser> GetUserAuthAsync();
        Task<IdentityUser> GetUserByUserId(string userId);
        Task<int> GetPatientIdFromUserIdAsync(string userId);
        Task<bool> PeutAjouterNoteAClinique(int patientId, int cliniqueId);
    }
}
