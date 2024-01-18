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
        //public bool IsClinicQueueOpen(int cliniqueId);

        //public bool HasActiveConsultation(int patientId);

        //public string ValidateConsultationRequestForm(Consultation consultation);

        //Task<Consultation> CreateConsultationRequest(Consultation consultation);
    }
}
