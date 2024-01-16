using Xunit;
using Moq;
using Clinique2000_Services.IServices;
using Clinique2000_DataAccess.Data;
using Clinique2000_Core.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.InMemory;
using Clinique2000_Services.Services;
using Xunit.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace Clinique2000_TestsUnitaires
{
    public class ListeAttenteServiceTestsUnits
    {

        private readonly CliniqueDbContext dbTest;
        
        public ListeAttenteServiceTestsUnits()
        {
            var options = SetUpInMemory("CliniqueTestDb");
            dbTest = new CliniqueDbContext(options);
            //seed les données
            SeedInMemoryStore(dbTest);
        }

        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(uniqueName).Options;
            return options;
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
                     new ListeAttente { ListeAttenteID = 1, DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 },
                     new ListeAttente { ListeAttenteID = 2, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 0, CliniqueID = 1 },
                     new ListeAttente { ListeAttenteID = 3, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 3 },
                     new ListeAttente { ListeAttenteID = 4, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 2 }


                     );
                    dbTest.SaveChanges();
                }
            
        }

        [Fact]
        public async Task GenererPlagesHorairesAsync_CreatesCorrectNumberofConsultation()
        {
            IListeAttenteService service = new ListeAttenteService(dbTest);
            var listeAttente = await dbTest.ListeAttentes.FindAsync(1);

            if (listeAttente == null)
            {
                throw new InvalidOperationException("ListeAttente not found.");
            }
            // Act
            await service.GenererPlagesHorairesAsync(listeAttente.ListeAttenteID);

            // Assert
            var consultations = dbTest.PlagesHoraires.Count();
            var expectedCount = 4;//dans 2hrs avec 2 medecins je dois ouvrir 4 plages horaires pour la Liste d'attente 1
            Assert.Equal(expectedCount, consultations);
        }


        [Fact]
        public async Task GenererPlagesHorairesAsync_NoMedecinsDisponibles()
        {
            IListeAttenteService service = new ListeAttenteService(dbTest);
            var listeAttente = dbTest.ListeAttentes.FirstOrDefault(l => l.ListeAttenteID == 2);

            if (listeAttente == null)
            {
                throw new InvalidOperationException("ListeAttente not found.");
            }
            // Act
            var exception = Assert.Throws<ValidationException>(() => service.VerifierSiNbMedecinsDisponibles(listeAttente));

            // Assert
            Assert.Equal("On doit avoir au moins un medecin disponible.", exception.Message);
        }



        [Fact]
        public async Task GenererPlagesHorairesAsync_ListeDejaExistanteDansLaBD()
        {
            IListeAttenteService service = new ListeAttenteService(dbTest);
            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 };
            if (listeAttente == null)
            {
                throw new InvalidOperationException("ListeAttente not found.");
            }

            // Act
            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiListeAttenteExisteMemeJourClinique(DateTime.Today, listeAttente.CliniqueID));

            // Assert
            Assert.Equal("Il existe deja une liste d'attente dans la meme clinique pour la meme date.", exception.Message);
        }




        [Fact]
        public async Task GenererPlagesHorairesAsync_HeureOuvertureInvalide()
        {
            IListeAttenteService service = new ListeAttenteService(dbTest);
            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(10), HeureFermeture = TimeSpan.FromHours(9), NbMedecinsDispo = 2, CliniqueID = 1 };
            if (listeAttente == null)
            {
                throw new InvalidOperationException("ListeAttente not found.");
            }

            // Act
            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiHeureOuvertureValide(listeAttente));

            // Assert
            Assert.Equal("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.", exception.Message);
        }

        [Fact]
        public async Task GenererPlagesHorairesAsync_DateEffectiviteInvalide()
        {
            IListeAttenteService service = new ListeAttenteService(dbTest);
            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today.AddDays(-1), HeureOuverture = TimeSpan.FromHours(10), HeureFermeture = TimeSpan.FromHours(9), NbMedecinsDispo = 2, CliniqueID = 1 };
            if (listeAttente == null)
            {
                throw new InvalidOperationException("ListeAttente not found.");
            }

            // Act
            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiDateEffectiviteValide(listeAttente));

            // Assert
            Assert.Equal("La date d'effectivite n'est pas valide. Elle doit etre posterieure a la date actuelle.", exception.Message);
        }
    }


}
    
