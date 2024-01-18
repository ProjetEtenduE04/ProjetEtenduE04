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

        private readonly CliniqueDbContext dbTest;
        public ConsultationServiceTestsUnits()
        {
            var options = SetUpInMemory("CliniqueTestDb");
            dbTest = new CliniqueDbContext(options);
            //seed les données
            SeedInMemoryStore(dbTest);
        }

        //Preparer des valeurs 
        private void SeedInMemoryStore(CliniqueDbContext dbTest)
        {


            if (!dbTest.Cliniques.Any())
            {
                dbTest.Cliniques.AddRange(
                 new Clinique { CliniqueID = 1, TempsMoyenConsultation = 30 },
                 new Clinique { CliniqueID = 2, TempsMoyenConsultation = 20 },
                 new Clinique { CliniqueID = 3, TempsMoyenConsultation = 30 }
                 );
                dbTest.SaveChanges();
            }

            if (!dbTest.ListeAttentes.Any())
            {
                dbTest.ListeAttentes.AddRange(
                 new ListeAttente { ListeAttenteID = 1, DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1,IsOuverte=true,DureeConsultationMinutes=15 },
                 new ListeAttente { ListeAttenteID = 2, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 0, CliniqueID = 1 },
                 new ListeAttente { ListeAttenteID = 3, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 3 },
                 new ListeAttente { ListeAttenteID = 4, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 2 }


                 );
                dbTest.SaveChanges();
            }

            if (!dbTest.PlagesHoraires.Any())
            {
                dbTest.PlagesHoraires.AddRange(
                    new PlageHoraire { PlageHoraireID = 1, HeureDebut = DateTime.Today.AddHours(8), HeureFin = DateTime.Today.AddHours(9), ListeAttenteID = 1 },
                    new PlageHoraire { PlageHoraireID = 2, HeureDebut = DateTime.Today.AddHours(9), HeureFin = DateTime.Today.AddHours(10), ListeAttenteID = 1 }
                    // Ajoutez d'autres PlageHoraire ici selon vos besoins
                ) ;
                dbTest.SaveChanges();
            }

            if (!dbTest.Consultations.Any())
            {
                dbTest.Consultations.AddRange(
                    new Consultation { ConsultationID = 1, PlageHoraireID = 1, StatutConsultation = StatutConsultation.DisponiblePourReservation, HeureDateDebutPrevue = DateTime.Today.AddHours(8), HeureDateFinPrevue = DateTime.Today.AddHours(9) },
                    new Consultation { ConsultationID = 2, PlageHoraireID = 2, StatutConsultation = StatutConsultation.DisponiblePourReservation, HeureDateDebutPrevue = DateTime.Today.AddHours(9), HeureDateFinPrevue = DateTime.Today.AddHours(10) }
                    // Ajoutez d'autres Consultations ici selon vos besoins
                );
                dbTest.SaveChanges();
            }

            if (!dbTest.Patients.Any())
            {
                dbTest.Patients.AddRange(
                    new Patient { PatientId = 1, Nom = "Doe", Prenom = "John", NAM = "ABCD 1234 5678", CodePostal = "A1A 1A1", DateDeNaissance = new DateTime(1980, 1, 1), Age = 40,UserId="User1" },
                    new Patient { PatientId = 2, Nom = "Smith", Prenom = "Jane", NAM = "EFGH 1234 5678", CodePostal = "B2B 2B2", DateDeNaissance = new DateTime(1990, 2, 2), Age = 30, UserId = "User2" }
                    // Ajoutez d'autres Patients ici selon vos besoins
                );
                dbTest.SaveChanges();
            }


        }

        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(uniqueName).Options;
            return options;
        }



        //[Fact]
        //public async Task ReserverConsultationAsync_ShouldReserveConsultation_WhenAllValidationsPass()
        //{
        //    // Arrange
        //    var consultationService = new ConsultationService(dbTest);

        //    int patientId = 1; // ID de test
        //    var consultation = dbTest.Consultations.FirstOrDefault(c => c.ConsultationID == 1);

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