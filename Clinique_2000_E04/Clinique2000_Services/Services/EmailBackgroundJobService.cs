﻿using Clinique2000_Services.IServices;
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

        public EmailBackgroundJobService(
            ILogger<EmailService> logger,
            IEmailService emailService,
            IConsultationService consultationService
            )
        {
            _logger = logger;
            _emailService = emailService;
            _consultationService = consultationService;
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

            foreach (var consultation in listConsultationsEnAttente)
            {
                // Vérifier si la date du rendez-vous est différente de la date actuelle
                if (consultation.HeureDateDebutPrevue.Date >= DateTime.Today.Date && consultation.HeureDateDebutPrevue.Date <= DateTime.Today.AddDays(1).Date)
                {
                    // Calculer le délai entre la date et l'heure actuelles et la date et l'heure de la consultation.
                    var timeDifference = consultation.HeureDateDebutPrevue - DateTime.Now;

                    // Vérifier les conditions de notification et envoyer le courrier électronique correspondant.
                    if (timeDifference <= TimeSpan.FromDays(1) && timeDifference > TimeSpan.FromHours(23))
                    {
                        // Préavis d'un jour entre 16 et 17 heures
                        if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 17)
                        {
                            await _emailService.SendConsultationNotificationAsync(consultation, NotificationTime.UnJourAvant);
                        }
                    }
                    else if (timeDifference > TimeSpan.FromHours(6) && timeDifference <= TimeSpan.FromHours(12))
                    {
                        // Préavis de 12 heures
                        await _emailService.SendConsultationNotificationAsync(consultation, NotificationTime.DouzeHeuresAvant);
                    }
                    else if (timeDifference > TimeSpan.FromHours(1) && timeDifference <= TimeSpan.FromHours(6))
                    {
                        // Préavis de 6 heures
                        await _emailService.SendConsultationNotificationAsync(consultation, NotificationTime.SixHeuresAvant);
                    }
                    else if (timeDifference > TimeSpan.FromHours(0) && timeDifference <= TimeSpan.FromHours(1))
                    {
                        // Préavis de 1 heure
                        await _emailService.SendConsultationNotificationAsync(consultation, NotificationTime.UneHeureAvant);
                    }
                }
            }
            _logger.LogInformation("{UtcNow}", DateTime.UtcNow);
            //return Task.CompletedTask; (if not async)
        }

    }
}
