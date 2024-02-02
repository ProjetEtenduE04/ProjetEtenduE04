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

    // Create a Clinique with required properties
    var clinique = new Clinique
    {
        CliniqueID = 1,
        TempsMoyenConsultation = 30,
        Courriel = "clinique@example.com",
        CreateurID = "user1",
        HeureOuverture = new TimeSpan(8, 0, 0),   // Opening time (8:00 AM)
        HeureFermeture = new TimeSpan(18, 0, 0),  // Closing time (6:00 PM)
        NomClinique = "Clinique2000"
    };
    dbContext.Cliniques.Add(clinique);

    // Create a ListeAttente associated with the Clinique
    var listeAttente = new ListeAttente
    {
        ListeAttenteID = 1,
        CliniqueID = 1,
        IsOuverte = true
    };
    dbContext.ListeAttentes.Add(listeAttente);

    // Create a PlageHoraire associated with the ListeAttente
    var plageHoraire = new PlageHoraire
    {
        PlageHoraireID = 1,
        HeureDebut = DateTime.Now,
        HeureFin = DateTime.Now.AddHours(1),
        ListeAttenteID = 1
    };
    dbContext.PlagesHoraires.Add(plageHoraire);

    // Create a ApplicationUser (User)
    var user = new ApplicationUser
    {
        UserName = "user1",
        Email = "user1@example.com"
    };
    dbContext.ApplicationUser.Add(user);
    dbContext.SaveChanges(); // Save to generate user Id

    // Create a Patient associated with the User
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

    // Create a Consultation with missing properties and associate with PlageHoraire
    var consultationReady = new Consultation
    {
        ConsultationID = 1,
        StatutConsultation = StatutConsultation.DisponiblePourReservation,
        PlageHoraireID = 1,
        PatientID = null
    };
    dbContext.Consultations.Add(consultationReady);

    // Create another Consultation with missing properties and associate with PlageHoraire
    var consultationPlanned = new Consultation
    {
        ConsultationID = 2,
        //HeureDateDebutPrevue = DateTime.Now.AddHours(2),
        //HeureDateFinPrevue = DateTime.Now.AddHours(3),
        StatutConsultation = StatutConsultation.EnAttente,
        PlageHoraireID = 1,
        PatientID = 1
    };
    dbContext.Consultations.Add(consultationPlanned);

    dbContext.SaveChanges();
}

        /// <summary>
        /// Teste le lancement d'une exception pour une consultation inexistante.
        /// </summary>
        [Fact]
        public async Task ReserverConsultationAsync_ExceptionPourConsultationInexistante()
        {
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int nonExistentConsultationId = -1;

            // Tente de réserver une consultation inexistante et vérifie si une exception est lancée
            var exception = await Assert.ThrowsAsync<ValidationException>(() => service.ReserverConsultationAsync(nonExistentConsultationId));

            Assert.Equal("Consultation introuvable.", exception.Message);
        }

        /// <summary>
        /// Teste la réservation réussie d'une consultation.
        /// </summary>
        [Fact]
        public async Task ReserverConsultationAsync_ReservationReussie()
        {
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int consultationId = 1;

            // Configuration du mock pour simuler un utilisateur connecté
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "userId")
            }));
            _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            // Réserve une consultation et vérifie si le statut est mis à jour correctement
            await service.ReserverConsultationAsync(consultationId);

            var consultation = await context.Consultations.FindAsync(consultationId);
            Assert.NotNull(consultation);
            Assert.Equal(StatutConsultation.EnAttente, consultation.StatutConsultation);
        }

        /// <summary>
        /// Teste le lancement d'une exception si la liste d'attente est fermée.
        /// </summary>
        [Fact]
        public async Task ReserverConsultationAsync_ExceptionSiListeAttenteFermee()
        {
            var context = CreateAndSeedContext();
            var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
            int consultationId = 1;

            var plageHoraire = await context.PlagesHoraires.FirstOrDefaultAsync(ph => ph.PlageHoraireID == consultationId);

            // Ferme la liste d'attente associée et tente une réservation
            if (plageHoraire != null)
            {
                plageHoraire.ListeAttente.IsOuverte = false;
                await context.SaveChangesAsync();
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "userId")
            }));
            _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var exception = await Assert.ThrowsAsync<ValidationException>(() => service.ReserverConsultationAsync(consultationId));

            Assert.Equal("La liste d'attente est fermée.", exception.Message);
        }

        /// <summary>
        /// Teste le lancement d'une exception si le patient a déjà une consultation planifiée.
        /// </summary>
        [Fact]
        public async Task PatientAConsultationPlanifiee_ExceptionSiConsultationDejaExistante()
        {
            using (var context = CreateAndSeedContext())
            {
                var service = new ConsultationService(context, _mockPatientService.Object, _mockHttpContextAccessor.Object);
                int patientId = 1;

                // Vérifie si le patient a déjà une consultation planifiée et attend une exception
                var exception = await Assert.ThrowsAsync<ValidationException>(
                    () => service.PatientAConsultationPlanifieeAsync(patientId));

                Assert.Equal("Vous avez déjà une consultation planifiée.", exception.Message);
            }
        }



    }
}

