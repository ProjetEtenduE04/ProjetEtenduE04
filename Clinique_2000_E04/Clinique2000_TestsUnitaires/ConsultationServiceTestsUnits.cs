using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using Clinique2000_Utility.Enum;
using Xunit.Abstractions;

namespace Clinique2000_TestsUnitaires
{
    public class ConsultationServiceTestsUnits
    {

        //private readonly CliniqueDbContext dbTest;
        //public ConsultationServiceTestsUnits()
        //{
        //    var options = SetUpInMemory("CliniqueTestDb");
        //    dbTest = new CliniqueDbContext(options);
        //    //seed les données
        //    SeedInMemoryStore(dbTest);
        //}

        ////Preparer des valeurs 
        //private void SeedInMemoryStore(CliniqueDbContext dbTest)
        //{


        //    if (!dbTest.Cliniques.Any())
        //    {
        //        dbTest.Cliniques.AddRange(
        //         new Clinique { CliniqueID = 1, TempsMoyenConsultation = 30 },
        //         new Clinique { CliniqueID = 2, TempsMoyenConsultation = 20 },
        //         new Clinique { CliniqueID = 3, TempsMoyenConsultation = 30 }
        //         );
        //        dbTest.SaveChanges();
        //    }

        //    if (!dbTest.ListeAttentes.Any())
        //    {
        //        dbTest.ListeAttentes.AddRange(
        //         new ListeAttente { ListeAttenteID = 1, DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 },
        //         new ListeAttente { ListeAttenteID = 2, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 0, CliniqueID = 1 },
        //         new ListeAttente { ListeAttenteID = 3, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 3 },
        //         new ListeAttente { ListeAttenteID = 4, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 2 }


        //         );
        //        dbTest.SaveChanges();
        //    }

        //}

        //private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        //{
        //    var options = new DbContextOptionsBuilder<CliniqueDbContext>()
        //        .UseInMemoryDatabase(uniqueName).Options;
        //    return options;
        //}



        //[Fact]
        //public async Task ReserverConsultationAsync_ShouldReserveConsultation_WhenAllValidationsPass()
        //{
        //    // Arrange
        //    var consultationService = new ConsultationService(dbTest);

        //    int patientId = 1; // ID de test
        //    var consultation = new Consultation
        //    {
        //        ConsultationID = 1,
        //        StatutConsultation = StatutConsultation.DisponiblePourReservation,
        //        HeureDateDebutPrevue = DateTime.MinValue,
        //        HeureDateFinPrevue = DateTime.MaxValue,
                
        //    };

        //    // Act
        //    await consultationService.ReserverConsultationAsync(patientId, consultation);

        //    // Assert
        //    var reservedConsultation = dbTest.Consultations.Find(consultation.ConsultationID);
        //    Assert.NotNull(reservedConsultation);
        //    Assert.Equal(patientId, reservedConsultation.PatientID);
        //    Assert.Equal(StatutConsultation.EnAttente, reservedConsultation.StatutConsultation);
        //}
    }
}