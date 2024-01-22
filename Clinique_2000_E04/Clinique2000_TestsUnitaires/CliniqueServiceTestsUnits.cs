using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class CliniqueServiceTests_ObtenirCliniqueParNomAsync : IDisposable
    {
        private readonly CliniqueDbContext _dbContext;

        public CliniqueServiceTests_ObtenirCliniqueParNomAsync()
        {
            _dbContext = CreateDbContext();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        // Définir la DB InMemory

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
                    context.Cliniques.AddRange(
                       new Clinique()
                       {
                           CliniqueID = 1,
                           NomClinique = "CliniqueA",
                           Courriel = "test@clinique2000.com",
                           HeureOuverture = new TimeSpan(8, 0, 0),
                           HeureFermeture = new TimeSpan(17, 0, 0),
                           TempsMoyenConsultation = 30,
                           EstActive = true,
                           AdresseID = 1,
                           NumTelephone = "(438) 333-5555",
                           CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",

                       },
                        new Clinique()
                        {
                            CliniqueID = 2,
                            NomClinique = "CliniqueB",
                            Courriel = "Test2@test.com",
                            HeureOuverture = new TimeSpan(8, 0, 0),
                            HeureFermeture = new TimeSpan(17, 0, 0),
                            TempsMoyenConsultation = 30,
                            EstActive = true,
                            AdresseID = 2,
                            NumTelephone = "(438) 333-7777",
                            CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
                        }
                   ); 
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task ObtenirCliniqueParNomAsync_ValidName_ReturnsClinique()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var cliniqueService = new CliniqueService(context, Mock.Of<IAdresseService>());
            var clinicName = "CliniqueA";
            var expectedClinique = await context.Cliniques.FirstOrDefaultAsync();

            // Act
            var result = await cliniqueService.ObtenirCliniqueParNomAsync(clinicName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClinique, result);
        }

        [Fact]
        public async Task ObtenirCliniqueParNomAsync_NullName_ReturnsNull()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            string clinicName = null;

            // Act
            var result = await cliniqueService.ObtenirCliniqueParNomAsync(clinicName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ObtenirCliniqueParNomAsync_NonExistentName_ReturnsNull()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var clinicName = "NonExistentClinique";

            // Act
            var result = await cliniqueService.ObtenirCliniqueParNomAsync(clinicName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ObtenirCliniqueParCourrielAsync_ValidCourriel_ReturnsClinique()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var cliniqueService = new CliniqueService(context, Mock.Of<IAdresseService>());

            // Act
            var resultClinique = await cliniqueService.ObtenirCliniqueParCourrielAsync("test@clinique2000.com");

                // Assert
                Assert.NotNull(resultClinique);
                Assert.Equal("test@clinique2000.com", resultClinique.Courriel); 
        }

        [Fact]
        public async Task ObtenirCliniqueParCourrielAsync_NullCourriel_ReturnsNull()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            string courriel = null;

            // Act
            var result = await cliniqueService.ObtenirCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ObtenirCliniqueParCourrielAsync_NonExistentCourriel_ReturnsNull()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var courriel = "NonExistent@example.com";

            // Act
            var result = await cliniqueService.ObtenirCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task VerifierExistenceCliniqueParCourrielAsync_ExistingClinique_ReturnsTrue()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var courriel = "test@example.com";
            var expectedClinique = new Clinique
            {
                NomClinique = "TestClinique",
                Courriel = courriel,
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            _dbContext.Cliniques.Add(expectedClinique);
            _dbContext.SaveChanges();

            // Act
            var result = await cliniqueService.VerifierExistenceCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task VerifierExistenceCliniqueParCourrielAsync_NonExistentClinique_ReturnsFalse()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var courriel = "nonexistent@example.com";

            // Act
            var result = await cliniqueService.VerifierExistenceCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task VerifierExistenceCliniqueParCourrielAsync_NullCourriel_ReturnsFalse()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            string courriel = null;

            // Act
            var result = await cliniqueService.VerifierExistenceCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task VerifierSiHeureOuvertureValide_ValidOpeningHours_ReturnsTrue()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var clinique = new Clinique
            {
                NomClinique = "TestClinique",
                Courriel = "test@example.com",
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };

            // Act
            var result = await cliniqueService.VerifierSiHeureOuvertureValide(clinique);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifierSiHeureOuvertureValide_InvalidOpeningHours_ReturnsFalse()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var clinique = new Clinique
            {
                NomClinique = "TestClinique",
                Courriel = "test@example.com",
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(18), // Set opening hours after closing hours
                HeureFermeture = TimeSpan.FromHours(8),  // Set closing hours before opening hours
            };

            // Act
            var result = cliniqueService.VerifierSiHeureOuvertureValide(clinique);

            // Assert
            Assert.False(result.Result);
        }



        [Fact]
        public async Task EnregistrerCliniqueAsync_ValidInput_ReturnsClinique()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var adresseService = new Mock<IAdresseService>();
            adresseService.Setup(s => s.VerifierCodePostalValideAsync(It.IsAny<string>())).ReturnsAsync(true);

            var cliniqueService = new CliniqueService(dbContext, adresseService.Object);
            var viewModel = new CliniqueAdresseVM
            {
                Clinique = new Clinique
                {
                    NomClinique = "NewClinique",
                    Courriel = "new@example.com",
                    CreateurID = "12345",
                    HeureOuverture = TimeSpan.FromHours(8),
                    HeureFermeture = TimeSpan.FromHours(18)
                },
                Adresse = new Adresse
                {
                    Numero = "123",
                    Rue = "Main Street",
                    Ville = "City",
                    Province = "State",
                    Pays = "Country",
                    CodePostal = "A1A 1A1"
                }
            };

            // Act
            var result = await cliniqueService.EnregistrerCliniqueAsync(viewModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(viewModel.Clinique.NomClinique, result.NomClinique);

            // Add more assertions as needed to verify the returned Clinique object and other conditions.
            dbContext.Dispose();
        }

        private CliniqueDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new CliniqueDbContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
