using Clinique2000_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IConsultationService:IServiceBaseAsync<Consultation>
    {
        Task ReserverConsultationAsync(int patientId, Consultation consultation);
        Task<(PlageHoraire, ListeAttente)> GetPlageHoraireEtListeAttenteParConsultationIdAsync(int consultationId);
        bool VerifierSiPatientAdejaConsultationEnAttente(int patientID);

        bool VerifierPlageHoraireValideEtListeAttenteOuverte(int ConsultationID);
    }
}
