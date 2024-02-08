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
                PlageHorarie = new PlageHoraire
                {
                    HeureDebut = DateTime.Now,
                    HeureFin = DateTime.Now.AddHours(1)
                }
            };

            patientServiceMock.Setup(ps => ps.GetUserAuth()).ReturnsAsync(user);

            // Act
            var result = await emailService.CreateConsultationConfirmationEmail(consultation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.To);
            Assert.Equal("Confirmation de réservation Consultation", result.Subject);

            Assert.Contains(consultation.Patient.Nom, result.Body);
            Assert.Contains(consultation.Patient.Prenom, result.Body);

            Assert.Contains(consultation.PlageHorarie.HeureDebut.ToShortDateString(), result.Body);
            Assert.Contains(consultation.PlageHorarie.HeureDebut.ToShortTimeString(), result.Body);

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
    }
}

