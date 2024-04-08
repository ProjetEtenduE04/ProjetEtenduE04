using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Enum;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    [DisallowConcurrentExecution]
    public class EmailBackgroundJobService : IJob
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IEmailService _emailService;
        private readonly IConsultationService _consultationService;
        private readonly ISMSService _smsService;

        public EmailBackgroundJobService(
            ILogger<EmailService> logger,
            IEmailService emailService,
            IConsultationService consultationService,
            ISMSService smsService)

        {
            _logger = logger;
            _emailService = emailService;
            _consultationService = consultationService;
            _smsService = smsService;
        }

        /// <summary>
        /// Exécute le travail d'arrière-plan de l'expéditeur de courrier électronique.
        /// </summary>
        /// <param name="context">Le contexte d'exécution du travail.</param>
        public async Task Execute(IJobExecutionContext context)
        {
            // Nous récupérons tous les rendez-vous en cours
            var consultations = await _consultationService.ObtenirToutAsync();
            var listConsultationsEnAttente = consultations.Where(c => c.StatutConsultation == StatutConsultation.EnAttente);
            _emailService.CleanUpSentNotifications();
            foreach (var consultation in listConsultationsEnAttente)
            {
                // Vérifier si la date du rendez-vous est différente de la date actuelle
                if (consultation.HeureDateDebutPrevue.Date >= DateTime.Today.Date && 
                    consultation.HeureDateDebutPrevue.Date <= DateTime.Today.AddDays(1).Date)
                {
                    // Calculer le délai entre la date et l'heure actuelles et la date et l'heure de la consultation.
                    var timeDifference = consultation.HeureDateDebutPrevue - DateTime.Now;

                    // Vérifier les conditions de notification et envoyer le courrier électronique correspondant.
                    if (timeDifference <= TimeSpan.FromDays(1) && timeDifference > TimeSpan.FromHours(23))
                    {
                        // Préavis d'un jour entre 16 et 17 heures
                        if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 17)
                        {
                            var notificationTime = NotificationTime.UnJourAvant;
                            await SendNotificationBasedOnPreference (consultation, notificationTime);                            
                        }
                    }
                    else if (timeDifference > TimeSpan.FromHours(6) && timeDifference <= TimeSpan.FromHours(12))
                    {
                        // Préavis de 12 heures
                        var notificationTime = NotificationTime.DouzeHeuresAvant;
                        await SendNotificationBasedOnPreference(consultation, notificationTime);
                    }
                    else if (timeDifference > TimeSpan.FromHours(1) && timeDifference <= TimeSpan.FromHours(6))
                    {
                        // Préavis de 6 heures
                        var notificationTime = NotificationTime.SixHeuresAvant;
                        await SendNotificationBasedOnPreference(consultation, notificationTime);
                    }
                    else if (timeDifference > TimeSpan.FromHours(0) && timeDifference <= TimeSpan.FromHours(1))
                    {
                        // Préavis de 1 heure
                        var notificationTime = NotificationTime.UneHeureAvant;
                        await SendNotificationBasedOnPreference(consultation, notificationTime);
                    }
                }
            }
            _logger.LogInformation("{UtcNow}", DateTime.UtcNow);
            //return Task.CompletedTask; (if not async)
        }

        /// <summary>
        /// Envoie une notification en fonction de la préférence du patient.
        /// </summary>
        /// <param name="consultation"></param>
        /// <param name="notificationTime"></param>
        /// <returns></returns>
        public async Task SendNotificationBasedOnPreference(Consultation consultation, NotificationTime notificationTime)
        {
            if (consultation.Patient.preferenceNotification != PreferenceNotification.SMS)
            {
                await _emailService.SendConsultationNotificationAsync(consultation, notificationTime);
            }
            else
            {
                _smsService.SendConsultationReminderSMS(consultation);
            }
        }
    }
}
