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
namespace Clinique2000_TestsUnitaires
{
    public class ListeAttenteServiceTestsUnits
    {


        //Définir la BD inMemory 
        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options);
            return options;
        }

        //Preparer des valeurs 
        private void SeedInMemoryStore(DbContextOptions<CliniqueDbContext> options)
        {

            using (var context = new CliniqueDbContext(options))
            {
                if (!context.Cliniques.Any())
                {
                    context.Cliniques.AddRange(
                     new Clinique { CliniqueID = 1, TempsMoyenConsultation = 30 },
                     new Clinique { CliniqueID = 2, TempsMoyenConsultation = 30 },
                     new Clinique { CliniqueID = 3, TempsMoyenConsultation = 30 }
                     );
                    context.SaveChanges();
                }

                if (!context.ListeAttentes.Any())
                {
                    context.ListeAttentes.AddRange(
                     new ListeAttente { ListeAttenteID = 1, DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 },
                     new ListeAttente { ListeAttenteID = 2, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 },
                     new ListeAttente { ListeAttenteID = 3, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 3 },
                     new ListeAttente { ListeAttenteID = 4, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 2 }


                     );
                    context.SaveChanges();
                }
            }
        }
            //[Fact]
            //public async Task GenererPlagesHorairesAsync_CreatesCorrectNumberOfTimeSlots()
            //{


            //    // Context avec la BD en memorie
            //    using (var context = new CliniqueDbContext(SetUpInMemory("PlageHoraires"))
            //    {
                    
            //        var listeAttente = new ListeAttente
            //        {
            //            DateEffectivite = DateTime.Today,
            //            HeureOuverture = TimeSpan.FromHours(8),
            //            HeureFermeture = TimeSpan.FromHours(10),
            //            NbMedecinsDispo = 2,
            //            Clinique = new Clinique { TempsMoyenConsultation = 30 } // Asume 30 minutos por consulta
            //        };

            //        // Act
            //        service.GenererPlagesHorairesAsync(listeAttente);

            //        // Assert
            //        var createdSlots = context.PlagesHoraires.Count();
            //        var expectedCount = 4;//dans 2hrs avec 2 medecins je dois ouvrir 4 plages horaires
            //        Assert.Equal(expectedCount, createdSlots);
            //    }
            //}


        }
    }
