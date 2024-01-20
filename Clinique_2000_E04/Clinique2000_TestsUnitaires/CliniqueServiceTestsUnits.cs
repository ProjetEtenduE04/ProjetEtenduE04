using Clinique2000_Core.Models;
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
    public class CliniqueServiceTests_ObtenirCliniqueParNomAsync
    {
        [Fact]
        public async Task ObtenirCliniqueParNomAsync_ValidName_ReturnsClinique()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext, Mock.Of<IAdresseService>());
            var clinicName = "TestClinique";
            var expectedClinique = new Clinique
            {
                NomClinique = clinicName,
                Courriel = "test@example.com",
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            dbContext.Cliniques.Add(expectedClinique);
            dbContext.SaveChanges();

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
            var dbContext1 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext1, Mock.Of<IAdresseService>());
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
            var dbContext2 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext2, Mock.Of<IAdresseService>());
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
            var dbContext3 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext3, Mock.Of<IAdresseService>());
            var courriel = "test@example.com";
            var expectedClinique = new Clinique
            {
                CliniqueID = 4, // Update the CliniqueID to match the ID in your in-memory database
                NomClinique = "TestClinique",
                Courriel = courriel,
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            dbContext3.Cliniques.Add(expectedClinique);
            dbContext3.SaveChanges();

            // Act
            var result = await cliniqueService.ObtenirCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClinique, result);
        }

        [Fact]
        public async Task ObtenirCliniqueParCourrielAsync_NullCourriel_ReturnsNull()
        {
            // Arrange
            var dbContext4 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext4, Mock.Of<IAdresseService>());
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
            var dbContext5 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext5, Mock.Of<IAdresseService>());
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
            var dbContext6 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext6, Mock.Of<IAdresseService>());
            var courriel = "test@example.com";
            var expectedClinique = new Clinique
            {
                NomClinique = "TestClinique",
                Courriel = courriel,
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(8),
                HeureFermeture = TimeSpan.FromHours(18),
            };
            dbContext6.Cliniques.Add(expectedClinique);
            dbContext6.SaveChanges();

            // Act
            var result = await cliniqueService.VerifierExistenceCliniqueParCourrielAsync(courriel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task VerifierExistenceCliniqueParCourrielAsync_NonExistentClinique_ReturnsFalse()
        {
            // Arrange
            var dbContext7 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext7, Mock.Of<IAdresseService>());
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
            var dbContext8 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext8, Mock.Of<IAdresseService>());
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
            var dbContext9 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext9, Mock.Of<IAdresseService>());
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
        public async Task VerifierSiHeureOuvertureValide_InvalidOpeningHours_ThrowsValidationException()
        {
            // Arrange
            var dbContext10 = CreateDbContext();
            var cliniqueService = new CliniqueService(dbContext10, Mock.Of<IAdresseService>());
            var clinique = new Clinique
            {
                NomClinique = "TestClinique",
                Courriel = "test@example.com",
                CreateurID = "SDASDA231231ADSA3213DSAD",
                HeureOuverture = TimeSpan.FromHours(18), // Set opening hours after closing hours
                HeureFermeture = TimeSpan.FromHours(8),  // Set closing hours before opening hours
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => cliniqueService.VerifierSiHeureOuvertureValide(clinique));
            Assert.Equal("L'heure d'ouverture doit être inférieure à l'heure de fermeture.", exception.Message);
        }

        private CliniqueDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext11 = new CliniqueDbContext(options);
            dbContext11.Database.EnsureCreated();
            return dbContext11;
        }
    }
}
