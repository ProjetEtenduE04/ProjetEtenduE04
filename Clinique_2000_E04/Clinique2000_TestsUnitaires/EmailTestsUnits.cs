using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Clinique2000_MVC.Areas.Patients.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Clinique2000_Utility.Enum;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Clinique2000_TestsUnitaires
{
    public class EmailTestsUnits
    {
        private readonly Mock<IPatientService> _patientServiceMock = new Mock<IPatientService>();
        private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();

        public EmailTestsUnits()
        {
            _emailServiceMock = new Mock<IEmailService>();
            _patientServiceMock = new Mock<IPatientService>();
        }


        //[Fact]
        //public void SendEmail_ShouldNotThrowException()
        //{
        //    // Arrange
        //    var configMock = new Mock<IConfiguration>();
        //    var patientServiceMock = new Mock<IPatientService>();
        //    var emaisServiceMock = new Mock<IEmailService>();
        //    var userMock = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        //   {
        //new Claim(ClaimTypes.Email, "test@example.com")
        //   }, "mock"));

        //    var user = new ApplicationUser
        //    {
        //        Id = "1",
        //        Email = "test@test.test"
        //    };
        //    //patientServiceMock.Setup(ps => ps.GetUserAuth()).ReturnsAsync(user);

        //    var emailService = new EmailService(configMock.Object, patientServiceMock.Object);

        //    var emailRequest = new EmailVM
        //    {
        //        To = user.Email,
        //        Subject = "Test Subject",
        //        Body = "Test Body"
        //    };

        //        // Assert
        //        // Poți adăuga orice aserțiune suplimentară aici, dacă este necesar
        //        Assert.ThrowsAny<Exception>(() => emailService.SendEmail(emailRequest));
        //}


        [Fact]
        public async Task CreateConsultationConfirmationEmail_ShouldReturnValidEmailVM()
        {
            // Arrange
            var configMock = new Mock<IConfiguration>();
            var patientServiceMock = new Mock<IPatientService>();
            var userMock = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
           {
                new Claim(ClaimTypes.Email, "test@example.com")
           }, "mock"));

            var user = new ApplicationUser
            {
                Id = "1",
                Email = "test@test.test"
            };
            var emailService = new EmailService(configMock.Object, patientServiceMock.Object);

            var consultation = new Consultation
            {
                Patient = new Patient
                {
                    Nom = "Doe",
                    Prenom = "John"
                },
                PlageHoraire = new PlageHoraire
                {
                    HeureDebut = DateTime.Now,
                    HeureFin = DateTime.Now.AddHours(1),
                    ListeAttente = new ListeAttente
                    {
                        Clinique = new Clinique
                        {
                            NomClinique = "Clinique2000"
                        }
                    }

                }
            };

            patientServiceMock.Setup(ps => ps.GetUserAuthAsync()).ReturnsAsync(user);

            // Act
            var result = await emailService.CreateConsultationConfirmationEmail(consultation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.To);
            Assert.Equal("Confirmation de réservation Consultation", result.Subject);

            Assert.Contains(consultation.Patient.Nom, result.Body);
            Assert.Contains(consultation.Patient.Prenom, result.Body);

            Assert.Contains(consultation.PlageHoraire.HeureDebut.ToShortDateString(), result.Body);
            Assert.Contains(consultation.PlageHoraire.HeureDebut.ToShortTimeString(), result.Body);

        }

        [Fact]
        public async Task CreateReminderEmail_ShouldReturnValidEmailVM()
        {
            // Arrange
            var configMock = new Mock<IConfiguration>();
            var patientServiceMock = new Mock<IPatientService>();
            var user = new ApplicationUser
            {
                Id = "1",
                Email = "test@test.test"
            };

            var emailService = new EmailService(configMock.Object, patientServiceMock.Object);

            var consultation = new Consultation
            {
                Patient = new Patient
                {
                    Nom = "Doe",
                    Prenom = "John",
                    UserId = "1" // Id-ul utilizatorului
                },
                PlageHoraire = new PlageHoraire
                {
                    HeureDebut = DateTime.Now.AddHours(24), // Exemplu, data și ora pentru consultație
                    ListeAttente = new ListeAttente
                    {
                        Clinique = new Clinique
                        {
                            NomClinique = "Clinique2000" // Numele clinicii
                        }
                    }
                }
            };

            patientServiceMock.Setup(ps => ps.GetUserByUserId(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await emailService.CreateReminderEmail(consultation, consultation.Patient, NotificationTime.UneHeureAvant);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.To);
            Assert.Equal("Rappel de Consultation", result.Subject);

            // Verificăm dacă corpul email-ului conține informațiile corecte despre consultație și pacient
            Assert.Contains(consultation.Patient.Nom, result.Body);
            Assert.Contains(consultation.Patient.Prenom, result.Body);
            Assert.Contains(consultation.PlageHoraire.HeureDebut.ToShortDateString(), result.Body);
            Assert.Contains(consultation.PlageHoraire.HeureDebut.ToShortTimeString(), result.Body);
            Assert.Contains("Clinique : Clinique2000", result.Body);
        }

        //[Fact]
        //public async Task SendConsultationConfirmationEmail_ShouldCallMethods()
        //{
        //    // Arrange


        //    var user = new ApplicationUser
        //    {
        //        Id = "7cc96785-8933-4eac-8d7f-a289b28df223",
        //        Email = "test@test.test"
        //    };
        //    var consultation = new Consultation
        //    {
        //        ConsultationID = 1,
        //        StatutConsultation = StatutConsultation.EnAttente,
        //        PlageHoraireID = 1,
        //        PatientID = 1,

        //        Patient = new Patient
        //        {
        //            PatientId = 1,
        //            Nom = "Eastwood",
        //            Prenom = "Clint",
        //            Genre = "Masculin",
        //            NAM = "EASC 2342 4332",
        //            CodePostal = "J4J 1Z4",
        //            DateDeNaissance = new DateTime(1990, 1, 1),
        //            Age = 32,
        //            UserId = "7cc96785-8933-4eac-8d7f-a289b28df223"
        //        },
        //        PlageHorarie = new PlageHoraire
        //        {
        //            PlageHoraireID = 1,
        //            HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(0),
        //            HeureFin = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
        //            ListeAttenteID = 1,
        //        }
        //    };

        //    var emailRequest = new EmailVM
        //    {
        //        To = user.Email,
        //        Subject = "Test Subject",
        //        Body = "Test Body"
        //    };

        //    _patientServiceMock.Setup(ps => ps.GetUserAuth()).ReturnsAsync(user);

        //    var emailService = new EmailService(null, _patientServiceMock.Object);

        //    // Act
        //    emailService.SendEmail(emailRequest);

        //    // Assert
        //    _emailServiceMock.Verify(es => es.CreateConsultationConfirmationEmail(consultation), Times.Once);
        //}

        //[Fact]
        //public async Task Execute_SendsEmailNotifications()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<EmailService>>();
        //    var emailServiceMock = new Mock<IEmailService>();
        //    var consultationServiceMock = new Mock<IConsultationService>();

        //    var consultation1 = new Consultation { StatutConsultation = StatutConsultation.EnAttente, HeureDateDebutPrevue = DateTime.Now.AddDays(1) };
        //    var consultation2 = new Consultation { StatutConsultation = StatutConsultation.EnAttente, HeureDateDebutPrevue = DateTime.Now.AddHours(12) };
        //    var consultation3 = new Consultation { StatutConsultation = StatutConsultation.EnAttente, HeureDateDebutPrevue = DateTime.Now.AddHours(5) };
        //    var consultation4 = new Consultation { StatutConsultation = StatutConsultation.EnAttente, HeureDateDebutPrevue = DateTime.Now.AddHours(1) };

        //    consultationServiceMock.Setup(x => x.ObtenirToutAsync()).ReturnsAsync(new List<Consultation> { consultation1, consultation2, consultation3, consultation4 });

        //    emailServiceMock.Verify(x => x.SendConsultationNotificationAsync(consultation1, NotificationTime.UnJourAvant), Times.Once);
        //    emailServiceMock.Verify(x => x.SendConsultationNotificationAsync(consultation2, NotificationTime.DouzeHeuresAvant), Times.Once);
        //    emailServiceMock.Verify(x => x.SendConsultationNotificationAsync(consultation3, NotificationTime.SixHeuresAvant), Times.Once);
        //    emailServiceMock.Verify(x => x.SendConsultationNotificationAsync(consultation4, NotificationTime.UneHeureAvant), Times.Once);

        //    var jobService = new EmailBackgroundJobService(loggerMock.Object, emailServiceMock.Object, consultationServiceMock.Object);
        //    var jobExecutionContextMock = new Mock<IJobExecutionContext>();

        //    // Act
        //    await jobService.Execute(jobExecutionContextMock.Object);

        //    // Assert
        //    emailServiceMock.Verify();
        //}
        [Fact]
        public async Task Execute_SendsEmailOneDayBefore_WhenConsultationIsOneDayAway()
        {
            // Arrange
            var mockConsultationService = new Mock<IConsultationService>();
            var mockEmailService = new Mock<IEmailService>();
            var consultations = new List<Consultation>()
            {
                new Consultation()
                {
                    HeureDateDebutPrevue = DateTime.Now.AddDays(1).AddHours(10),
                    StatutConsultation = StatutConsultation.EnAttente
                }
            };

            mockConsultationService.Setup(s => s.ObtenirToutAsync()).Returns(Task.FromResult(consultations));

            var service = new EmailBackgroundJobService(Mock.Of<ILogger<EmailService>>(), mockEmailService.Object, mockConsultationService.Object);

            // Act
            await service.Execute(It.IsAny<IJobExecutionContext>());

            // Assert
            mockEmailService.Verify(es => es.SendConsultationNotificationAsync(It.IsAny<Consultation>(), NotificationTime.UnJourAvant), Times.Once);
        }
        [Fact]
        public async Task Execute_SendsEmailTwelveHoursBefore_WhenConsultationIsTwelveHoursAway()
        {
            // Arrange
            var mockConsultationService = new Mock<IConsultationService>();
            var mockEmailService = new Mock<IEmailService>();
            var consultations = new List<Consultation>()
            {
                new Consultation()
                {
                    HeureDateDebutPrevue = DateTime.Now.AddHours(18),
                    StatutConsultation = StatutConsultation.EnAttente
                }
            };

            mockConsultationService.Setup(s => s.ObtenirToutAsync()).Returns(Task.FromResult(consultations));

            var service = new EmailBackgroundJobService(Mock.Of<ILogger<EmailService>>(), mockEmailService.Object, mockConsultationService.Object);

            // Act
            await service.Execute(It.IsAny<IJobExecutionContext>());

            // Assert
            mockEmailService.Verify(es => es.SendConsultationNotificationAsync(It.IsAny<Consultation>(), NotificationTime.DouzeHeuresAvant), Times.Once);
        }

        [Fact]
        public async Task Execute_SendsEmailSixHoursBefore_WhenConsultationIsSixHoursAway()
        {
            // Arrange
            var mockConsultationService = new Mock<IConsultationService>();
            var mockEmailService = new Mock<IEmailService>();
            var consultations = new List<Consultation>()
            {
                new Consultation()
                {
                    HeureDateDebutPrevue = DateTime.Now.AddHours(7),
                    StatutConsultation = StatutConsultation.EnAttente
                }
            };

            mockConsultationService.Setup(s => s.ObtenirToutAsync()).Returns(Task.FromResult(consultations));

            var service = new EmailBackgroundJobService(Mock.Of<ILogger<EmailService>>(), mockEmailService.Object, mockConsultationService.Object);

            // Act
            await service.Execute(It.IsAny<IJobExecutionContext>());

            // Assert
            mockEmailService.Verify(es => es.SendConsultationNotificationAsync(It.IsAny<Consultation>(), NotificationTime.SixHeuresAvant), Times.Once);
        }
    }
}

