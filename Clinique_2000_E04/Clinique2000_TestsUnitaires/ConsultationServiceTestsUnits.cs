//using Clinique2000_Core.Models;
//using Clinique2000_DataAccess.Data;
//using Clinique2000_Services.Services;
//using Microsoft.EntityFrameworkCore;
//using Xunit;
//using System.Threading.Tasks;
//using Clinique2000_Utility.Enum;
//using Xunit.Abstractions;
//using Moq;
//using Clinique2000_Services.IServices;
//using Microsoft.AspNetCore.Http;
//using System.ComponentModel.DataAnnotations;
//using System.Linq.Expressions;
//using System.Security.Claims;

//namespace Clinique2000_TestsUnitaires
//{
//    public class ConsultationServiceTestsUnits
//    {
//        private readonly Mock<IPatientService> _mockPatientService;
//        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;

//        public ConsultationServiceTestsUnits()
//        {
//            _mockPatientService = new Mock<IPatientService>();
//            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
//        }

//        private CliniqueDbContext CreateAndSeedContext()
//        {
//            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
//                .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                .Options;

//            var context = new CliniqueDbContext(options);
//            context.Database.EnsureDeleted();
//            context.Database.EnsureCreated();

//            SeedInMemoryStore(context);
//            return context;
//        }

//        public static void SeedInMemoryStore(CliniqueDbContext dbContext)
//        {
//            dbContext.Database.EnsureDeleted();
//            dbContext.Database.EnsureCreated();

//            // Check if the database has been seeded
//            if (dbContext.Cliniques.Any())
//            {
//                return; // Data already seeded, no need to seed again
//            }

//            dbContext.Database.EnsureCreated();

//            // Seed Clinique data
//            var clinique = new Clinique { CliniqueID = int.MaxValue, TempsMoyenConsultation = 30 };
//            dbContext.Cliniques.Add(clinique);

//            // Seed ListeAttente data
//            var listeAttente = new ListeAttente { ListeAttenteID = 1, CliniqueID = int.MaxValue, IsOuverte = true };
//            dbContext.ListeAttentes.Add(listeAttente);

//            // Seed PlageHoraire data
//            var plageHoraire = new PlageHoraire { PlageHoraireID = 1, HeureDebut = DateTime.Now, HeureFin = DateTime.Now.AddHours(1), ListeAttenteID = 1 };
//            dbContext.PlagesHoraires.Add(plageHoraire);

//            // Seed ApplicationUser (and Patient) data
//            var user = new ApplicationUser { UserName = "user1", Email = "user1@example.com" };
//            dbContext.ApplicationUser.Add(user);
//            dbContext.SaveChanges(); // Save to generate user Id

//            var patient = new Patient
//            {
//                PatientId = 1,
//                Age = 30,
//                UserId = user.Id,
//                CodePostal = "J4G 1T2", // Example data
//                NAM = "COUJ 2222 2222", // Example data
//                Nom = "Doe", // Example data
//                Prenom = "John" // Example data
//            };
//            dbContext.Patients.Add(patient);

//            // Seed Consultation data
//            var consultationReady = new Consultation
//            {
//                ConsultationID = 1,
//                StatutConsultation = StatutConsultation.DisponiblePourReservation,
//                // Ensure this ID exists in your seeded PlageHoraires
//                PlageHoraireID = 1,
//                // Important: make sure no patient is initially assigned
//                PatientID = null
//            };
//            dbContext.Consultations.Add(consultationReady);

//            // Seed Consultation data - Already planned for the patient
//            var consultationPlanned = new Consultation
//            {
//                ConsultationID = 2,
//                HeureDateDebutPrevue = DateTime.Now.AddHours(2),
//                HeureDateFinPrevue = DateTime.Now.AddHours(3),
//                StatutConsultation = StatutConsultation.EnAttente,
//                PlageHoraireID = 1,
//                PatientID = 1
//            };
//            dbContext.Consultations.Add(consultationPlanned);

//            dbContext.SaveChanges();
//        }


//        [Fact]
//        public async Task ReserverConsultationAsync_ThrowsValidationException_ForNonExistentConsultation()
//        {
//            using (var context = CreateAndSeedContext())
//            {
//                var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
//                int nonExistentConsultationId = -1; // ID that doesn't exist in the seeded data

//                // Act & Assert
//                var exception = await Assert.ThrowsAsync<ValidationException>(
//                    () => service.ReserverConsultationAsync(nonExistentConsultationId));

//                Assert.Equal("Consultation introuvable.", exception.Message);
//            }
//        }



//        [Fact]
//        public async Task ReserverConsultationAsync_SuccessfulReservation()
//        {
//            using (var context = CreateAndSeedContext())
//            {
//                var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
//                int consultationId = 1; // Assuming this ID exists in the seeded data

//                // Mock IHttpContextAccessor to simulate a logged-in user
//                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
//                {
//            new Claim(ClaimTypes.NameIdentifier, "userId")
//                }));
//                _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

//                // Act
//                await service.ReserverConsultationAsync(consultationId);

//                // Assert
//                using (var assertContext = CreateAndSeedContext()) // Create a new context for assertions
//                {
//                    var consultation = await assertContext.Consultations.FindAsync(consultationId);
//                    Assert.NotNull(consultation);
//                    Assert.Equal(StatutConsultation.EnAttente, consultation.StatutConsultation);
//                }
//            }
//        }



//    }




//}

using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using Clinique2000_Utility.Enum;
using Moq;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System;
using Clinique2000_DataAccess.Data;

namespace Clinique2000_TestsUnitaires
{
    public class ConsultationServiceTestsUnits
    {
        private readonly Mock<IPatientService> _mockPatientService;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;

        public ConsultationServiceTestsUnits()
        {
            _mockPatientService = new Mock<IPatientService>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        }

        private CliniqueDbContext CreateAndSeedContext()
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new CliniqueDbContext(options);

            // Seed the in-memory database with data resembling your real database
            SeedInMemoryStore(context);

            return context;
        }

        private void SeedInMemoryStore(CliniqueDbContext dbContext)
        {
            // Seed your in-memory database with data resembling your real database
            var clinique = new Clinique { CliniqueID = 1, TempsMoyenConsultation = 30 };
            dbContext.Cliniques.Add(clinique);

            var listeAttente = new ListeAttente { ListeAttenteID = 1, CliniqueID = 1, IsOuverte = true };
            dbContext.ListeAttentes.Add(listeAttente);

            var plageHoraire = new PlageHoraire { PlageHoraireID = 1, HeureDebut = DateTime.Now, HeureFin = DateTime.Now.AddHours(1), ListeAttenteID = 1 };
            dbContext.PlagesHoraires.Add(plageHoraire);

            var user = new ApplicationUser { UserName = "user1", Email = "user1@example.com" };
            dbContext.ApplicationUser.Add(user);
            dbContext.SaveChanges(); // Save to generate user Id

            var patient = new Patient
            {
                PatientId = 1,
                Age = 30,
                UserId = user.Id,
                CodePostal = "J4G 1T2",
                NAM = "COUJ 2222 2222",
                Nom = "Doe",
                Prenom = "John"
            };
            dbContext.Patients.Add(patient);

            var consultationReady = new Consultation
            {
                ConsultationID = 1,
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 1,
                PatientID = null
            };
            dbContext.Consultations.Add(consultationReady);

            var consultationPlanned = new Consultation
            {
                ConsultationID = 2,
                HeureDateDebutPrevue = DateTime.Now.AddHours(2),
                HeureDateFinPrevue = DateTime.Now.AddHours(3),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 1,
                PatientID = 1
            };
            dbContext.Consultations.Add(consultationPlanned);

            dbContext.SaveChanges();
        }

        [Fact]
        public async Task ReserverConsultationAsync_ThrowsValidationException_ForNonExistentConsultation()
        {
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int nonExistentConsultationId = -1;

            var exception = await Assert.ThrowsAsync<ValidationException>(() => service.ReserverConsultationAsync(nonExistentConsultationId));

            Assert.Equal("Consultation introuvable.", exception.Message);
        }

        [Fact]
        public async Task ReserverConsultationAsync_SuccessfulReservation()
        {
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int consultationId = 1;

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "userId")
            }));
            _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            await service.ReserverConsultationAsync(consultationId);

            var consultation = await context.Consultations.FindAsync(consultationId);
            Assert.NotNull(consultation);
            Assert.Equal(StatutConsultation.EnAttente, consultation.StatutConsultation);
        }



        [Fact]
        public async Task ReserverConsultationAsync_ThrowsValidationException_WhenListeAttenteIsClosed()
        {
            // Arrange
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int consultationId = 1; // Assuming this ID corresponds to a consultation with a closed Liste d'attente in the seeded data

            // Find the PlageHoraire associated with the consultation
            var plageHoraire = await context.PlagesHoraires.FirstOrDefaultAsync(ph => ph.PlageHoraireID == consultationId);

            if (plageHoraire != null)
            {
                // Modify the ListeAttente associated with the PlageHoraire to be closed
                plageHoraire.ListeAttente.IsOuverte = false;
                await context.SaveChangesAsync();
            }

            // Mock IHttpContextAccessor to simulate a logged-in user
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
        new Claim(ClaimTypes.NameIdentifier, "userId")
            }));
            _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => service.ReserverConsultationAsync(consultationId));

            Assert.Equal("La liste d'attente est fermée.", exception.Message);
        }


        [Fact]
        public async Task PatientAConsultationPlanifiee_ThrowsValidationException_WhenPatientHasScheduledConsultation()
        {
            // Arrange
            using (var context = CreateAndSeedContext())
            {
                var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
                int patientId = 1; // Assuming this patient has an existing scheduled consultation in the seeded data

                // Act & Assert
                var exception = await Assert.ThrowsAsync<ValidationException>(
                    () => service.PatientAConsultationPlanifiee(patientId));

                Assert.Equal("Le patient a déjà une consultation planifiée.", exception.Message);
            }
        }



    }
}

