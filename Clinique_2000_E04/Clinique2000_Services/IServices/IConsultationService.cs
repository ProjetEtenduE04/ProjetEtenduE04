using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IConsultationService : IServiceBaseAsync<Consultation>
    {
        Task ReserverConsultationAsync(int consultationId);
        Task<(PlageHoraire, ListeAttente)> ObtenirPlageHoraireEtListeAttenteAsync(int consultationId);
        Task<bool> ListeAttenteOuverteAsync(int consultationId);
        Task<int> ObtenirIdPatientAsync();
        string ObtenirIdUtilisateur();
        Task<int> ObtenirIdPatientDepuisUtilisateurAsync(string userId);
        Task<bool> PatientAConsultationPlanifieeAsync(int patientId);
        Task FermerOuLaisserOuverteListeAttente(int listeattenteid);
        Task<Consultation> ObtenirConsultationParIdAsync(int consultationId);
        //Task<List<Consultation>> ObtenirListesConsultationIncludeUsersCourriel();
        Task<ListeAttenteVM> AppelerProchainPatient(int employeCliniqueID);
        Task<ListeAttenteVM> TerminerConsultation(int consultaionID, DetailsConsultation details);
        Task AnnulerConsultationAsync(Patient patient);
    }
}
