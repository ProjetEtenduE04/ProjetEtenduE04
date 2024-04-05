using Clinique2000_Services.IServices;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Clinique2000_Core.ViewModels;
using Clinique2000_Core.Models;
using Clinique2000_Utility.Enum;
using Quartz;
using Microsoft.Extensions.Hosting;
using Google.Apis.Logging;
using Microsoft.Extensions.Logging;

namespace Clinique2000_Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly IPatientService _patientService;
        private readonly IDictionary<string, HashSet<NotificationTime>> _sentNotifications = new Dictionary<string, HashSet<NotificationTime>>();


        public EmailService(IConfiguration config,
            IPatientService patientService
            )
        {
            _config = config;
            _patientService = patientService;
        }

        /// <summary>
        /// Envoie un courriel en utilisant les paramètres spécifiés dans l'objet EmailVM.
        /// </summary>
        /// <param name="request">L'objet EmailVM contenant les informations du courriel à envoyer.</param>
        //public void SendEmail(EmailVM request)
        //{
        //    try
        //    {
        //        var email = new MimeMessage();
        //        email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
        //        email.To.Add(MailboxAddress.Parse(request.To));
        //        email.Subject = request.Subject;
        //        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        //        using var smtp = new SmtpClient();
        //        smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.Auto);
        //        smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
        //        smtp.Send(email);
        //        smtp.Disconnect(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erreur lors de l'envoi du courrier électronique : {ex.Message}");
        //    }
        //}


        /// <summary>
        /// Envoie un courriel en utilisant les paramètres spécifiés dans l'objet EmailVM.
        /// </summary>
        /// <param name="request">L'objet EmailVM contenant les informations du courriel à envoyer.</param>
        public async Task SendEmail(EmailVM request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.Auto);
                await smtp.AuthenticateAsync(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'envoi du courrier électronique : {ex.Message}");  
            }
        }


        /// <summary>
        /// Crée et retourne un objet EmailVM pour la confirmation de réservation de consultation.
        /// </summary>
        /// <param name="consultation">La consultation pour laquelle la confirmation est générée.</param>
        public async Task<EmailVM> CreateConsultationConfirmationEmail(Consultation consultation)
        {
            var user = await _patientService.GetUserAuthAsync();
            var patient = consultation.Patient;
            var subject = "Confirmation de réservation Consultation";
                var body =  $"    <p>Bonjour, {patient.Nom} {consultation.Patient.Prenom} !</p>" +
                        $"    <p>Nous confirmons la réservation de la consultation prévue pour :</p>" +
                        $"    <h3 style=\"color:red;\">{consultation.HeureDateDebutPrevue.ToShortDateString()} à {consultation.HeureDateFinPrevue.ToShortTimeString()}</h3>" +
                        $"    <h3 style=\"color:red;\">Clinique : {consultation.PlageHoraire.ListeAttente.Clinique.NomClinique}</h3>" +
                        $"    <p>Nous vous remercions et nous nous réjouissons de vous voir lors de votre rendez-vous.</p>" +
                        $"    <p>Cordialement,<br />L'équipe Clinique2000</p>";

            return new EmailVM
            {
                To = user.Email,
                Subject = subject,
                Body = body
            };
        }

        /// <summary>
        /// Envoie un courriel de confirmation de réservation pour la consultation spécifiée.
        /// </summary>
        /// <param name="consultation">La consultation pour laquelle le courriel de confirmation est envoyé.</param>
        public async Task SendConsultationConfirmationEmail(Consultation consultation)
        {
            var confirmationEmail = await CreateConsultationConfirmationEmail(consultation);
            await SendEmail(confirmationEmail);
        }


        /// <summary>
        /// Crée et retourne un objet EmailVM pour la rappel de consultation.
        /// </summary>
        /// <param name="consultation">La consultation pour laquelle un rappel est générée.</param>
        public async Task<EmailVM> CreateReminderEmail(Consultation consultation, Patient patient, NotificationTime notificationTime)
        {
            var subject = "Rappel de Consultation";
            var body = $"    <p>Bonjour, {patient.Nom} {patient.Prenom} !</p>" +
                        $"    <p>Ceci est un rappel pour votre consultation prévue pour :</p>" +
                        $"    <h3 style=\"color:red;\">{consultation.HeureDateDebutPrevue.ToShortDateString()} à {consultation.HeureDateFinPrevue.ToShortTimeString()}</h3>" +
                        $"    <h3 style=\"color:red;\">Clinique : {consultation.PlageHoraire.ListeAttente.Clinique.NomClinique}</h3>" +
                        $"    <p>Nous vous attendons avec impatience.</p>" +
                        $"    <p>Cordialement,<br />L'équipe Clinique2000</p>";
            var user = await _patientService.GetUserByUserId(patient.UserId);
            return new EmailVM
            {
                To = user.Email,
                Subject = subject,
                Body = body
            };
        }

        /// <summary>
        /// Envoie une notification de consultation pour la consultation spécifiée.
        /// </summary>
        /// <param name="consultation">La consultation pour laquelle la notification est envoyée.</param>
        /// <param name="notificationTime">Le moment de la notification.</param>
        public async Task SendConsultationNotificationAsync(Consultation consultation, NotificationTime notificationTime)
        {
            var reminderEmail = await CreateReminderEmail(consultation, consultation.Patient, notificationTime);
            // Vérifier si la notification a déjà été envoyée pour cet email et ce NotificationTime
            if (await IsNotificationAlreadySent(reminderEmail.To, notificationTime))
            {
                return; // Ne pas renvoyer la notification
            }
            await SendEmail(reminderEmail);
            // Mise à jour de la structure de données avec les informations relatives à la notification envoyée
            await UpdateSentNotifications(reminderEmail.To, notificationTime);
        }

        /// <summary>
        /// Crée et retourne un objet EmailVM pour la notification d'importation du patient.
        /// </summary>
        /// <param name="patient">PATIENT</param>
        /// <returns> EmailVM/// </returns>
        public async Task<EmailVM> CreateNotification_PatientImport_Async(Patient patient)
        {
            var subject = "Importation de votre dossier patient";
            var body = $"    <p>Bonjour, {patient.Nom} {patient.Prenom} !</p>" +
                        $"    <p>Votre dossier de patient a été importé avec succès dans notre système - Clinique2000.</p>" +
                        $"    <p>Vous pouvez maintenant accéder à votre dossier patient en ligne.</p>" +
                        $"    <p>Cordialement,<br />L'équipe Clinique2000</p>";
     
            return new EmailVM
            {
                To = patient.Courriel,
                Subject = subject,
                Body = body
            }; 
        }


        /// <summary>
        /// Envoie une notification pour l'importation du patient spécifié.
        /// </summary>
        /// <param name="patient"> patient/// </param>
        public async Task SendNotificationPatienImportAsync(Patient patient)
        {
            var notificationEmail = await CreateNotification_PatientImport_Async(patient);
            await SendEmail(notificationEmail);
        }

        /// <summary>
        /// Vérifie si une notification a déjà été envoyée pour une adresse e-mail et un moment donné.
        /// </summary>
        /// <param name="email">L'adresse e-mail pour laquelle vérifier l'envoi de la notification.</param>
        /// <param name="notificationTime">Le moment auquel vérifier l'envoi de la notification.</param>
        /// <returns>True si une notification a déjà été envoyée pour l'adresse e-mail et le moment donné ; sinon, False.</returns>
        private async Task<bool> IsNotificationAlreadySent(string email, NotificationTime notificationTime)
        {
            if (_sentNotifications.ContainsKey(email))
            {
                return _sentNotifications[email].Contains(notificationTime);
            }
            return false;
        }

        /// <summary>
        /// Met à jour les notifications envoyées pour une adresse e-mail avec le moment donné.
        /// </summary>
        /// <param name="email">L'adresse e-mail pour laquelle mettre à jour les notifications envoyées.</param>
        /// <param name="notificationTime">Le moment auquel mettre à jour les notifications envoyées.</param>
        private async Task UpdateSentNotifications(string email, NotificationTime notificationTime)
        {
            if (!_sentNotifications.ContainsKey(email))
            {
                _sentNotifications[email] = new HashSet<NotificationTime>();
            }
            _sentNotifications[email].Add(notificationTime);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Nettoie les notifications envoyées en supprimant celles qui ont expiré.
        /// </summary>
        /// <exception cref="ArgumentException">NotificationTime is not valid</exception>
        public async Task CleanUpSentNotifications()
        {
            var currentTime = DateTime.Now;

            foreach (var entry in _sentNotifications.ToList())
            {
                var email = entry.Key;
                var notificationTimes = entry.Value;

                foreach (var notificationTime in notificationTimes.ToList())
                {
                    DateTime notificationTimeThreshold;
                    switch (notificationTime)
                    {
                        case NotificationTime.UnJourAvant:
                            notificationTimeThreshold = currentTime.AddHours(-24);
                            break;
                        case NotificationTime.DouzeHeuresAvant:
                            notificationTimeThreshold = currentTime.AddHours(-12);
                            break;
                        case NotificationTime.SixHeuresAvant:
                            notificationTimeThreshold = currentTime.AddHours(-6);
                            break;
                        case NotificationTime.UneHeureAvant:
                            notificationTimeThreshold = currentTime.AddHours(-1);
                            break;
                        default:
                            throw new ArgumentException("NotificationTime is not valid.");
                    }

                    // Verifier si l'heure de la notification est antérieure au seuil de temps.
                    if (notificationTimeThreshold < currentTime)
                    {
                        // Supprimer la notification expirée de la collection associée
                        _sentNotifications[email].Remove(notificationTime);

                        // S'il n'y a plus de notifications pour cette adresse e-mail, nous supprimons également l'entrée du dictionnaire.
                        if (_sentNotifications[email].Count == 0)
                        {
                            _sentNotifications.Remove(email);
                        }
                    }
                }
            }
            await Task.CompletedTask;
        }

      
        /// <summary>
        /// Méthode pour supprimer du dictionnaire tous les enregistrements associés à un courriel
        /// </summary>
        /// <param name="email">Courriel</param>
        private async Task RemoveEntriesForEmail(string email)
        {
            // Vérifier si le dictionnaire contient la clé spécifiée
            if (_sentNotifications.ContainsKey(email))
            {
                // Supprimer l'ensemble de l'entrée associée à l'e-mail spécifié
                _sentNotifications.Remove(email);
            }
            await Task.CompletedTask;
        }



        /// <summary>
        /// Supprime toutes les notifications associées à un patient après la fin de la consultation.
        /// </summary>
        /// <param name="patient"> patient </param>
        public async Task ConsultationCompleted(Patient patient)
        {
            var user = await _patientService.GetUserByUserId(patient.UserId);
            string patientEmail = user.Email;

            // Supprimer du dictionnaire tous les enregistrements associés à l'adresse électronique du patient.
            await RemoveEntriesForEmail(patientEmail);
        }

    }
}
