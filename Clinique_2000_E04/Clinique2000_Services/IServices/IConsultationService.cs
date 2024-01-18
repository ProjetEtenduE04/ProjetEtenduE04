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
        Task ReserverConsultationAsync(Consultation consultation);
        Task<(PlageHoraire, ListeAttente)> GetPlageHoraireEtListeAttenteParConsultationIdAsync(int consultationId);
        Task<bool> ListeAttenteEstOuverte(int consultationId);
        Task<bool> PatientAConsultationPlanifiee(int patientId);
    }
}
