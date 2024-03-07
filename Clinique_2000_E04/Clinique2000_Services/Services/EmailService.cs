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
        public void SendEmail(EmailVM request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.Auto);
                smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
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
                        $"    <h3 style=\"color:red;\">{consultation.PlageHoraire.HeureDebut.ToShortDateString()} à {consultation.PlageHoraire.HeureDebut.ToShortTimeString()}</h3>" +
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
            SendEmail(confirmationEmail);
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
                        $"    <h3 style=\"color:red;\">{consultation.PlageHoraire.HeureDebut.ToShortDateString()} à {consultation.PlageHoraire.HeureDebut.ToShortTimeString()}</h3>" +
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
            // Verificați dacă notificarea a mai fost trimisă pentru acest e-mail și acest NotificationTime
            if (IsNotificationAlreadySent(reminderEmail.To, notificationTime))
            {
                return; // Nu trimiteți din nou notificarea
            }
            SendEmail(reminderEmail);
            // Actualizați structura de date cu informații despre notificarea trimisă
            UpdateSentNotifications(reminderEmail.To, notificationTime);
        }

        private bool IsNotificationAlreadySent(string email, NotificationTime notificationTime)
        {
            if (_sentNotifications.ContainsKey(email))
            {
                return _sentNotifications[email].Contains(notificationTime);
            }
            return false;
        }

        private void UpdateSentNotifications(string email, NotificationTime notificationTime)
        {
            if (!_sentNotifications.ContainsKey(email))
            {
                _sentNotifications[email] = new HashSet<NotificationTime>();
            }
            _sentNotifications[email].Add(notificationTime);
        }


        public void CleanUpSentNotifications()
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

                    // Verificăm dacă timpul notificării este mai vechi decât pragul de timp
                    if (notificationTimeThreshold < currentTime)
                    {
                        // Ștergem notificarea expirată din colecția asociată
                        _sentNotifications[email].Remove(notificationTime);

                        // Dacă nu mai există alte notificări pentru această adresă de e-mail, ștergem și intrarea din dicționar
                        if (_sentNotifications[email].Count == 0)
                        {
                            _sentNotifications.Remove(email);
                        }
                    }
                }
            }
        }


    }
}
