using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class CliniqueServiceTestsUnits
    {
        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(uniqueName)
                .Options;
            SeedInMemoryStore(options);
            return options;
        }

        private void SeedInMemoryStore(DbContextOptions<CliniqueDbContext> options)
        {
            using (var context = new CliniqueDbContext(options))
            {
                if (!context.Cliniques.Any())
                    context.Cliniques.AddRange(
                        new Clinique()
                        {
                            CliniqueID = 1,
                            NomClinique = "Anh Anh",
                            Courriel = "anieewon@gmail.com",
                            HeureOuverture = new TimeSpan(8, 0, 0),
                            HeureFermeture = new TimeSpan(18, 0, 0),
                            TempsMoyenConsultation = 30,
                            EstActive = false,
                            AdresseID = 1
                        },
                        new Clinique()
                        {
                            CliniqueID = 2,
                            NomClinique = "Nguyen Nguyen",
                            Courriel = "anieewon@gmail.com",
                            HeureOuverture = new TimeSpan(8, 0, 0),
                            HeureFermeture = new TimeSpan(18, 0, 0),
                            TempsMoyenConsultation = 30,
                            EstActive = false,
                            AdresseID = 2
                        }
                    );
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task GetListeAttentePourPatientAsync_FiltersAndOrdersCorrectly()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new CliniqueService(context);

            // Act
            var result = await service.GetListeAttentePourPatientAsync(1, true);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(la => la.Clinique.CliniqueID == 1 && la.IsOuverte == true));
            Assert.Equal(result, result.OrderBy(x => x.DateEffectivite).ToList());
        }
    }
}
