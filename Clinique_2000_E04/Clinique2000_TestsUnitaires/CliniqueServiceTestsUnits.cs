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

        [Fact]
        public async Task ObtenirCliniqueParNomAsync_ValidName_ReturnsClinique()
        {
            // Arrange
            var cliniqueService = new CliniqueService(_dbContext, Mock.Of<IAdresseService>());
            var clinicName = "TestClinique";
            var expectedClinique = new Clinique
            {
                NomClinique = clinicName,
                Courriel = "test@example.com",
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            _dbContext.Cliniques.Add(expectedClinique);
            _dbContext.SaveChanges();

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
            var dbContext = CreateDbContext(); // Create a new DbContext instance for isolation
            var cliniqueService = new CliniqueService(dbContext, Mock.Of<IAdresseService>());
            var courriel = "test@example.com";
            var expectedClinique = new Clinique
            {
                CliniqueID = 5, // Choose a unique CliniqueID that doesn't exist in the database
                NomClinique = "TestClinique",
                Courriel = courriel,
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            dbContext.Cliniques.Add(expectedClinique);
            dbContext.SaveChanges();

            // Act
            var result = await cliniqueService.ObtenirCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClinique.CliniqueID, result.CliniqueID);
            Assert.Equal(expectedClinique.NomClinique, result.NomClinique);
            Assert.Equal(expectedClinique.Courriel, result.Courriel);
            Assert.Equal(expectedClinique.CreateurID, result.CreateurID);
            Assert.Equal(expectedClinique.HeureOuverture, result.HeureOuverture);
            Assert.Equal(expectedClinique.HeureFermeture, result.HeureFermeture);

            // Clean up the DbContext to ensure isolation
            dbContext.Dispose();
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
