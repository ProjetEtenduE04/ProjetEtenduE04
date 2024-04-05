using Clinique2000_Core.Models;
using IO.ClickSend.ClickSend.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface ISMSService
    {
        void SendSMS(string phoneNumber);
        void SendConfirmationSMS(Consultation consultation, string phoneNumber);
        void SendConfirmationSMSApresImportationPatient(string phoneNumber);
        void SendConsultationReminderSMS(Consultation consultation);
    }
}
