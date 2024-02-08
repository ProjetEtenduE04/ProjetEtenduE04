using Clinique2000_Services.IServices;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Clinique2000_Core.ViewModels;
using Clinique2000_Core.Models;

namespace Clinique2000_Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly IPatientService _patientService;

        public EmailService(IConfiguration config, IPatientService patientService)
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
            var user = await _patientService.GetUserAuth();
            var patient = consultation.Patient;
            var subject = "Confirmation de réservation Consultation";
            var body =  $"    <p>Bonjour, {patient.Nom} {consultation.Patient.Prenom} !</p>" +
                        $"    <p>Nous confirmons la réservation de la consultation prévue pour :</p>" +
                        $"    <h3 style=\"color:red;\">{consultation.PlageHorarie.HeureDebut.ToShortDateString()} à {consultation.PlageHorarie.HeureDebut.ToShortTimeString()}</h3>" +
                        $"    <h3 style=\"color:red;\">Clinique : {consultation.PlageHorarie.ListeAttente.Clinique.NomClinique}</h3>" +
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
    }
}
