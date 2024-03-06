using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Utility.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IEmailService
    {
        void SendEmail(EmailVM request);
        Task<EmailVM> CreateConsultationConfirmationEmail(Consultation consultation);
        Task SendConsultationConfirmationEmail(Consultation consultation);
        Task SendConsultationNotificationAsync(Consultation consultation, NotificationTime notificationTime);

    }
}
