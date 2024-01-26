using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class AdresseServiceTestsUnits
    {
        /// <summary>
        /// Vérifie si un code postal valide retourne true de manière asynchrone.
        /// </summary>
        [Fact]
        public async Task VerifierCodePostalValideAsync_CodePostalValide_RetourneTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Nom de base de données unique pour chaque test
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                var adresseService = new AdresseService(dbContext);
                var codePostalValide = "A1A 1A1";

                // Act
                var resultat = await adresseService.VerifierCodePostalValideAsync(codePostalValide);

                // Assert
                Assert.True(resultat);
            }
        }

        /// <summary>
        /// Vérifie si un code postal invalide lance une ValidationException de manière asynchrone.
        /// </summary>
        [Fact]
        public async Task VerifierCodePostalValideAsync_CodePostalInvalide_LanceValidationException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Nom de base de données unique pour chaque test
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                var adresseService = new AdresseService(dbContext);
                var codePostalInvalide = "CodePostalInvalide";

                // Act & Assert
                await Assert.ThrowsAsync<ValidationException>(() => adresseService.VerifierCodePostalValideAsync(codePostalInvalide));
            }
        }



        [Fact]
        public void CalculerDistance_RetourneDistanceCorrecte()
        {
            // Préparation
            var adresseService = new AdresseService(null); // Pas besoin de DbContext pour ce test
            double lat1 = 45.5017; // Latitude exemple pour Montréal
            double lon1 = -73.5673; // Longitude exemple pour Montréal
            double lat2 = 43.6532; // Latitude exemple pour Toronto
            double lon2 = -79.3832; // Longitude exemple pour Toronto

            // Action
            var distance = adresseService.CalculerDistance(lat1, lon1, lat2, lon2);

            // Vérification
            Assert.True(distance > 0); // Vérifiez si la distance est positive et significative
        }

        [Fact]
        public void ToRadians_ConvertitDegresEnRadians()
        {
            // Préparation
            var adresseService = new AdresseService(null); // Pas besoin de DbContext pour ce test
            double angle = 180; // Angle exemple

            // Action
            var radians = adresseService.ToRadians(angle);

            // Vérification
            Assert.Equal(Math.PI, radians, 5); // Vérifie la précision de la conversion à 5 décimales près
        }

        [Fact]
        public async Task CalculerDistanceEntre2CodesPostaux_RetourneDistancePourCodesPostauxValides()
        {
            // Préparation
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                // Ajout de données de test dans la base de données
                var location1 = new AdressesQuebec { Id = 167724, PostalCode = "J4G 1C4", City = "LONGUEUIL", ProvinceAbbr = "QC", TimeZone = 5, Latitude = 45.570322, Longitude = -73.480425 }; // Longueuil
                var location2 = new AdressesQuebec { Id = 164541, PostalCode = "J3Y 0B1", City = "SAINT-HUBERT", ProvinceAbbr = "QC", TimeZone = 5, Latitude = 45.50854, Longitude = -73.417819 }; // St-Hubert
                dbContext.AdressesQuebec.Add(location1);
                dbContext.AdressesQuebec.Add(location2);
                await dbContext.SaveChangesAsync();

                var adresseService = new AdresseService(dbContext);

                // Action
                var distance = await adresseService.CalculerDistanceEntre2CodesPostaux("J4G 1C4", "J3Y 0B1");

                // Vérification
                Assert.True(distance > 0); // Vérifie si la distance est positive et significative
            }
        }

        [Fact]
        public async Task CalculerDistanceEntre2CodesPostaux_LanceExceptionPourCodePostalInvalide()
        {
            // Préparation
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                var adresseService = new AdresseService(dbContext);

                // Action & Vérification
                await Assert.ThrowsAsync<ArgumentException>(
                    () => adresseService.CalculerDistanceEntre2CodesPostaux("Invalid1", "Invalid2"));
            }
        }



    }
}
