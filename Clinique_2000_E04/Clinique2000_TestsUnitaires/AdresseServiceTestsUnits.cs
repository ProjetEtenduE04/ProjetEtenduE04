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
    }
}
